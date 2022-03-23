using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class DatabaseBrowserDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseBrowserDockForm));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnDatabaseName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDatabaseState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnNote = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctxDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkSelectedDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckSelectedDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllDatabasesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListGroup = new System.Windows.Forms.ImageList(this.components);
            this.toolStripDatabaseSelector = new System.Windows.Forms.ToolStrip();
            this.tslFilterDb = new System.Windows.Forms.ToolStripLabel();
            this.tstbFilterDatabases = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefreshDatabases = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslSelectDatabasesCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.ctxDatabase.SuspendLayout();
            this.toolStripDatabaseSelector.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumnDatabaseName);
            this.objectListView1.AllColumns.Add(this.olvColumnDatabaseState);
            this.objectListView1.AllColumns.Add(this.olvColumnNote);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.CheckBoxes = true;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDatabaseName,
            this.olvColumnDatabaseState,
            this.olvColumnNote});
            this.objectListView1.ContextMenuStrip = this.ctxDatabase;
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.GroupImageList = this.imageListGroup;
            this.objectListView1.SelectedBackColor = System.Drawing.Color.Empty;
            this.objectListView1.SelectedForeColor = System.Drawing.Color.Empty;
            this.objectListView1.Location = new System.Drawing.Point(0, 25);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowItemCountOnGroups = true;
            this.objectListView1.Size = new System.Drawing.Size(309, 362);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 15;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.UseHotItem = true;
            this.objectListView1.UseTranslucentHotItem = true;
            this.objectListView1.UseTranslucentSelection = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.GroupTaskClicked += new System.EventHandler<BrightIdeasSoftware.GroupTaskClickedEventArgs>(this.objectListView1_GroupTaskClicked);
            this.objectListView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.objectListView1_ItemCheck);
            this.objectListView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListView1_ItemChecked);
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // olvColumnDatabaseName
            // 
            this.olvColumnDatabaseName.AspectName = "DatabaseName";
            this.olvColumnDatabaseName.HeaderCheckBox = true;
            this.olvColumnDatabaseName.ImageAspectName = "Image";
            this.olvColumnDatabaseName.Text = "Database";
            this.olvColumnDatabaseName.Width = 132;
            // 
            // olvColumnDatabaseState
            // 
            this.olvColumnDatabaseState.AspectName = "State";
            this.olvColumnDatabaseState.Searchable = false;
            this.olvColumnDatabaseState.Text = "State";
            // 
            // olvColumnNote
            // 
            this.olvColumnNote.AspectName = "Note";
            this.olvColumnNote.Text = "Note";
            this.olvColumnNote.Width = 70;
            // 
            // ctxDatabase
            // 
            this.ctxDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkSelectedDatabasesToolStripMenuItem,
            this.checkAllDatabasesToolStripMenuItem,
            this.uncheckSelectedDatabasesToolStripMenuItem,
            this.uncheckAllDatabasesToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.refreshDatabasesToolStripMenuItem});
            this.ctxDatabase.Name = "contextMenuStrip2";
            this.ctxDatabase.Size = new System.Drawing.Size(168, 120);
            // 
            // checkSelectedDatabasesToolStripMenuItem
            // 
            this.checkSelectedDatabasesToolStripMenuItem.Enabled = false;
            this.checkSelectedDatabasesToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.CheckBoxChecked_669_24;
            this.checkSelectedDatabasesToolStripMenuItem.Name = "checkSelectedDatabasesToolStripMenuItem";
            this.checkSelectedDatabasesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.checkSelectedDatabasesToolStripMenuItem.Text = "Check Selected";
            this.checkSelectedDatabasesToolStripMenuItem.Click += new System.EventHandler(this.checkSelectedDatabases);
            // 
            // checkAllDatabasesToolStripMenuItem
            // 
            this.checkAllDatabasesToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.CheckBoxListChecked_727_24;
            this.checkAllDatabasesToolStripMenuItem.Name = "checkAllDatabasesToolStripMenuItem";
            this.checkAllDatabasesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.checkAllDatabasesToolStripMenuItem.Text = "Check All";
            this.checkAllDatabasesToolStripMenuItem.Click += new System.EventHandler(this.checkAllDatabases);
            // 
            // uncheckSelectedDatabasesToolStripMenuItem
            // 
            this.uncheckSelectedDatabasesToolStripMenuItem.Enabled = false;
            this.uncheckSelectedDatabasesToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.CheckBoxUnchecked_669_24;
            this.uncheckSelectedDatabasesToolStripMenuItem.Name = "uncheckSelectedDatabasesToolStripMenuItem";
            this.uncheckSelectedDatabasesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.uncheckSelectedDatabasesToolStripMenuItem.Text = "Uncheck Selected";
            this.uncheckSelectedDatabasesToolStripMenuItem.Click += new System.EventHandler(this.uncheckSelectedDatabases);
            // 
            // uncheckAllDatabasesToolStripMenuItem1
            // 
            this.uncheckAllDatabasesToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.CheckBoxListUnchecked_727_24;
            this.uncheckAllDatabasesToolStripMenuItem1.Name = "uncheckAllDatabasesToolStripMenuItem1";
            this.uncheckAllDatabasesToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.uncheckAllDatabasesToolStripMenuItem1.Text = "Uncheck All";
            this.uncheckAllDatabasesToolStripMenuItem1.Click += new System.EventHandler(this.uncheckAllDatabases);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(164, 6);
            // 
            // refreshDatabasesToolStripMenuItem
            // 
            this.refreshDatabasesToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Refresh;
            this.refreshDatabasesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.refreshDatabasesToolStripMenuItem.Name = "refreshDatabasesToolStripMenuItem";
            this.refreshDatabasesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.refreshDatabasesToolStripMenuItem.Text = "Refresh";
            this.refreshDatabasesToolStripMenuItem.Click += new System.EventHandler(this.refreshDatabases);
            // 
            // imageListGroup
            // 
            this.imageListGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListGroup.ImageStream")));
            this.imageListGroup.TransparentColor = System.Drawing.Color.Magenta;
            this.imageListGroup.Images.SetKeyName(0, "SqlServer.png");
            this.imageListGroup.Images.SetKeyName(1, "SqlServerLinked.png");
            this.imageListGroup.Images.SetKeyName(2, "StatusAnnotations_Warning_16xLG_color.png");
            // 
            // toolStripDatabaseSelector
            // 
            this.toolStripDatabaseSelector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslFilterDb,
            this.tstbFilterDatabases,
            this.toolStripSeparator2,
            this.tsbRefreshDatabases});
            this.toolStripDatabaseSelector.Location = new System.Drawing.Point(0, 0);
            this.toolStripDatabaseSelector.Name = "toolStripDatabaseSelector";
            this.toolStripDatabaseSelector.Size = new System.Drawing.Size(309, 25);
            this.toolStripDatabaseSelector.TabIndex = 16;
            this.toolStripDatabaseSelector.Text = "toolStrip2";
            // 
            // tslFilterDb
            // 
            this.tslFilterDb.Name = "tslFilterDb";
            this.tslFilterDb.Size = new System.Drawing.Size(91, 22);
            this.tslFilterDb.Text = "Filter databases:";
            // 
            // tstbFilterDatabases
            // 
            this.tstbFilterDatabases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbFilterDatabases.Name = "tstbFilterDatabases";
            this.tstbFilterDatabases.Size = new System.Drawing.Size(100, 25);
            this.tstbFilterDatabases.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstbFilterDatabases_KeyUp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefreshDatabases
            // 
            this.tsbRefreshDatabases.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshDatabases.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Refresh;
            this.tsbRefreshDatabases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshDatabases.Name = "tsbRefreshDatabases";
            this.tsbRefreshDatabases.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshDatabases.Text = "Refresh databases";
            this.tsbRefreshDatabases.Click += new System.EventHandler(this.refreshDatabases);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSelectDatabasesCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(309, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslSelectDatabasesCount
            // 
            this.tsslSelectDatabasesCount.Image = global::AdvancedSqlServerDependencies.Properties.Resources.database;
            this.tsslSelectDatabasesCount.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tsslSelectDatabasesCount.Name = "tsslSelectDatabasesCount";
            this.tsslSelectDatabasesCount.Size = new System.Drawing.Size(130, 17);
            this.tsslSelectDatabasesCount.Text = "0 databases selected";
            this.tsslSelectDatabasesCount.ToolTipText = "Number of checked databases";
            // 
            // DatabaseBrowserDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 409);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripDatabaseSelector);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseBrowserDockForm";
            this.Text = "Database Browser";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DatabaseBrowserDockForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ctxDatabase.ResumeLayout(false);
            this.toolStripDatabaseSelector.ResumeLayout(false);
            this.toolStripDatabaseSelector.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OLVColumn olvColumnDatabaseName;
        private OLVColumn olvColumnDatabaseState;
        private ToolStrip toolStripDatabaseSelector;
        private ToolStripLabel tslFilterDb;
        private ToolStripTextBox tstbFilterDatabases;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbRefreshDatabases;
        private ContextMenuStrip ctxDatabase;
        private ToolStripMenuItem checkSelectedDatabasesToolStripMenuItem;
        private ToolStripMenuItem checkAllDatabasesToolStripMenuItem;
        private ToolStripMenuItem uncheckSelectedDatabasesToolStripMenuItem;
        private ToolStripMenuItem uncheckAllDatabasesToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem refreshDatabasesToolStripMenuItem;
        private ImageList imageListGroup;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslSelectDatabasesCount;
        private ObjectListView objectListView1;
        private OLVColumn olvColumnNote;
    }
}