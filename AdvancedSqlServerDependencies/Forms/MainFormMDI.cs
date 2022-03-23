using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.DockForms;
using AdvancedSqlServerDependencies.Forms.Options;
using AdvancedSqlServerDependencies.Microsoft.Data.ConnectionUI;
using AdvancedSqlServerDependencies.Progress;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using Microsoft.Data.ConnectionUI;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using AdvancedSqlServerDependencies.CustomOutput;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class MainFormMdi : Form
    {
        // Don't forget to add new dock form into GetContentFromPersistString method!!!
        public DatabaseBrowserDockForm DatabaseBrowserDockForm;
        public PropertiesDockForm PropertiesDockForm;
        //public DependencyBrowserDockForm DependencyBrowserDockForm;
        public OutputDockForm OutputDockForm;
        public ChildrenSummaryDockForm ChildrenSummaryDockForm;
        public DataPreviewDockForm DataPreviewDockForm;
        public ObjectDefinitionDockForm ObjectDefinitionDockForm;
        public StartDockForm StartDockForm;
        public SqlServerPropertiesDockForm SqlServerPropertiesDockForm;
        public TopObjectsDockForm TopObjectsDockForm;

        //private readonly BackgroundWorker _bw;
        //private DependencySearchProgressForm _dependencySearchProgressForm;

        private int _windowId;


        //private EMatchMethod MatchMethod
        //{
        //    get { return (EMatchMethod)Enum.Parse(typeof(EMatchMethod), tscbxObjectNameMatchMethod.Text.Replace(" ", "")); }
        //}

        #region Construct and Destruct
        public MainFormMdi()
        {
            InitializeComponent();

            //_bw = new BackgroundWorker();
            //_bw.WorkerReportsProgress = true;
            //_bw.DoWork += bw_DoWork;
            //_bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //_bw.ProgressChanged += _bw_ProgressChanged;

            this._windowId = 1;
        }

        #endregion

        #region Opening and Closing form
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool layoutLoadedSuccessfully = true;

            //AppSettings.Default.MySqlConnection = new MySqlConnection();
            //AppSettings.Default.MySqlConnection.OnConnectionStateChangedEvent += MySqlConn__OnConnectionStateChangedEvent;
            //AppSettings.Default.MySqlConnection.OnInfoMessage += mySqlConn__OnInfoMessage;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text = string.Format("{0} - {1}", this.Text, fvi.FileVersion);

            // Docking Windows

            this.DatabaseBrowserDockForm = new DatabaseBrowserDockForm(ref mySqlServer1);
            this.SqlServerPropertiesDockForm = new SqlServerPropertiesDockForm(ref mySqlServer1);
            this.PropertiesDockForm = new PropertiesDockForm();
            this.ChildrenSummaryDockForm = new ChildrenSummaryDockForm();
            this.DataPreviewDockForm = new DataPreviewDockForm(ref mySqlServer1);
            this.ObjectDefinitionDockForm = new ObjectDefinitionDockForm(ref mySqlServer1);
            this.OutputDockForm = new OutputDockForm();
            this.TopObjectsDockForm = new TopObjectsDockForm(ref mySqlServer1);


            var mf = this;
            this.StartDockForm = new StartDockForm(ref mf);

            try
            {
                // Load saved layout
                var xml = TempFolder.GetPath("DockPanelLayout", "xml", false);
                DeserializeDockContent ddc = GetContentFromPersistString;
                this.dockPanel.LoadFromXml(xml, ddc);
            }
            catch { layoutLoadedSuccessfully = false; }

            if (!this.dockPanel.Contains(this.DatabaseBrowserDockForm))
                this.DatabaseBrowserDockForm.Show(this.dockPanel, DockState.DockLeft);

            if (!this.dockPanel.Contains(this.SqlServerPropertiesDockForm))
                this.SqlServerPropertiesDockForm.Show(this.dockPanel, DockState.DockRight);

            if (!this.dockPanel.Contains(this.PropertiesDockForm))
                this.PropertiesDockForm.Show(this.dockPanel, DockState.DockRight);

            if (!this.dockPanel.Contains(this.ChildrenSummaryDockForm))
                this.ChildrenSummaryDockForm.Show(this.dockPanel, DockState.DockRight);

            if (!this.dockPanel.Contains(this.DataPreviewDockForm))
                this.DataPreviewDockForm.Show(this.dockPanel, DockState.DockRight);

            if (!this.dockPanel.Contains(this.ObjectDefinitionDockForm))
                this.ObjectDefinitionDockForm.Show(this.dockPanel, DockState.DockBottom);

            if (!this.dockPanel.Contains(this.OutputDockForm))
                this.OutputDockForm.Show(this.dockPanel, DockState.DockBottom);

            if (!this.dockPanel.Contains(this.TopObjectsDockForm))
                this.TopObjectsDockForm.Show(this.dockPanel, DockState.DockBottom);


            this.StartDockForm.Show(this.dockPanel, DockState.Document);

            if (!layoutLoadedSuccessfully)
            {
                PropertiesDockForm.Show();
                OutputDockForm.Show();
            }

            MyOutput.Initialize(ref this.OutputDockForm);
            MyOutput.NewMessage(EOutputMessageType.INFORMATION, "Application started.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySqlServer1.ConnectionPool.RemoveAllConnections();

            TempFolder.CleanTransientFolder();

            var xml = TempFolder.GetPath("DockPanelLayout", "xml", false);
            this.dockPanel.SaveAsXml(xml);
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(DatabaseBrowserDockForm).ToString())
            {
                return this.DatabaseBrowserDockForm;
            }
            else if (persistString == typeof(PropertiesDockForm).ToString())
            {
                return this.PropertiesDockForm;
            }

            else if (persistString == typeof(OutputDockForm).ToString())
            {
                return this.OutputDockForm;
            }

            else if (persistString == typeof(ChildrenSummaryDockForm).ToString())
            {
                return this.ChildrenSummaryDockForm;
            }

            else if (persistString == typeof(DataPreviewDockForm).ToString())
            {
                return this.DataPreviewDockForm;
            }

            else if (persistString == typeof(ObjectDefinitionDockForm).ToString())
            {
                return this.ObjectDefinitionDockForm;
            }

            else if (persistString == typeof(SqlServerPropertiesDockForm).ToString())
            {
                return this.SqlServerPropertiesDockForm;
            }

            return null;
        }

        #endregion

        #region SQL Connection
        /// <summary>
        /// Connection (and reconnection) to the database using Microsoft's native interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void connect(object sender, EventArgs e)
        {
            DataConnectionDialog dcd = new DataConnectionDialog();
            DataConnectionConfiguration dcc = new DataConnectionConfiguration(null);
            dcc.LoadConfiguration(dcd);

            // Initialize connection string from current or previous (saved) connection string
            if (mySqlServer1.ConnectionPool.GetConnection(0) != null && mySqlServer1.ConnectionPool.GetConnection(0).State == ConnectionState.Open)
                dcd.ConnectionString = mySqlServer1.ConnectionPool.GetConnection(0).ConnectionString;
            else if (!string.IsNullOrEmpty(AppSettings.Default.LastConnectionString))
                dcd.ConnectionString = AppSettings.Default.LastConnectionString;

            if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
            {
                AppSettings.Default.LastConnectionString = dcd.ConnectionString;
                AppSettings.Default.Save();
                dcc.SaveConfiguration(dcd);

                var succ = mySqlServer1.RefreshServers(dcd.ConnectionString);

                if(succ)
                    DatabaseBrowserDockForm.RefreshObjects();
            }
        }

     
        /// <summary>
        /// When SQL connections fires error (intentionally)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mySqlConn__OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            //tsslQueryStat.Text = e.Message;
            Application.DoEvents();
        }
        #endregion

        #region Object Browser

        #endregion


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void databasesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.DatabaseBrowserDockForm.Show(dockPanel);
        }

        public void newDependencyCheck(object sender, EventArgs e)
        {
            bool useWizard = sender.ToString().Contains("Wizard");

            if (mySqlServer1.ConnectionPool.GetConnection(0).State == ConnectionState.Open && mySqlServer1.SqlCheckedDatabases.Any())
            {
                NewDependencyCheckForm ndcf = null;
                NewDependencyCheckWizard ndcw = null;

                if (sender.ToString().Contains("Wizard"))
                    ndcw = new NewDependencyCheckWizard(mySqlServer1.SqlCheckedDatabases);
                else
                    ndcf = new NewDependencyCheckForm();

                if ((!useWizard && ndcf.ShowDialog() == DialogResult.OK) || (useWizard && ndcw.ShowDialog() == DialogResult.OK))
                {
                    if (!LongRunningOperationManager.IsBusy)
                    {
                        do
                        {
                            LongRunningOperationManager.NewOperationBatch(true, true, new[] { new LongRunningOperation("Initializing objects and dependencies", 0.45), new LongRunningOperation("Searching for dependencies", 0.45), new LongRunningOperation("Drawing objects", 0.10) });

                            string[] objTypes = (useWizard) ? ndcw.ObjectTypes : null;
                            string objName = (useWizard) ? ndcw.ObjectName : ndcf.ObjectName;
                            bool topDown = (useWizard) ? ndcw.IsTopDownDiscovery : ndcf.IsTopDownDiscovery;
                            EMatchMethod mm = (useWizard) ? ndcw.MatchMethod : EMatchMethod.Contains;
                            bool forceInternalDbReload = (useWizard) ? ndcw.IsForceReload : false;
                            string title = (useWizard) ? ndcw.SearchObjectFullDescription : ndcf.SearchObjectFullDescription;
                            MySqlDatabase[] searchDbs = (useWizard) ? ndcw.SearchDatabases : null;

                            BwObject bwo = new BwObject { CheckedDatabases = mySqlServer1.SqlCheckedDatabases, ObjectTypes = objTypes, ObjectName = objName, IsTopDownDiscovery = topDown, MatchMethod = mm, IsForceReload = forceInternalDbReload, SearchDatabases = searchDbs, SearchObjectFullDescription = title };

                            LongRunningOperationManager.DoWork += lrom_DoWorkViewDependencies;
                            LongRunningOperationManager.WorkCompleted += lrom_ViewDependenciesCompleted;
                            LongRunningOperationManager.RunAsync(bwo);
                        }
                        while (LongRunningOperationManager.ProcessResult != null && ((DependencyBackgroundWorkerResult)LongRunningOperationManager.ProcessResult).ResultType == EResultType.RERUN);
                    }
                    else
                    {
                        MessageBox.Show("Please wait for background process to finish.");
                    }
                }
            }
            else
            {
                if (mySqlServer1.ConnectionPool.GetConnection(0).State != ConnectionState.Open)
                {
                    MessageBox.Show("Please connect to SQL Server and then select at least one database from the list to search for dependencies.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                if (mySqlServer1.ConnectionPool.GetConnection(0).State == ConnectionState.Open && !mySqlServer1.SqlCheckedDatabases.Any())
                {
                    MessageBox.Show("Please select at least one database from the list to search for dependencies.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }


        void lrom_DoWorkViewDependencies(object sender, DoWorkEventArgs e)
        {
            BwObject bwo = (BwObject)e.Argument;

            LongRunningOperationManager.StartNextStep();
            mySqlServer1.Load(bwo.IsForceReload);
            //inMemoryDatabase1.Load(bwo.CheckedDatabases, bwo.IsForceReload);

            //
            if (LongRunningOperationManager.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //
            LongRunningOperationManager.StartNextStep();
            DependencyBrowserDockForm dbdf = new DependencyBrowserDockForm(ref mySqlServer1, bwo.SearchObjectFullDescription, bwo.ObjectTypes, bwo.IsTopDownDiscovery,  this._windowId++);
            dbdf.LoadDependencies(bwo.ObjectName, bwo.ObjectTypes, bwo.IsTopDownDiscovery, bwo.MatchMethod, bwo.IsForceReload, bwo.SearchDatabases);

            //
            if (LongRunningOperationManager.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 
            LongRunningOperationManager.StartNextStep();
            dbdf.DrawObjects();



            if (dbdf.RecommendedDatabases.Count > 0)
            {
                var v1 = dbdf.RecommendedDatabases.Select(d => d.Value.ToString().ToUpper()).ToArray();
                var v2 = mySqlServer1.SqlDatabases.Select(d => d.ToString().ToUpper()).ToArray();
                var v3 = v1.Except(v2);

                if (v3 != null && v3.Any())
                {
                    var v4 = from rd in dbdf.RecommendedDatabases.AsEnumerable()
                             where v3.Contains(rd.Value.ToString().ToUpper())
                             select rd;

                    new InvalidDatabaseReferencesForm(v4.ToArray()).ShowDialog();
                }


                MySqlDatabase[] recommendedDatabasesWithAllAttributesSet =
                    dbdf.RecommendedDatabases.Select(
                        db =>
                            //this.DatabaseBrowserDockForm.AllDatabases.First(
                            mySqlServer1.SqlDatabases.FirstOrDefault(
                                db1 =>
                                    db1.ServerObjectName.Equals(db.Value.ServerObjectName, StringComparison.InvariantCultureIgnoreCase) &&
                                    db1.DatabaseName.Equals(db.Value.DatabaseName, StringComparison.InvariantCultureIgnoreCase)))
                        .Where(db => db != null).ToArray();

                string missingDbs = string.Join(", ", recommendedDatabasesWithAllAttributesSet.Select(db => "[" + db.DatabaseName + "]").Distinct());
                string missingDbsText = string.Format("Results might be incomplete! Include database{0} " + missingDbs + " to get more accurate results.", (recommendedDatabasesWithAllAttributesSet.Length == 1) ? string.Empty : "s");
                dbdf.SetInfo(missingDbsText, Resources.StatusAnnotations_Warning_16xLG_color);

                var f = new RecommendedDatabasesForm(recommendedDatabasesWithAllAttributesSet);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    
                    e.Result = new DependencyBackgroundWorkerResult { ResultType = EResultType.RERUN, ResultObject = f.CheckedRecommendedDatabases };
                }
                else
                {
                    e.Result = new DependencyBackgroundWorkerResult { ResultType = EResultType.SHOW_RESULTS, ResultObject = dbdf };
                }
            }
            else
                e.Result = new DependencyBackgroundWorkerResult { ResultType = EResultType.SHOW_RESULTS, ResultObject = dbdf };
        }



        void lrom_ViewDependenciesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result.GetType().IsAssignableFrom(typeof(DependencyBackgroundWorkerResult)))
            {
                var res = ((DependencyBackgroundWorkerResult)e.Result);

                if (res.ResultType == EResultType.SHOW_RESULTS)
                {
                    var d = ((DependencyBrowserDockForm)res.ResultObject);
                    if (d.AreDependenciesInitialized)
                    {
                        d.Show(this.dockPanel, DockState.Document);
                        d.AutoResizeColumns();
                    }
                }
                else if (res.ResultType == EResultType.RERUN)
                {
                    MySqlDatabase[] checkedRecommendedDatabases = new MySqlDatabase[((List<MySqlDatabase>)res.ResultObject).Count];
                    ((List<MySqlDatabase>)res.ResultObject).CopyTo(checkedRecommendedDatabases);

                    this.DatabaseBrowserDockForm.CheckDatabases(checkedRecommendedDatabases.Select(db => mySqlServer1.SqlDatabases.First(db1 => db1.ServerObjectName.Equals(db.ServerObjectName, StringComparison.InvariantCultureIgnoreCase) && db1.DatabaseName.Equals(db.DatabaseName, StringComparison.InvariantCultureIgnoreCase))).ToArray());
                }
            }

            /*
            if (d.RecommendedDatabases.Count > 0)
            {
                var recommendedDatabasesCleaned =
                    d.RecommendedDatabases.Select(
                        db =>
                            this.DatabaseBrowserDockForm.AllDatabases.First(
                                db1 =>
                                    db1.ServerName.Equals(db.ServerName, StringComparison.InvariantCultureIgnoreCase) &&
                                    db1.DatabaseName.Equals(db.DatabaseName, StringComparison.InvariantCultureIgnoreCase)))
                        .ToArray();

                string missingDbs = string.Join(", ", recommendedDatabasesCleaned.Select(db => "[" + db.DatabaseName + "]").Distinct());
                string missingDbsText = string.Format("Results might be incomplete! Include database{0} " + missingDbs + " to get more accurate results.", (recommendedDatabasesCleaned.Length == 1) ? string.Empty : "s");
                d.SetInfo(missingDbsText, Resources.StatusAnnotations_Warning_16xLG_color);

                var f = new RecommendedDatabasesForm(recommendedDatabasesCleaned);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.DatabaseBrowserDockForm.CheckDatabases(f.CheckedRecommendedDatabases.Select(db => this.DatabaseBrowserDockForm.AllDatabases.First(db1 => db1.ServerName.Equals(db.ServerName, StringComparison.InvariantCultureIgnoreCase) && db1.DatabaseName.Equals(db.DatabaseName, StringComparison.InvariantCultureIgnoreCase))).ToArray());

                    d.Close();
                    //newDependencyCheck(sender, e);
                }
            }
             * */
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PropertiesDockForm.Show(dockPanel);
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OutputDockForm.Show(dockPanel);
        }

        private void childrenSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChildrenSummaryDockForm.Show(dockPanel);
        }

        private void dataPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataPreviewDockForm.Show(dockPanel);
        }

        private void objectDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ObjectDefinitionDockForm.Show(dockPanel);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var of = new OptionsForm();
            if (of.ShowDialog() == DialogResult.OK)
            {
                foreach (IDockContent content in this.dockPanel.Contents)
                {
                    content.DockHandler.Form.Invalidate();
                }
            }
        }

        private void MainFormMdi_Resize(object sender, EventArgs e)
        {
            //int w = 0;
            //foreach (ToolStripItem control in ssMain.Items)
            //{
            //    if (!control.Name.Equals("tsslDummy"))
            //    {
            //        w += control.Width;
            //    }
            //}

            //tsslDummy.Width = this.Width - w - 35;
        }

        private void MainFormMdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Rate
            //if (Properties.AppSettings.Default.ApplicationRated != -1)
            //{
            //    var rw = new RateAppForm();
            //    rw.ShowDialog();
            //}
        }

        private void visitProjectWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/knyazs/Advanced-SQL-Server-Dependencies");
        }

        private void mySqlServer1_OnMainConnectionChangedEvent(object sender, SqlServer.MainConnectionChangedEventArgs e)
        {
            var conn = mySqlServer1.ConnectionPool.GetConnection(0);
            tsslDataSource.Text = conn.DataSource;
            tsslConnectionState.Image = (conn.State == ConnectionState.Open) ? Resources.DataConnection_Connected_1061 : Resources.DataConnection_NotConnected_1059;
        
            //tsslInMemoryDbStat.Text = string.Format("{0:n0} objects, {1:n0} dependencies (last refreshed on {2})", e.ObjectCount, e.DependencyCount, DateTime.Now);
            this.SqlServerPropertiesDockForm.RefreshInfo();

            //this.InMemoryDbPropertiesDockForm.textBoxObjectCount.Text = e.ObjectCount.ToString();
            //this.InMemoryDbPropertiesDockForm.numericUpDown1.Value = e.ObjectCount;

        }

        private void mySqlServer1_OnDataChanged(object sender, DataChangedEventArgs e)
        {
            this.SqlServerPropertiesDockForm.RefreshInfo();
            this.TopObjectsDockForm.RefreshInfo();
        }

        private void mySqlServer1_OnCheckedDatabasesChanged(object sender, EventArgs e)
        {
            this.SqlServerPropertiesDockForm.RefreshInfo();
        }

        private void cacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SqlServerPropertiesDockForm.Show(dockPanel);
        }
    }

    class BwObject
    {
        public MySqlDatabase[] CheckedDatabases;
        public string ObjectName;
        public string[] ObjectTypes;
        public bool IsTopDownDiscovery;
        public EMatchMethod MatchMethod;
        public bool IsForceReload;
        public MySqlDatabase[] SearchDatabases;
        public string SearchObjectFullDescription;
    }
}
