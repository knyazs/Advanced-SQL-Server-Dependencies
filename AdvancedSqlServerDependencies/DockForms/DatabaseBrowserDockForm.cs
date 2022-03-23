using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.Properties;
using BrightIdeasSoftware;
using WeifenLuo.WinFormsUI.Docking;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class DatabaseBrowserDockForm : DockContent
    {
        private MySqlServer _mySqlServer;


        // =========================================

        public DatabaseBrowserDockForm(ref MySqlServer mySqlServer)
        {
            _mySqlServer = mySqlServer;

            int normalIdx = 0;
            int linkedIdx = 100000;

            InitializeComponent();

            objectListView1.Groups.Clear();

            olvColumnDatabaseName.GroupKeyGetter = delegate (object x)
            {
                return ((MySqlDatabase)x).ServerObjectName;
            };

            olvColumnDatabaseName.GroupFormatter = delegate (OLVGroup group, GroupingParameters parms)
            {
                var svr = _mySqlServer.SqlServerObjects.First(x => x.ServerObjectName.Equals(group.Key.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (!svr.IsValid)
                    group.TitleImage = 2;
                else
                    group.TitleImage = (svr.IsLinked) ? 1 : 0;

                group.Subtitle = string.Format("{0} {1}{2}", svr.ProductVersionName, svr.ProductLevel, ((svr.IsLinked) ? " (Linked)" : string.Empty));
                group.Task = "Server Properties";

                @group.SortValue = svr.IsLinked ? linkedIdx++ : normalIdx++;
            };

            olvColumnDatabaseName.ImageGetter = delegate (object x)
            {
                return ((MySqlDatabase)x).Image;
            };
        }

        private void tstbFilterDatabases_KeyUp(object sender, KeyEventArgs e)
        {
            TextMatchFilter filter = TextMatchFilter.Contains(this.objectListView1, tstbFilterDatabases.Text);
            this.objectListView1.ModelFilter = filter;
        }

        public void RefreshObjects()
        {
            this.objectListView1.Groups.Clear();

            foreach (MySqlServerObject so in _mySqlServer.SqlServerObjects)
            {
                this.objectListView1.Groups.Add(new ListViewGroup(so.ServerObjectName, so.ServerObjectName));
            }

            this.objectListView1.SetObjects(_mySqlServer.SqlDatabases.OrderBy(m => m.DatabaseName));
            this.objectListView1.AutoResizeColumns();

            // Collapse all server groups where server is not valid (version < 2008)
            foreach (OLVGroup t in objectListView1.OLVGroups.Where(g => _mySqlServer.SqlServerObjects.Where(s => !s.IsValid).Select(s => s.ServerObjectName).Contains(g.Key.ToString())))
            {
                t.Collapsed = true;
            }

            // Disable
            objectListView1.DisableObjects(_mySqlServer.SqlDisabledDatabases);
        }

        private void objectListView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dbs = ObjectListView.EnumerableToArray(objectListView1.Objects, false);

            if (_mySqlServer.SqlDisabledDatabases.Contains(((MySqlDatabase)dbs[e.Index])))
                e.NewValue = CheckState.Unchecked;
        }


        //    MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Loading servers and databases... "));

        //    //LongRunningOperationManager.StartNextStep();
        //    //LongRunningOperationManager.ReportProgress(-1);

        //    try
        //    {
        //        DateTime dt = DateTime.Now;
        //        _servers.Clear();
        //        _databases.Clear();

        //        AppSettings.Default.MySqlConnection.ChangeDatabase("master");
        //        SqlCommand cmd = (SqlCommand)AppSettings.Default.MySqlConnection.CreateCommand();
        //        cmd.CommandText = QueryReader.Read("Servers.sql");
        //        cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            _servers.Add(new MySqlServer { Id = (int)rdr["server_id"], Name = (string)rdr["data_source"], IsLinked = (bool)rdr["is_linked"] });
        //        }
        //        rdr.Close();

        //        foreach(MySqlServer mss in _servers)
        //        {
        //            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(AppSettings.Default.MySqlConnection.ConnectionString);
        //            if(mss.Id > 0)
        //                scsb.DataSource = mss.Name;

        //            var m_conn = new MySqlConnection();
        //            m_conn.Connect(scsb.ConnectionString);


        //            cmd = (SqlCommand)m_conn.CreateCommand();
        //            cmd.CommandText = QueryReader.Read("ServerProperties.sql");
        //            cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //            cmd.CommandType = CommandType.Text;
        //            rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                mss.ProductVersionCode = (string)rdr["product_version"];
        //                mss.ProductLevel = (string)rdr["product_level"];
        //                mss.Edition = (string)rdr["edition"];
        //                mss.ProcessId = (int)rdr["process_id"];
        //                mss.EditionID = (int)rdr["edition_id"];
        //                mss.LicenseType = (string)rdr["license_type"];


        //            }
        //            rdr.Close();


        //            cmd = (SqlCommand)m_conn.CreateCommand();
        //            cmd.CommandText = QueryReader.Read("Databases.sql");
        //            cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //            cmd.CommandType = CommandType.Text;
        //            rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                _databases.Add(new MySqlDatabase {
        //                        ServerId = mss.Id,
        //                        ServerName = mss.Name,
        //                        DatabaseId = (int)rdr["database_id"],
        //                        DatabaseName = (string)rdr["name"],
        //                        State = (string)rdr["state_desc"],
        //                        UserHasDbAccess = (bool)rdr["has_db_access"],
        //                        CompatibilityLevel = Convert.ToInt32(rdr["compatibility_level"]),
        //                        CollationName = (string)rdr["collation_name"],
        //                        RecoveryModel = (string)rdr["recovery_model_desc"]
        //                });
        //            }
        //            rdr.Close();
        //        }



        //        /*
        //        string query = QueryReader.Read("ServersAndDatabases.sql");

        //        AppSettings.Default.MySqlConnection.ChangeDatabase("master");
        //        SqlCommand cmd = (SqlCommand)AppSettings.Default.MySqlConnection.CreateCommand();
        //        cmd.CommandText = query;
        //        cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //        cmd.CommandType = CommandType.Text;

        //        SqlDataReader rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            if (!_servers.Select(x => x.Id).Contains((int)rdr["server_id"]))
        //                _servers.Add(new MySqlServer { Id = (int)rdr["server_id"], Name = (string)rdr["data_source"], IsLinked = (bool)rdr["is_linked"], ProductVersionCode = (string)rdr["product_version"], ProductLevel = (string)rdr["product_level"], Edition = (string)rdr["edition"] });

        //            _databases.Add(new MySqlDatabase { ServerId = (int)rdr["server_id"], ServerName = (string)rdr["data_source"], DatabaseId = (int)rdr["database_id"], DatabaseName = (string)rdr["database_name"], State = (string)rdr["database_state_desc"], UserHasDbAccess = (bool)rdr["has_db_access"] });
        //        }
        //        rdr.Close();
        //         * */

        //        DrawDatabases();

        //        MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} databases in {1:n0} servers.", _databases.Count, _servers.Count), (DateTime.Now - dt).TotalSeconds);
        //    }
        //    catch (Exception ex)
        //    {
        //        MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Error, cannot load databases: {0}.", ex.Message));
        //    }
        //}

        private void checkSelectedDatabases(object sender, EventArgs e)
        {
            objectListView1.CheckObjects(objectListView1.SelectedObjects);
        }

        private void uncheckSelectedDatabases(object sender, EventArgs e)
        {
            objectListView1.UncheckObjects(objectListView1.SelectedObjects);
        }

        private void checkAllDatabases(object sender, EventArgs e)
        {
            objectListView1.CheckAll();
        }

        private void uncheckAllDatabases(object sender, EventArgs e)
        {
            objectListView1.UncheckAll();
        }

        private void refreshDatabases(object sender, EventArgs e)
        {
            _mySqlServer.RefreshServers();
            RefreshObjects();
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkSelectedDatabasesToolStripMenuItem.Enabled = (objectListView1.SelectedObjects.Count > 0);
            uncheckSelectedDatabasesToolStripMenuItem.Enabled = (objectListView1.SelectedObjects.Count > 0);

            var db = (MySqlDatabase)objectListView1.SelectedObject;
            ((MainFormMdi)this.ParentForm).PropertiesDockForm.SetObject(db, null, "DatabaseName");
        }

        private void objectListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _mySqlServer.SetCheckedDatabases(objectListView1.CheckedObjects.Cast<MySqlDatabase>().ToArray());

            tsslSelectDatabasesCount.Text = string.Format("{0} database{1} selected", _mySqlServer.CheckedDatabasesCount, (_mySqlServer.CheckedDatabasesCount == 1) ? string.Empty : "s");
        }

        private void objectListView1_GroupTaskClicked(object sender, GroupTaskClickedEventArgs e)
        {
            var svr = _mySqlServer.SqlServerObjects.First(s => s.ServerObjectName.Equals(e.Group.Key.ToString(), StringComparison.InvariantCultureIgnoreCase));
            ((MainFormMdi)this.ParentForm).PropertiesDockForm.SetObject(svr, null, "Name");
            ((MainFormMdi)this.ParentForm).PropertiesDockForm.Show();
        }

        public void CheckDatabases(MySqlDatabase[] dbs)
        {
            foreach (MySqlDatabase db in dbs)
            {
                MySqlDatabase uncheckedDb =
                    _mySqlServer.SqlDatabases.First(
                        d => d.ServerObjectName.Equals(db.ServerObjectName, StringComparison.InvariantCultureIgnoreCase) &&
                             d.DatabaseName.Equals(db.DatabaseName, StringComparison.InvariantCultureIgnoreCase));

                objectListView1.CheckObject(uncheckedDb);
            }
            RefreshObjects();
        }

        private void DatabaseBrowserDockForm_Paint(object sender, PaintEventArgs e)
        {
            bool settingsChanged = false;
            if (objectListView1.AlternateRowBackColor != UserSettings.Default.AlternateRowBackColor)
            {
                objectListView1.AlternateRowBackColor = UserSettings.Default.AlternateRowBackColor;
                settingsChanged = true;
            }

            if (objectListView1.UseAlternatingBackColors != UserSettings.Default.UseAlternatingBackColors)
            {
                objectListView1.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;
                settingsChanged = true;
            }

            if (objectListView1.Objects != null && settingsChanged)
                objectListView1.UpdateObjects(objectListView1.Objects.Cast<MySqlDatabase>().ToList());
        }
    }
}
