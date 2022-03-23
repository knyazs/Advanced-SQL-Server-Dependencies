using AdvancedSqlServerDependencies.CustomOutput;
using AdvancedSqlServerDependencies.Progress;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdvancedSqlServerDependencies.SqlServer
{
    public class ConnectionPool
    {
        //private SqlConnection _conn;
        private Dictionary<int, SqlConnection> _pool; //ServerObjectId, SqlConnection
        private List<int> _confirmedServerObjectIds;


        public int[] ServerObjectIds
        {
            get
            {
                return _pool.Select(x => x.Key).ToArray();
            }
        }

        public int[] ConfirmedServerObjectIds
        {
            get
            {
                return _confirmedServerObjectIds.ToArray();
            }
        }

        public ConnectionPool()
        {
            _pool = new Dictionary<int, SqlConnection>();
            _confirmedServerObjectIds = new List<int>();
        }

        //internal SqlConnection DefaultConnection
        //{
        //    get
        //    {
        //        return GetConnection(0);
        //    }
        //}

        internal void AddConnection(string connectionString, int serverObjectId)
        {
            //TODO - Add necessary events for each connection
            var conn = new SqlConnection(connectionString);
            _pool.Add(serverObjectId, conn);
        }

        internal void Connect(int[] serverObjectIds)
        {
            SqlConnectionStringBuilder scsb;

            _confirmedServerObjectIds.Clear();
            LongRunningOperationManager.NewOperationBatch(true, false, new[]{ new LongRunningOperation(string.Format("Connecting to all server objects...")) });

            if (!LongRunningOperationManager.IsBusy)
            {
                foreach(int serverObjectId in serverObjectIds)
                {
                    scsb = new SqlConnectionStringBuilder(_pool[serverObjectId].ConnectionString);
                    //lro.Add(new LongRunningOperation(string.Format("Connecting to '{0}'", scsb.DataSource), 1.0 / serverObjectIds.Length));
                }

                LongRunningOperationManager.DoWork += lrom_DoWorkConnectToSqlServer;
                LongRunningOperationManager.RunAsync(_pool);
                
            }

            _confirmedServerObjectIds.AddRange((int[])LongRunningOperationManager.ProcessResult);

            /*
            if (LongRunningOperationManager.ProcessResult == null)
            {
                _unconfirmedConnections.Remove(serverObjectId);
                MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Cannot establish connection to '{0}'", scsb.DataSource), true);
                return false;
            }
            else
            {
                _confirmedConnections.Add(serverObjectId, _unconfirmedConnections[serverObjectId]);
                MyOutput.NewMessage(EOutputMessageType.ERROR, string.Format("Connected to '{0}'", scsb.DataSource), true);
                return true;
            }*/
        }

        private void lrom_DoWorkConnectToSqlServer(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dictionary<int, SqlConnection> pool = (Dictionary<int, SqlConnection>)e.Argument;
            List<int> succServerObjects = new List<int>();
            int counter = 0;

            LongRunningOperationManager.StartNextStep();
            
            foreach (var c in pool)
            {
                counter++;

                LongRunningOperationManager.ReportProgress(counter / pool.Count);
                SqlConnection conn = c.Value;


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    succServerObjects.Add(c.Key);
                }
                else
                {
                    try
                    {
                        conn.Open();
                        succServerObjects.Add(c.Key);
                    }
                    catch (Exception ex)
                    {
                        MyOutput.NewMessage(EOutputMessageType.ERROR, ex.Message, true);
                    }
                }
            }

            e.Result = succServerObjects.ToArray();
        }

        //private void lrom_ConnectToSqlServerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Result != null)
        //        _conn = (SqlConnection)e.Result;
        //    else
        //        _conn = null;
        //}



        /// <summary>
        /// Removes all connections
        /// </summary>
        /// <returns></returns>
        internal int RemoveAllConnections()
        {
            int connCount = _pool.Count;

            while (_pool.Count > 0)
            {
                RemoveConnection(_pool.ElementAt(0).Key);
            }

            return connCount;
        }

        /// <summary>
        /// Removes connection for specific ServerObject
        /// </summary>
        /// <param name="serverObjectId"></param>
        internal void RemoveConnection(int serverObjectId)
        {
            if (_pool != null && _pool.ContainsKey(serverObjectId) && ((SqlConnection)_pool[serverObjectId]) != null && ((SqlConnection)_pool[serverObjectId]).State == System.Data.ConnectionState.Open)
                ((SqlConnection)_pool[serverObjectId]).Close();

            _pool.Remove(serverObjectId);
        }

        /// <summary>
        /// Gets a connection for specific ServerObject
        /// </summary>
        /// <param name="serverObjectId"></param>
        /// <returns></returns>
        internal SqlConnection GetConnection(int serverObjectId)
        {
            if (!_confirmedServerObjectIds.Contains(serverObjectId))
                return null;

            //Connect(new[] { serverObjectId });

            return _pool != null && _pool.ContainsKey(serverObjectId) && _pool[serverObjectId] != null ? _pool[serverObjectId] : null;
        }


    }
}
