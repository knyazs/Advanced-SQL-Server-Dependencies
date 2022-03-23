using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace AdvancedSqlServerDependencies.Forms
{
    partial class MainFormMdi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormMdi));
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDataSource = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbConnectToServer = new System.Windows.Forms.ToolStripButton();
            this.tssbQuickDependencyCheck = new System.Windows.Forms.ToolStripSplitButton();
            this.startSearchWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonWebsite = new System.Windows.Forms.ToolStripButton();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dependencyCheckWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childrenSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databasesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitProjectWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySqlServer1 = new AdvancedSqlServerDependencies.SqlServer.MySqlServer(this.components);
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Location = new System.Drawing.Point(0, 49);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(784, 488);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 2;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectionState,
            this.tsslDataSource});
            this.ssMain.Location = new System.Drawing.Point(0, 537);
            this.ssMain.Name = "ssMain";
            this.ssMain.ShowItemToolTips = true;
            this.ssMain.Size = new System.Drawing.Size(784, 25);
            this.ssMain.TabIndex = 0;
            this.ssMain.Text = "statusStrip1";
            // 
            // tsslConnectionState
            // 
            this.tsslConnectionState.Image = global::AdvancedSqlServerDependencies.Properties.Resources.DataConnection_NotConnected_1059;
            this.tsslConnectionState.Name = "tsslConnectionState";
            this.tsslConnectionState.Size = new System.Drawing.Size(16, 20);
            this.tsslConnectionState.ToolTipText = "Connection state";
            // 
            // tsslDataSource
            // 
            this.tsslDataSource.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslDataSource.Image = global::AdvancedSqlServerDependencies.Properties.Resources.DatabaseServer;
            this.tsslDataSource.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tsslDataSource.Name = "tsslDataSource";
            this.tsslDataSource.Size = new System.Drawing.Size(122, 20);
            this.tsslDataSource.Text = "Server unavailable";
            this.tsslDataSource.ToolTipText = "Database server name";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnectToServer,
            this.tssbQuickDependencyCheck,
            this.toolStripSeparator2,
            this.toolStripButtonWebsite});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(784, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbConnectToServer
            // 
            this.tsbConnectToServer.Image = global::AdvancedSqlServerDependencies.Properties.Resources.AddConnection_477_32;
            this.tsbConnectToServer.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbConnectToServer.Name = "tsbConnectToServer";
            this.tsbConnectToServer.Size = new System.Drawing.Size(72, 22);
            this.tsbConnectToServer.Text = "Connect";
            this.tsbConnectToServer.Click += new System.EventHandler(this.connect);
            // 
            // tssbQuickDependencyCheck
            // 
            this.tssbQuickDependencyCheck.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSearchWizardToolStripMenuItem});
            this.tssbQuickDependencyCheck.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Relation_8467_24;
            this.tssbQuickDependencyCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbQuickDependencyCheck.Name = "tssbQuickDependencyCheck";
            this.tssbQuickDependencyCheck.Size = new System.Drawing.Size(175, 22);
            this.tssbQuickDependencyCheck.Text = "Quick Dependency Check";
            this.tssbQuickDependencyCheck.ButtonClick += new System.EventHandler(this.newDependencyCheck);
            // 
            // startSearchWizardToolStripMenuItem
            // 
            this.startSearchWizardToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.wizard;
            this.startSearchWizardToolStripMenuItem.Name = "startSearchWizardToolStripMenuItem";
            this.startSearchWizardToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.startSearchWizardToolStripMenuItem.Text = "Dependency Check Wizard";
            this.startSearchWizardToolStripMenuItem.Click += new System.EventHandler(this.newDependencyCheck);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonWebsite
            // 
            this.toolStripButtonWebsite.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Web;
            this.toolStripButtonWebsite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWebsite.Name = "toolStripButtonWebsite";
            this.toolStripButtonWebsite.Size = new System.Drawing.Size(69, 22);
            this.toolStripButtonWebsite.Text = "Website";
            this.toolStripButtonWebsite.Click += new System.EventHandler(this.visitProjectWebsiteToolStripMenuItem_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(784, 24);
            this.msMain.TabIndex = 13;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToServerToolStripMenuItem,
            this.newToolStripMenuItem,
            this.dependencyCheckWizardToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "&FILE";
            // 
            // connectToServerToolStripMenuItem
            // 
            this.connectToServerToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.AddConnection_477_32;
            this.connectToServerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.connectToServerToolStripMenuItem.Name = "connectToServerToolStripMenuItem";
            this.connectToServerToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.connectToServerToolStripMenuItem.Text = "&Connect";
            this.connectToServerToolStripMenuItem.Click += new System.EventHandler(this.connect);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Relation_8467_24;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.newToolStripMenuItem.Text = "&Quick Dependency Check";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newDependencyCheck);
            // 
            // dependencyCheckWizardToolStripMenuItem
            // 
            this.dependencyCheckWizardToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.wizard;
            this.dependencyCheckWizardToolStripMenuItem.Name = "dependencyCheckWizardToolStripMenuItem";
            this.dependencyCheckWizardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.dependencyCheckWizardToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.dependencyCheckWizardToolStripMenuItem.Text = "Dependency Check &Wizard";
            this.dependencyCheckWizardToolStripMenuItem.Click += new System.EventHandler(this.newDependencyCheck);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(257, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childrenSummaryToolStripMenuItem,
            this.databasesToolStripMenuItem1,
            this.dataPreviewToolStripMenuItem,
            this.objectDefinitionToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.cacheToolStripMenuItem,
            this.topObjectsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.viewToolStripMenuItem.Text = "&VIEW";
            // 
            // childrenSummaryToolStripMenuItem
            // 
            this.childrenSummaryToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.stock_sum1;
            this.childrenSummaryToolStripMenuItem.Name = "childrenSummaryToolStripMenuItem";
            this.childrenSummaryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.childrenSummaryToolStripMenuItem.Text = "Children &Summary";
            this.childrenSummaryToolStripMenuItem.Click += new System.EventHandler(this.childrenSummaryToolStripMenuItem_Click);
            // 
            // databasesToolStripMenuItem1
            // 
            this.databasesToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.database;
            this.databasesToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.databasesToolStripMenuItem1.Name = "databasesToolStripMenuItem1";
            this.databasesToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.databasesToolStripMenuItem1.Text = "&Databases";
            this.databasesToolStripMenuItem1.Click += new System.EventHandler(this.databasesToolStripMenuItem1_Click);
            // 
            // dataPreviewToolStripMenuItem
            // 
            this.dataPreviewToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.search2;
            this.dataPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dataPreviewToolStripMenuItem.Name = "dataPreviewToolStripMenuItem";
            this.dataPreviewToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dataPreviewToolStripMenuItem.Text = "&Data Preview";
            this.dataPreviewToolStripMenuItem.Click += new System.EventHandler(this.dataPreviewToolStripMenuItem_Click);
            // 
            // objectDefinitionToolStripMenuItem
            // 
            this.objectDefinitionToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.script;
            this.objectDefinitionToolStripMenuItem.Name = "objectDefinitionToolStripMenuItem";
            this.objectDefinitionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.objectDefinitionToolStripMenuItem.Text = "Object De&finition";
            this.objectDefinitionToolStripMenuItem.Click += new System.EventHandler(this.objectDefinitionToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.sign_out;
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.outputToolStripMenuItem.Text = "&Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.property1;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.propertiesToolStripMenuItem.Text = "&Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // cacheToolStripMenuItem
            // 
            this.cacheToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.ram_or_hardware1;
            this.cacheToolStripMenuItem.Name = "cacheToolStripMenuItem";
            this.cacheToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cacheToolStripMenuItem.Text = "Cache";
            this.cacheToolStripMenuItem.Click += new System.EventHandler(this.cacheToolStripMenuItem_Click);
            // 
            // topObjectsToolStripMenuItem
            // 
            this.topObjectsToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.knewstuff;
            this.topObjectsToolStripMenuItem.Name = "topObjectsToolStripMenuItem";
            this.topObjectsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.topObjectsToolStripMenuItem.Text = "&Top Objects";
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.tOOLSToolStripMenuItem.Text = "&TOOLS";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.visitProjectWebsiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "&HELP";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // visitProjectWebsiteToolStripMenuItem
            // 
            this.visitProjectWebsiteToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Web;
            this.visitProjectWebsiteToolStripMenuItem.Name = "visitProjectWebsiteToolStripMenuItem";
            this.visitProjectWebsiteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.visitProjectWebsiteToolStripMenuItem.Text = "Visit Project Website";
            this.visitProjectWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitProjectWebsiteToolStripMenuItem_Click);
            // 
            // mySqlServer1
            // 
            this.mySqlServer1.OnMainConnectionChangedEvent += new AdvancedSqlServerDependencies.SqlServer.MySqlServer.MainConnectionChangedEventHandler(this.mySqlServer1_OnMainConnectionChangedEvent);
            this.mySqlServer1.OnDataChanged += new AdvancedSqlServerDependencies.SqlServer.MySqlServer.DataChangedEventHandler(this.mySqlServer1_OnDataChanged);
            this.mySqlServer1.OnCheckedDatabasesChanged += new AdvancedSqlServerDependencies.SqlServer.MySqlServer.CheckedDatabasesChangedEventHandler(this.mySqlServer1_OnCheckedDatabasesChanged);
            // 
            // MainFormMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainFormMdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced SQL Server Dependencies";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormMdi_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainFormMdi_Resize);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip ssMain;
        private ToolStrip tsMain;
        private ToolStripStatusLabel tsslConnectionState;
        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem connectToServerToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripButton tsbConnectToServer;
        private ToolStripStatusLabel tsslDataSource;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private DockPanel dockPanel;
        private ToolStripMenuItem databasesToolStripMenuItem1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem outputToolStripMenuItem;
        private ToolStripMenuItem childrenSummaryToolStripMenuItem;
        private ToolStripMenuItem dataPreviewToolStripMenuItem;
        private ToolStripMenuItem objectDefinitionToolStripMenuItem;
        private ToolStripMenuItem tOOLSToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonWebsite;
        private ToolStripMenuItem visitProjectWebsiteToolStripMenuItem;
        private ToolStripSplitButton tssbQuickDependencyCheck;
        private ToolStripMenuItem startSearchWizardToolStripMenuItem;
        private ToolStripMenuItem dependencyCheckWizardToolStripMenuItem;
        private SqlServer.MySqlServer mySqlServer1;
        private ToolStripMenuItem cacheToolStripMenuItem;
        private ToolStripMenuItem topObjectsToolStripMenuItem;
    }
}