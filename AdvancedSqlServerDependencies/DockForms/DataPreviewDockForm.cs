using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.Progress;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using BrightIdeasSoftware;
using WeifenLuo.WinFormsUI.Docking;
using AdvancedSqlServerDependencies.CustomOutput;
using AdvancedSqlServerDependencies.SqlServer;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class DataPreviewDockForm : DockContent
    {
        private MySqlServer _mySqlServer;
        private MySqlObject _mySqlObject;
        private SqlCommand cmd;

        public DataPreviewDockForm(ref MySqlServer mySqlServer)
        {
            InitializeComponent();

            _mySqlServer = mySqlServer;

            this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            this.Enabled = false;
        }

        public void SetObject(MySqlObject mySqlObject)
        {
            this.Enabled = mySqlObject != null;

            if (mySqlObject != null)
            {
                this._mySqlObject = mySqlObject;
                richTextBox1.Rtf = mySqlObject.Rtf;

                tsbOpenInSSMS.Enabled = tsbShowInThisWindow.Enabled = (mySqlObject.ObjectType == "USER_TABLE" || mySqlObject.ObjectType == "VIEW");
            }
            else
            {
                this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            }

            objectListView1.ClearObjects();
            objectListView1.Columns.Clear();
        }

        private void tsbShowInThisWindow_Click(object sender, EventArgs e)
        {
            LongRunningOperationManager.NewOperationBatch(true, true, new[] { new LongRunningOperation("Executing query") });
            LongRunningOperationManager.DoWork += LongRunningOperationManager_DoWorkExecQuery;
            LongRunningOperationManager.WorkCompleted += LongRunningOperationManager_ExecQueryCompleted;
            LongRunningOperationManager.WorkerPreCancel += LongRunningOperationManager_WorkerPreCancel;
            LongRunningOperationManager.RunAsync();            
        }

        private void LongRunningOperationManager_DoWorkExecQuery(object sender, DoWorkEventArgs e)
        {
            LongRunningOperationManager.StartNextStep();
            LongRunningOperationManager.ReportProgress(-1);

            MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Reading data from {0}... ", this._mySqlObject.ObjectNameFull));

            DateTime dt = DateTime.Now;

            string query = string.Format("SELECT TOP 1000 * FROM [{0}].[{1}] WITH (NOLOCK)", _mySqlObject.SchemaName, _mySqlObject.ObjectName);

            _mySqlServer.ConnectionPool.GetConnection(_mySqlObject.ServerObjectId).ChangeDatabase(_mySqlObject.DatabaseName);
            cmd = (SqlCommand)_mySqlServer.ConnectionPool.GetConnection(_mySqlObject.ServerObjectId).CreateCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = null;
            try
            {
                rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            }
            catch(Exception ex1)
            {
                if (!LongRunningOperationManager.CancellationPending)
                {
                    MyOutput.AppendToLastMessage(EOutputMessageType.ERROR, string.Format("{0}", ex1.Message));
                    MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MyOutput.AppendToLastMessage(EOutputMessageType.WARNING, string.Format("Done. Cancelled by user."), (DateTime.Now - dt).TotalSeconds);
                }
            }

            if (rdr == null)
            {
                e.Cancel = true;
                return;
            }

            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            rdr.Close();

            // Get all byte columns
            List<DataColumn> byteColumns = dataTable.Columns.Cast<DataColumn>().Where(dc => dc.DataType == typeof(byte[])).ToList();

            foreach (DataColumn dc in byteColumns)
            {
                int colOrdinal = dc.Ordinal;
                string colName = String.Format("{0} (Hex)", dc.ColumnName);

                DataColumn tmpCol = new DataColumn(colName, typeof(String));
                dataTable.Columns.Add(tmpCol);
                foreach (DataRow row in dataTable.Rows)
                    row[tmpCol] = byteArrayToHexString((byte[])row[dc]);
                dataTable.Columns.Remove(dc);
                dataTable.Columns[colName].SetOrdinal(colOrdinal);
            }

            e.Result = dataTable;

            MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0} rows.", dataTable.Rows.Count), (DateTime.Now - dt).TotalSeconds);
        }

        private void LongRunningOperationManager_ExecQueryCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                return;

            DataTable dataTable = (DataTable) e.Result;

            objectListView1.Columns.Clear();
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                var olvColumn = new OLVColumn(dataColumn.ColumnName, dataColumn.ColumnName);
                objectListView1.Columns.AddRange(new ColumnHeader[] { olvColumn });
            }
            objectListView1.Objects = dataTable.Rows;
            objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        void LongRunningOperationManager_WorkerPreCancel()
        {
            if(cmd != null)
                cmd.Cancel();
        }

        private string byteArrayToHexString(byte[] p)
        {
            byte b;
            char[] c = new char[p.Length * 2 + 2];
            c[0] = '0'; c[1] = 'x';
            for (int y = 0, x = 2; y < p.Length; ++y, ++x)
            {
                b = ((byte)(p[y] >> 4));
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(p[y] & 0xF));
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }


        private void tsbOpenInSSMS_Click(object sender, EventArgs e)
        {
            string queryPath = TempFolder.GetPath(null, "sql", true);

            File.WriteAllText(queryPath, string.Format("SELECT TOP 1000 * FROM {0} WITH (NOLOCK)", _mySqlObject.ObjectNameFull));

            if (Process.GetProcessesByName("ssms").Length == 0)
            {
                string arguments = string.Concat(" -S ", _mySqlObject.ServerObjectName, "-d ", _mySqlObject.DatabaseName, " '", queryPath, "'");
                Process.Start(new ProcessStartInfo { FileName = "ssms.exe", Arguments = arguments });
            }
            else
            {
                string str = string.Concat(" -S ", _mySqlObject.ServerObjectName, " -d ", _mySqlObject.DatabaseName);
                Process.Start(queryPath, str);
            }
        }

        private void DataPreviewDockForm_Paint(object sender, PaintEventArgs e)
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
                objectListView1.UpdateObjects(objectListView1.Objects.Cast<object>().ToList());
        }
    }
}
