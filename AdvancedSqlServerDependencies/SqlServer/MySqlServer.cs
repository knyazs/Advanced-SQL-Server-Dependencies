using AdvancedSqlServerDependencies.CustomOutput;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.Progress;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer.View;
using AdvancedSqlServerDependencies.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdvancedSqlServerDependencies.SqlServer
{
    public partial class MySqlServer : Component
    {
        public delegate void MainConnectionChangedEventHandler(object sender, MainConnectionChangedEventArgs e);
        public event MainConnectionChangedEventHandler OnMainConnectionChangedEvent;

        public delegate void DataChangedEventHandler(object sender, DataChangedEventArgs e);
        public event DataChangedEventHandler OnDataChanged;

        public delegate void CheckedDatabasesChangedEventHandler(object sender, EventArgs e);
        public event CheckedDatabasesChangedEventHandler OnCheckedDatabasesChanged;

        //

        public ConnectionPool ConnectionPool; //serverId, connection to server

        private List<MySqlServerObject> _sqlServerObjects;
        public MySqlServerObject[] SqlServerObjects
        {
            get
            {
                return _sqlServerObjects.ToArray();
            }
        }

        private List<MySqlDatabase> _sqlDatabases;
        public MySqlDatabase[] SqlDatabases
        {
            get
            {
                return _sqlDatabases.ToArray();
            }
        }
        public MySqlDatabase[] SqlCheckedDatabases
        {
            get { return SqlDatabases.Where(d => d.IsChecked).ToArray(); }
        }
        public MySqlDatabase[] SqlDisabledDatabases
        {
            get
            {
                var unsupported = SqlDatabases.Where(d => SqlServerObjects.Where(s => !s.IsValid).Select(s => s.ServerObjectId).Contains(d.ServerObjectId));
                var notOnline = SqlDatabases.Where(d => d.State != "ONLINE");
                var noAccess = SqlDatabases.Where(d => d.UserHasDbAccess == false);
                return unsupported.Union(notOnline).Union(noAccess).ToArray();
            }
        }

        private List<MySqlDatabase> _sqlLoadedDatabases;
        public MySqlDatabase[] SqlLoadedDatabases
        {
            get { return (_sqlLoadedDatabases != null) ? _sqlLoadedDatabases.ToArray() : null; }
        }

        private List<MySqlObject> _sqlObjects;
        public MySqlObject[] SqlObjects
        {
            get
            { return _sqlObjects.ToArray(); }
        }
        public Dictionary<int[], MySqlObject> SqlObjectsEx
        {
            get
            {
                var dict = new Dictionary<int[], MySqlObject>();
                var key = new int[4];
                foreach(var o in _sqlObjects)
                {
                    key[0] = o.ServerObjectId;
                    key[1] = o.DatabaseId;
                    key[2] = o.SchemaId;
                    key[3] = o.ObjectId;
                    dict.Add(key, o);
                }
                return dict;
            }
        }

        private List<MySqlExpressionDependency> _sqlExpressionDependencies;
        public MySqlExpressionDependency[] SqlExpressionDependencies
        {
            get
            {
                return _sqlExpressionDependencies.ToArray();
            }
        }

        public Dictionary<MyKeyList, MySqlExpressionDependency> SqlExpressionDependenciesEx;
        //{
        //    get
        //    {
        //        Console.Write("Preparing Ex Dependencies...");
        //        Dictionary<MyKeyList, MySqlExpressionDependency> dict = new Dictionary<MyKeyList, MySqlExpressionDependency>();
        //        foreach (var ed in _sqlExpressionDependencies)
        //        {
        //            var keys = new MyKeyList();
        //            keys.Add(ed.ParentServerObjectId);
        //            keys.Add(ed.ParentDatabaseId);
        //            keys.Add(ed.ParentObjectId);
        //            keys.Add(ed.ChildServerObjectId);
        //            keys.Add(ed.ChildDatabaseId);
        //            keys.Add(ed.ChildObjectId);
        //            dict.Add(keys, ed);
        //        }
        //        return dict;
        //    }
        //}


        private DateTime _lastDataLoad;
        public DateTime LastDataLoad { get { return _lastDataLoad; } }

        public ESqlServerStatus _status = ESqlServerStatus.NOT_INITIALIZED;
        public ESqlServerStatus Status { get { return _status; } }

        public string DataSource
        { get { return getDataSourceName(0); } }

        public int CheckedDatabasesCount
        {
            get
            {
                return SqlDatabases.Count(d => d.IsChecked);
            }
        }

        public MySqlServer()
        {
            InitializeComponent();
        }

        public MySqlServer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ConnectionPool = new ConnectionPool();
            _sqlServerObjects = new List<MySqlServerObject>();
            _sqlDatabases = new List<MySqlDatabase>();
            _sqlLoadedDatabases = new List<MySqlDatabase>();
            _sqlObjects = new List<MySqlObject>();
            _sqlExpressionDependencies = new List<MySqlExpressionDependency>();

            SqlExpressionDependenciesEx = new Dictionary<MyKeyList, MySqlExpressionDependency>();
        }

        internal bool RefreshServers(string connectionString)
        {

            if (!string.IsNullOrEmpty(connectionString))
            {
                // Remove all connections
                ConnectionPool.RemoveAllConnections();
                ConnectionPool.AddConnection(connectionString, 0);
            }
            else
            {
                // Remove all except main connection
                foreach (int id in ConnectionPool.ServerObjectIds.Where(x => x > 0))
                    ConnectionPool.RemoveConnection(id);
            }

            ConnectionPool.Connect(new[] { 0 });
            if (!ConnectionPool.ConfirmedServerObjectIds.Contains(0))
                return false;


            initSqlServerObjects();
            initSqlDatabases();

            if (!string.IsNullOrEmpty(connectionString) && OnMainConnectionChangedEvent != null)
            {
                var e = new MainConnectionChangedEventArgs { DataSourceName = getDataSourceName(0) };
                OnMainConnectionChangedEvent(this, e);
            }

            return true;
        }

        internal bool RefreshServers()
        {
            return RefreshServers(null);
        }

        public void SetCheckedDatabases(MySqlDatabase[] mySqlDatabases)
        {
            foreach (MySqlDatabase db in SqlDatabases)
            {
                db.IsChecked = (mySqlDatabases.Contains(db));
            }

            if (OnCheckedDatabasesChanged != null)
                OnCheckedDatabasesChanged(this, EventArgs.Empty);
        }


        #region SQL Object Initialization

        private void initSqlServerObjects()
        {
            DateTime dt = DateTime.Now;

            _sqlServerObjects.Clear();

            try
            {
                MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading server objects for server ({0}) '{1}'...", 0, getDataSourceName(0)));

                // Load Server data
                SqlCommand cmd = (SqlCommand)ConnectionPool.GetConnection(0).CreateCommand();
                cmd.CommandText = QueryReader.Read("server_objects.sql");
                cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // Create new server object
                    var so = new MySqlServerObject
                    {
                        ServerObjectId = (int)(rdr["server_id"]),
                        ServerObjectName = (string)rdr["data_source"],
                        IsLinked = (bool)rdr["is_linked"],
                        Product = (string)rdr["product"],
                        Provider = (string)rdr["provider"]
                    };

                    // Add new server objects
                    _sqlServerObjects.Add(so);

                    // Add new connections in the pool
                    if (so.ServerObjectId > 0)
                    {
                        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(ConnectionPool.GetConnection(0).ConnectionString);
                        scsb.DataSource = so.ServerObjectName;

                        ConnectionPool.AddConnection(scsb.ConnectionString, so.ServerObjectId);
                    }
                }
                rdr.Close();

                // Check connections
                ConnectionPool.Connect(_sqlServerObjects.Select(x => x.ServerObjectId).ToArray());
                List<int> soid = new List<int>();
                soid.AddRange(_sqlServerObjects.Select(x => x.ServerObjectId));

                foreach (int id in soid.ToArray())
                {
                    if (!ConnectionPool.ConfirmedServerObjectIds.Contains(id))
                    {
                        _sqlServerObjects.RemoveAll(x => x.ServerObjectId == id);
                    }
                }


                // Server Properties
                foreach (MySqlServerObject so in _sqlServerObjects)
                {
                    cmd = (SqlCommand)ConnectionPool.GetConnection(so.ServerObjectId).CreateCommand();
                    cmd.CommandText = QueryReader.Read("server_properties.sql");
                    cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                    cmd.CommandType = CommandType.Text;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        so.ProductVersionCode = (string)rdr["product_version"];
                        so.ProductLevel = (string)rdr["product_level"];
                        so.Edition = (string)rdr["edition"];
                        so.ProcessId = (int)rdr["process_id"];
                        so.EditionID = (int)rdr["edition_id"];
                        so.LicenseType = (string)rdr["license_type"];
                    }
                    rdr.Close();
                }
                MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} servers.", _sqlServerObjects.Count), (DateTime.Now - dt).TotalSeconds);
            }
            catch (Exception ex)
            {
                MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Error loading server objects: {0}", ex.Message));
                var exForm = new ExceptionForm(ex);
                exForm.ShowDialog();
            }
        }

        private void initSqlDatabases()
        {
            DateTime dt = DateTime.Now;

            _sqlDatabases.Clear();

            try
            {
                foreach (MySqlServerObject so in _sqlServerObjects)
                {
                    MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading databases from server ({0}) '{1}'...", so.ServerObjectId, getDataSourceName(so.ServerObjectId)));

                    var conn = ConnectionPool.GetConnection(so.ServerObjectId);
                    if (conn != null)
                    {
                        SqlCommand cmd = (SqlCommand)ConnectionPool.GetConnection(so.ServerObjectId).CreateCommand();
                        cmd.CommandText = QueryReader.Read("databases.sql");
                        cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            _sqlDatabases.Add(new MySqlDatabase
                            {
                                ServerObjectId = so.ServerObjectId,
                                ServerObjectName = so.ServerObjectName,
                                DatabaseId = (int)rdr["database_id"],
                                DatabaseName = (string)rdr["database_name"],
                                State = (string)rdr["state_desc"],
                                UserHasDbAccess = (bool)rdr["has_db_access"],
                                CompatibilityLevel = Convert.ToInt32(rdr["compatibility_level"]),
                                CollationName = (string)(rdr["collation_name"] == DBNull.Value ? "Unknown" : rdr["collation_name"]),
                                RecoveryModel = (string)rdr["recovery_model_desc"]
                            });
                        }
                        rdr.Close();

                        MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} databases.", _sqlDatabases.Count(x => x.ServerObjectId == so.ServerObjectId)), (DateTime.Now - dt).TotalSeconds);
                    }
                }
            }
            catch (Exception ex)
            {
                MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Error loading databases: {0}", ex.Message));
                var exForm = new ExceptionForm(ex);
                exForm.ShowDialog();
            }

        }

        private void initSqlObjects(int serverObjectId, int databaseId)
        {
            try
            {
                var serverObjectName = SqlServerObjects.First(so => so.ServerObjectId == serverObjectId).ServerObjectName;
                var databaseName = SqlDatabases.First(d => d.ServerObjectId == serverObjectId && d.DatabaseId == databaseId).DatabaseName;

                MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading objects from server object '{0}', database '{1}'... ", serverObjectName, databaseName));

                int counter = 0;
                DateTime dt = DateTime.Now;

                string query = QueryReader.Read("objects.sql");

                ConnectionPool.GetConnection(serverObjectId).ChangeDatabase(databaseName);
                SqlCommand cmd = (SqlCommand)ConnectionPool.GetConnection(serverObjectId).CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    counter++;
                    _sqlObjects.Add(new MySqlObject
                    {
                        ServerObjectId = serverObjectId,
                        ServerObjectName = serverObjectName,
                        DatabaseId = Convert.ToInt32(rdr["db_id"]),
                        DatabaseName = (string)rdr["db_name"],
                        SchemaId = Convert.ToInt32(rdr["schema_id"]),
                        SchemaName = (string)rdr["schema_name"],
                        ObjectId = (int)(rdr["object_id"]),
                        ObjectName = (string)rdr["object_name"],
                        ObjectTypeId = (string)rdr["type"],
                        ObjectType = (string)rdr["type_desc"],
                        ObjectNameFull = (string)rdr["object_name_full"],
                        BaseObjectNameFull = (rdr["base_object_name_full"] != DBNull.Value) ? rdr["base_object_name_full"].ToString() : null
                    });
                }
                rdr.Close();


                // Row counts
                query = QueryReader.Read("table_sizes.sql");

                cmd = (SqlCommand)ConnectionPool.GetConnection(serverObjectId).CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var obj = _sqlObjects.FirstOrDefault(o => o.ObjectType.Equals("USER_TABLE") &&
                        o.SchemaName.Equals((string)rdr["schema_name"], StringComparison.InvariantCultureIgnoreCase) &&
                        o.ObjectName.Equals((string)rdr["table_name"], StringComparison.InvariantCultureIgnoreCase));

                    if(obj != null)
                    {
                        obj.RowCount = (long)rdr["row_counts"];
                        obj.TotalSpaceUsedKB = (long)rdr["total_space_kb"];
                    }
                }
                rdr.Close();

                // Object definitions
                query = QueryReader.Read("object_definitions.sql");

                cmd = (SqlCommand)ConnectionPool.GetConnection(serverObjectId).CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var obj = _sqlObjects.FirstOrDefault(o => o.ObjectId == (int)rdr["object_id"]);

                    if (obj != null)
                    {
                        obj.ObjectDefinition = (string)rdr["definition"];
                    }
                }
                rdr.Close();

                MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} objects.", counter), (DateTime.Now - dt).TotalSeconds);
            }
            catch (Exception ex)
            {
                MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Error loading database objects: {0}", ex.Message));
                var exForm = new ExceptionForm(ex);
                exForm.ShowDialog();
            }
        }

        //private void initSqlExpressionDependencies(int serverObjectId, int databaseId)
        //{
        //    try
        //    {
        //        var serverObjectName = SqlServerObjects.First(so => so.ServerObjectId == serverObjectId).ServerObjectName;
        //        var databaseName = SqlDatabases.First(d => d.ServerObjectId == serverObjectId && d.DatabaseId == databaseId).DatabaseName;

        //        MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading expression dependencies from server object '{0}', database '{1}'... ", serverObjectName, databaseName));

        //        int counter = 0;
        //        DateTime dt = DateTime.Now;

        //        string query = QueryReader.Read("expression_dependencies.sql");

        //        ConnectionPool.GetConnection(serverObjectId).ChangeDatabase(databaseName);
        //        SqlCommand cmd = (SqlCommand)ConnectionPool.GetConnection(serverObjectId).CreateCommand();
        //        cmd.CommandText = query;
        //        cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //        cmd.CommandType = CommandType.Text;

        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            counter++;

        //            int referencedId = -1;
        //            int.TryParse(rdr["referenced_id"].ToString(), out referencedId);

        //            _sqlExpressionDependencies.Add(new MySqlExpressionDependency
        //            {
        //                ServerObjectId = serverObjectId,
        //                ServerObjectName = serverObjectName,
        //                DatabaseId = databaseId,
        //                DatabaseName = databaseName,
        //                ReferencingId = (int)rdr["referencing_id"],
        //                ReferencedServerName = (string)rdr["referenced_server_name"],
        //                ReferencedDatabaseName = (string)rdr["referenced_database_name"],
        //                ReferencedSchemaName = (string)rdr["referenced_schema_name"],
        //                ReferencedEntityName = (string)rdr["referenced_entity_name"],
        //                ReferencedId = (referencedId != -1) ? referencedId : (int?)null
        //            });
        //        }
        //        rdr.Close();

        //        MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} expression dependencies.", counter), (DateTime.Now - dt).TotalSeconds);
        //    }
        //    catch (Exception ex)
        //    {
        //        MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Error loading expression dependencies: {0}", ex.Message));
        //        var exForm = new ExceptionForm(ex);
        //        exForm.ShowDialog();
        //    }
        //}

        private void initSqlExpressionDependencies(int serverObjectId, int databaseId)
        {
            var serverObjectName = SqlServerObjects.First(so => so.ServerObjectId == serverObjectId).ServerObjectName;
            var databaseName = SqlDatabases.First(d => d.ServerObjectId == serverObjectId && d.DatabaseId == databaseId).DatabaseName;

            MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading expression dependencies from server '{0}', database '{1}'... ", serverObjectName, databaseName));

            int initialNumberOfRows = SqlExpressionDependencies.Length;
            DateTime dt = DateTime.Now;
            //DateTime timeCounterInner;

            DataTable ExpressionDependenciesDataTable = new DataTable();
            string query = QueryReader.Read("expression_dependencies.sql");

            var svr = SqlObjects.FirstOrDefault(o => o.ServerObjectId == serverObjectId);
            var db = SqlObjects.FirstOrDefault(o => o.ServerObjectId == serverObjectId && o.DatabaseId == databaseId);

            if (svr == null || db == null)
            {
                MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} dependencies.", SqlExpressionDependencies.Length - initialNumberOfRows), (DateTime.Now - dt).TotalSeconds);
                return;
            }

            ConnectionPool.GetConnection(serverObjectId).ChangeDatabase(databaseName);
            SqlCommand cmd = ConnectionPool.GetConnection(serverObjectId).CreateCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            ExpressionDependenciesDataTable.Load(cmd.ExecuteReader());

            //var results = from myRow in dataTable.AsEnumerable()
            //              select new
            //              {
            //                  ReferencingId = Convert.ToInt32(myRow["referencing_id"]),
            //                  ReferencedId = Convert.ToInt32(((myRow["referenced_id"] != DBNull.Value) ? Convert.ToInt32(myRow["referenced_id"]) : -1)),
            //                  ReferencedSchemaId = _objectList.First(o => o.ServerName.Equals(serverName, StringComparison.InvariantCultureIgnoreCase)
            //                      && o.DatabaseName.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase)
            //                      && o.SchemaName.Equals((string)myRow["referenced_schema_name"], StringComparison.InvariantCultureIgnoreCase)).SchemaId,
            //                ReferencedEntityName = (string)myRow["referenced_entity_name"]
            //              };


            var databaseDependencies = from myRow in ExpressionDependenciesDataTable.AsEnumerable()
                                       select new
                                       {
                                           ReferencingId = Convert.ToInt32(myRow["referencing_id"]),
                                           ReferencedId = Convert.ToInt32(((myRow["referenced_id"] != DBNull.Value) ? Convert.ToInt32(myRow["referenced_id"]) : -1)),
                                           ReferencedSchemaId = (SqlObjects.FirstOrDefault(o => o.ServerObjectId == serverObjectId
                                               && o.DatabaseId == databaseId
                                               && o.SchemaName.Equals((string)myRow["referenced_schema_name"], StringComparison.InvariantCultureIgnoreCase)) != null) ?
                                               (SqlObjects.FirstOrDefault(o => o.ServerObjectId == serverObjectId
                                               && o.DatabaseId == databaseId
                                               && o.SchemaName.Equals((string)myRow["referenced_schema_name"], StringComparison.InvariantCultureIgnoreCase)).SchemaId)
                                               : -1,
                                           ReferencedServerName = (string)myRow["referenced_server_name"],
                                           ReferencedDatabaseName = (string)myRow["referenced_database_name"],
                                           ReferencedSchemaName = (string)myRow["referenced_schema_name"],
                                           ReferencedEntityName = (string)myRow["referenced_entity_name"]
                                       };



            var res = from dbDep in databaseDependencies
                      join parentObj in SqlObjects.Where(p => p.ServerObjectId == serverObjectId && p.DatabaseId == databaseId)
                      on dbDep.ReferencingId equals parentObj.ObjectId
                      join childObj in SqlObjects.Where(c => c.ServerObjectId == serverObjectId && c.DatabaseId == databaseId)
                      on new { SchemaId = dbDep.ReferencedSchemaId, ObjectId = dbDep.ReferencedId, ObjectName = dbDep.ReferencedEntityName } equals
                          new { SchemaId = childObj.SchemaId, ObjectId = childObj.ObjectId, ObjectName = childObj.ObjectName }
                      select new MySqlExpressionDependency
                      {
                          ServerObjectId = serverObjectId,
                          DatabaseId = databaseId,
                          ParentServerObjectId = parentObj.ServerObjectId,
                          ParentDatabaseId = parentObj.DatabaseId,
                          ParentObjectId = parentObj.ObjectId,
                          ChildServerObjectId = childObj.ServerObjectId,
                          ChildDatabaseId = childObj.DatabaseId,
                          ChildObjectId = childObj.ObjectId,
                          ChildObjectExists = true
                      };

            var uwq = from dbDep in databaseDependencies.Where(dd => dd.ReferencedId == -1 || dd.ReferencedSchemaId == -1)
                      join parentObj in SqlObjects.Where(p => p.ServerObjectId == serverObjectId && p.DatabaseId == databaseId)
                      on dbDep.ReferencingId equals parentObj.ObjectId
                      select new MySqlExpressionDependency
                      {
                          ServerObjectId = serverObjectId,
                          DatabaseId = databaseId,
                          ParentServerObjectId = parentObj.ServerObjectId,
                          ParentDatabaseId = parentObj.DatabaseId,
                          ParentObjectId = parentObj.ObjectId,
                          ChildServerObjectName = dbDep.ReferencedServerName,
                          ChildDatabaseName = dbDep.ReferencedDatabaseName,
                          ChildSchemaName = dbDep.ReferencedSchemaName,
                          ChildObjectName = dbDep.ReferencedEntityName,
                          ChildObjectExists = false
                      };


            _sqlExpressionDependencies.AddRange(res.Union(uwq));

            MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} dependencies.", res.Count()), (DateTime.Now - dt).TotalSeconds);
        }


        #endregion SQL Object Initialization

        public void Load(bool forceReload)
        {
            DateTime dt;
            int dbCount;
            int counter;

            this._status = ESqlServerStatus.REFRESHING;

            OnDataChanged?.Invoke(this, null);

            // Make backup of all lists in case of use cancells execution
            MySqlDatabase[] oldLoadedDatabases = new MySqlDatabase[_sqlLoadedDatabases.Count];
            MySqlObject[] oldSqlObjects = new MySqlObject[_sqlObjects.Count];
            MySqlExpressionDependency[] oldSqlExpressionDependencies = new MySqlExpressionDependency[_sqlExpressionDependencies.Count];

            _sqlLoadedDatabases.CopyTo(oldLoadedDatabases);
            _sqlObjects.CopyTo(oldSqlObjects);
            _sqlExpressionDependencies.CopyTo(oldSqlExpressionDependencies);


            if (forceReload)
            {
                _sqlLoadedDatabases.Clear();
                _sqlObjects.Clear();
                _sqlExpressionDependencies.Clear();
            }

            MySqlDatabase[] newSqlDatabases = SqlCheckedDatabases.Except(SqlLoadedDatabases).ToArray();
            MySqlDatabase[] oldSqlDatabases = SqlLoadedDatabases.Except(SqlCheckedDatabases).ToArray();

            counter = 0;
            dbCount = newSqlDatabases.Length * 2 + oldSqlDatabases.Length;

            // Remove unnecessary objects from unused database
            if (oldSqlDatabases.Length > 0)
            {
                foreach (MySqlDatabase oldDb in oldSqlDatabases)
                {
                    if (LongRunningOperationManager.CancellationPending)
                        break;

                    dt = DateTime.Now;
                    MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Removing unnecessary objects for server '{0}', database '{1}' from internal database... ", oldDb.ServerObjectName, oldDb.DatabaseName));
                    int deletedObjectCount = _sqlObjects.RemoveAll(o => o.ServerObjectId == oldDb.ServerObjectId && o.DatabaseId == oldDb.DatabaseId);
                    MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Removed {0:n0} objects.", deletedObjectCount), (DateTime.Now - dt).TotalSeconds);

                    dt = DateTime.Now;
                    MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Removing unnecessary dependencies for server '{0}', database '{1}' from internal database... ", oldDb.ServerObjectName, oldDb.DatabaseName));
                    int deletedExpressionDependencyCount = _sqlExpressionDependencies.RemoveAll(o => o.ServerObjectId == oldDb.ServerObjectId && o.DatabaseId == oldDb.DatabaseId);
                    MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Removed {0:n0} dependencies.", deletedExpressionDependencyCount), (DateTime.Now - dt).TotalSeconds);

                    LongRunningOperationManager.ReportProgress(100 * ++counter / dbCount);
                }
            }

            if (newSqlDatabases.Length > 0)
            {
                foreach (MySqlDatabase newDb in newSqlDatabases)
                {
                    if (LongRunningOperationManager.CancellationPending)
                        break;

                    initSqlObjects(newDb.ServerObjectId, newDb.DatabaseId);
                    //loadDatabaseObjects(newDb.ServerObjectName, newDb.DatabaseName);

                    LongRunningOperationManager.ReportProgress(100 * ++counter / dbCount);
                }
                MyOutput.NewMessage(EOutputMessageType.INFORMATION, string.Format("Totally {0:n0} objects loaded from {1:n0} server(s) and {2:n0} database(s).", _sqlObjects.Count, SqlCheckedDatabases.Select(s => s.ServerObjectName).Distinct().Count(), SqlCheckedDatabases.Length));

                // ALL OBJECTS FROM ALL SERVERS / DATABASES MUST BE LOADED FIRST!
                foreach (MySqlDatabase newDb in newSqlDatabases)
                {
                    if (LongRunningOperationManager.CancellationPending)
                        break;

                    initSqlExpressionDependencies(newDb.ServerObjectId, newDb.DatabaseId);

                    LongRunningOperationManager.ReportProgress(100 * ++counter / dbCount);
                }
                MyOutput.NewMessage(EOutputMessageType.INFORMATION, string.Format("Totally {0:n0} dependencies loaded from {1:n0} server(s) and {2:n0} database(s).", _sqlExpressionDependencies.Count, SqlCheckedDatabases.Select(s => s.ServerObjectName).Distinct().Count(), SqlCheckedDatabases.Length));
            }

            if (!LongRunningOperationManager.CancellationPending)
            {
                _sqlLoadedDatabases.Clear();
                _sqlLoadedDatabases.AddRange(SqlCheckedDatabases);

                if (oldSqlDatabases.Length > 0 || newSqlDatabases.Length > 0)
                {
                    this._lastDataLoad = DateTime.Now;
                }
            }
            else
            {
                _sqlLoadedDatabases.Clear();
                _sqlObjects.Clear();
                _sqlExpressionDependencies.Clear();

                _sqlLoadedDatabases.AddRange(oldLoadedDatabases);
                _sqlObjects.AddRange(oldSqlObjects);
                _sqlExpressionDependencies.AddRange(oldSqlExpressionDependencies);
            }

            this._status = ESqlServerStatus.READY;


            // Prepare EX lists
            /*
            SqlExpressionDependenciesEx.Clear();
            foreach (var ed in _sqlExpressionDependencies)
            {
                var keys = new MyKeyList();
                keys.Add(ed.ParentServerObjectId);
                keys.Add(ed.ParentDatabaseId);
                keys.Add(ed.ParentObjectId);
                keys.Add(ed.ChildServerObjectId);
                keys.Add(ed.ChildDatabaseId);
                keys.Add(ed.ChildObjectId);
                SqlExpressionDependenciesEx.Add(keys, ed);
            }
            */

            OnDataChanged?.Invoke(this, null);
        }




        private string getDataSourceName(int serverObjectId)
        {
            var conn = ConnectionPool.GetConnection(serverObjectId);
            if (conn == null)
                return "Unknown";

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(conn.ConnectionString);
            return scsb.DataSource;
        }
    }

    public class DataChangedEventArgs : EventArgs
    {
        public int ObjectCount { get; set; }
        public int DependencyCount { get; set; }
        public DateTime LastRefresh { get; set; }
        public ESqlServerStatus Status { get; set; }
        public string Size;
    }

    public class MainConnectionChangedEventArgs : EventArgs
    {
        public string DataSourceName;
    }

    public enum ESqlServerStatus
    {
        NOT_INITIALIZED,
        REFRESHING,
        READY
    }





    public sealed class MyKeyList : ArrayList, IEquatable<MyKeyList>
    {
        public bool Equals(MyKeyList other)
        {
            return other != null && this.ToArray().SequenceEqual(other.ToArray());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(item.ToString());
            }

            return "OBJECT=[" + sb.ToString() + "]";
        }
    }

    public class MyKeyColumnArrayListComparer : IEqualityComparer<MyKeyList>
    {
        public bool Equals(MyKeyList x, MyKeyList y)
        {
            return x != null && y != null && x.ToArray().SequenceEqual(y.ToArray());
        }

        public int GetHashCode(MyKeyList obj)
        {
            int hashCode = -1;
            foreach (var item in obj)
            {
                var s = item.ToString();
                int hash2 = s.GetHashCode();
                hashCode = hashCode == -1 ? hash2 : GetHashCodeInternal(hashCode, hash2);
            }

            return hashCode;
        }

        // http://stackoverflow.com/questions/9976224/c-sharp-generic-dictionary-trygetvalue-doesnt-find-keys
        private static int GetHashCodeInternal(int key1, int key2)
        {
            unchecked
            {
                //Seed
                var num = 0x7e53a269;

                //Key 1
                num = (-1521134295 * num) + key1;
                num += (num << 10);
                num ^= (num >> 6);

                //Key 2
                num = ((-1521134295 * num) + key2);
                num += (num << 10);
                num ^= (num >> 6);

                return num;
            }
        }
    }
}
