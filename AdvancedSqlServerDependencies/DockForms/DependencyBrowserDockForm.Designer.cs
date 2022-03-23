using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class DependencyBrowserDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DependencyBrowserDockForm));
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumnObjectName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnObjectID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnServerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDatabaseName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSchemaName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnObjectType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMaximumUnderlyingLevels = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnIsSelfReferencing = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctxObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandSelectedObjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseSelectedObjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllObjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllObjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.autoResizeColumnsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslObjectCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripObjects = new System.Windows.Forms.ToolStrip();
            this.expandSelectedObjectToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.collapseSelectedObjectToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.tsbExpandAllObjects = new System.Windows.Forms.ToolStripButton();
            this.tsbCollapseAllObjects = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAutoResizeColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.ctxObject.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripObjects.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumnObjectName);
            this.treeListView1.AllColumns.Add(this.olvColumnObjectID);
            this.treeListView1.AllColumns.Add(this.olvColumnServerName);
            this.treeListView1.AllColumns.Add(this.olvColumnDatabaseName);
            this.treeListView1.AllColumns.Add(this.olvColumnSchemaName);
            this.treeListView1.AllColumns.Add(this.olvColumnObjectType);
            this.treeListView1.AllColumns.Add(this.olvColumnMaximumUnderlyingLevels);
            this.treeListView1.AllColumns.Add(this.olvColumnIsSelfReferencing);
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnObjectName,
            this.olvColumnObjectID,
            this.olvColumnServerName,
            this.olvColumnDatabaseName,
            this.olvColumnSchemaName,
            this.olvColumnObjectType,
            this.olvColumnMaximumUnderlyingLevels,
            this.olvColumnIsSelfReferencing});
            this.treeListView1.ContextMenuStrip = this.ctxObject;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 89);
            this.treeListView1.MultiSelect = false;
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.ShowItemToolTips = true;
            this.treeListView1.Size = new System.Drawing.Size(719, 281);
            this.treeListView1.TabIndex = 12;
            this.treeListView1.UseAlternatingBackColors = true;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.UseFilterIndicator = true;
            this.treeListView1.UseFiltering = true;
            this.treeListView1.UseHotItem = true;
            this.treeListView1.UseTranslucentHotItem = true;
            this.treeListView1.UseTranslucentSelection = true;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            // 
            // olvColumnObjectName
            // 
            this.olvColumnObjectName.AspectName = "ObjectName";
            this.olvColumnObjectName.Hideable = false;
            this.olvColumnObjectName.Text = "Object";
            // 
            // olvColumnObjectID
            // 
            this.olvColumnObjectID.AspectName = "ObjectId";
            this.olvColumnObjectID.Text = "ID";
            this.olvColumnObjectID.Width = 100;
            // 
            // olvColumnServerName
            // 
            this.olvColumnServerName.AspectName = "ServerName";
            this.olvColumnServerName.Text = "Server";
            // 
            // olvColumnDatabaseName
            // 
            this.olvColumnDatabaseName.AspectName = "DatabaseName";
            this.olvColumnDatabaseName.HeaderImageKey = "database.bmp";
            this.olvColumnDatabaseName.Text = "Database";
            // 
            // olvColumnSchemaName
            // 
            this.olvColumnSchemaName.AspectName = "SchemaName";
            this.olvColumnSchemaName.Text = "Schema";
            // 
            // olvColumnObjectType
            // 
            this.olvColumnObjectType.AspectName = "ObjectType";
            this.olvColumnObjectType.Text = "Type";
            // 
            // olvColumnMaximumUnderlyingLevels
            // 
            this.olvColumnMaximumUnderlyingLevels.AspectName = "MaximumUnderlyingLevels";
            this.olvColumnMaximumUnderlyingLevels.Text = "Max Underlying Levels";
            // 
            // olvColumnIsSelfReferencing
            // 
            this.olvColumnIsSelfReferencing.AspectName = "IsSelfReferencing";
            this.olvColumnIsSelfReferencing.Text = "Self Referencing?";
            // 
            // ctxObject
            // 
            this.ctxObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandSelectedObjectToolStripMenuItem1,
            this.collapseSelectedObjectToolStripMenuItem1,
            this.expandAllObjectsToolStripMenuItem1,
            this.collapseAllObjectsToolStripMenuItem1,
            this.toolStripMenuItem7,
            this.autoResizeColumnsToolStripMenuItem1,
            this.exportToolStripMenuItem1});
            this.ctxObject.Name = "contextMenuStrip1";
            this.ctxObject.Size = new System.Drawing.Size(187, 142);
            // 
            // expandSelectedObjectToolStripMenuItem1
            // 
            this.expandSelectedObjectToolStripMenuItem1.Enabled = false;
            this.expandSelectedObjectToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Expand_16xLG;
            this.expandSelectedObjectToolStripMenuItem1.Name = "expandSelectedObjectToolStripMenuItem1";
            this.expandSelectedObjectToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.expandSelectedObjectToolStripMenuItem1.Text = "Expand Selected";
            // 
            // collapseSelectedObjectToolStripMenuItem1
            // 
            this.collapseSelectedObjectToolStripMenuItem1.Enabled = false;
            this.collapseSelectedObjectToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Collapse_16xLG;
            this.collapseSelectedObjectToolStripMenuItem1.Name = "collapseSelectedObjectToolStripMenuItem1";
            this.collapseSelectedObjectToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.collapseSelectedObjectToolStripMenuItem1.Text = "Collapse Selected";
            // 
            // expandAllObjectsToolStripMenuItem1
            // 
            this.expandAllObjectsToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Expand_large;
            this.expandAllObjectsToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.expandAllObjectsToolStripMenuItem1.Name = "expandAllObjectsToolStripMenuItem1";
            this.expandAllObjectsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.expandAllObjectsToolStripMenuItem1.Text = "Expand All";
            // 
            // collapseAllObjectsToolStripMenuItem1
            // 
            this.collapseAllObjectsToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Collapse_large;
            this.collapseAllObjectsToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.collapseAllObjectsToolStripMenuItem1.Name = "collapseAllObjectsToolStripMenuItem1";
            this.collapseAllObjectsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.collapseAllObjectsToolStripMenuItem1.Text = "Collapse All";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(183, 6);
            // 
            // autoResizeColumnsToolStripMenuItem1
            // 
            this.autoResizeColumnsToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Autosizecolumn_269_32;
            this.autoResizeColumnsToolStripMenuItem1.Name = "autoResizeColumnsToolStripMenuItem1";
            this.autoResizeColumnsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.autoResizeColumnsToolStripMenuItem1.Text = "Auto Resize Columns";
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Office_Excel_Application_16xLG;
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslObjectCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslObjectCount
            // 
            this.tsslObjectCount.Image = global::AdvancedSqlServerDependencies.Properties.Resources.ObjectDatasource_6037_24;
            this.tsslObjectCount.ImageTransparentColor = System.Drawing.Color.White;
            this.tsslObjectCount.Name = "tsslObjectCount";
            this.tsslObjectCount.Size = new System.Drawing.Size(225, 17);
            this.tsslObjectCount.Text = "0 total, 0 root, 0 dependency, 0 unique";
            this.tsslObjectCount.ToolTipText = "Number of resulting database objects";
            // 
            // toolStripObjects
            // 
            this.toolStripObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandSelectedObjectToolStripMenuItem,
            this.collapseSelectedObjectToolStripMenuItem,
            this.tsbExpandAllObjects,
            this.tsbCollapseAllObjects,
            this.toolStripSeparator4,
            this.tsbAutoResizeColumns,
            this.toolStripSeparator9,
            this.tsbExport,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStripObjects.Location = new System.Drawing.Point(0, 64);
            this.toolStripObjects.Name = "toolStripObjects";
            this.toolStripObjects.Size = new System.Drawing.Size(719, 25);
            this.toolStripObjects.TabIndex = 15;
            this.toolStripObjects.Text = "toolStrip1";
            // 
            // expandSelectedObjectToolStripMenuItem
            // 
            this.expandSelectedObjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.expandSelectedObjectToolStripMenuItem.Enabled = false;
            this.expandSelectedObjectToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Expand_16xLG;
            this.expandSelectedObjectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expandSelectedObjectToolStripMenuItem.Name = "expandSelectedObjectToolStripMenuItem";
            this.expandSelectedObjectToolStripMenuItem.Size = new System.Drawing.Size(23, 22);
            this.expandSelectedObjectToolStripMenuItem.Text = "Expand selected";
            this.expandSelectedObjectToolStripMenuItem.Click += new System.EventHandler(this.expandSelectedObject);
            // 
            // collapseSelectedObjectToolStripMenuItem
            // 
            this.collapseSelectedObjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collapseSelectedObjectToolStripMenuItem.Enabled = false;
            this.collapseSelectedObjectToolStripMenuItem.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Collapse_16xLG;
            this.collapseSelectedObjectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collapseSelectedObjectToolStripMenuItem.Name = "collapseSelectedObjectToolStripMenuItem";
            this.collapseSelectedObjectToolStripMenuItem.Size = new System.Drawing.Size(23, 22);
            this.collapseSelectedObjectToolStripMenuItem.Text = "Collapse selected";
            this.collapseSelectedObjectToolStripMenuItem.Click += new System.EventHandler(this.collapseSelectedObject);
            // 
            // tsbExpandAllObjects
            // 
            this.tsbExpandAllObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExpandAllObjects.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Expand_large;
            this.tsbExpandAllObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpandAllObjects.Name = "tsbExpandAllObjects";
            this.tsbExpandAllObjects.Size = new System.Drawing.Size(23, 22);
            this.tsbExpandAllObjects.Text = "Expand whole tree";
            this.tsbExpandAllObjects.Click += new System.EventHandler(this.expandAllObjects);
            // 
            // tsbCollapseAllObjects
            // 
            this.tsbCollapseAllObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCollapseAllObjects.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Collapse_large;
            this.tsbCollapseAllObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCollapseAllObjects.Name = "tsbCollapseAllObjects";
            this.tsbCollapseAllObjects.Size = new System.Drawing.Size(23, 22);
            this.tsbCollapseAllObjects.Text = "Collapse whole tree";
            this.tsbCollapseAllObjects.Click += new System.EventHandler(this.collapseAllObjects);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAutoResizeColumns
            // 
            this.tsbAutoResizeColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAutoResizeColumns.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Autosizecolumn_269_32;
            this.tsbAutoResizeColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoResizeColumns.Name = "tsbAutoResizeColumns";
            this.tsbAutoResizeColumns.Size = new System.Drawing.Size(23, 22);
            this.tsbAutoResizeColumns.Text = "Auto Resize Columns";
            this.tsbAutoResizeColumns.ToolTipText = "Auto resize columns";
            this.tsbAutoResizeColumns.Click += new System.EventHandler(this.autoResizeColumns);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Office_Excel_Application_16xLG;
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(103, 22);
            this.tsbExport.Text = "Export to Excel";
            this.tsbExport.ToolTipText = "Export to Excel";
            this.tsbExport.Click += new System.EventHandler(this.export);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel1.Text = "Highlight:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(120, 25);
            this.toolStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyUp);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 42);
            this.panel1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(135, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(584, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(135, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(584, 20);
            this.textBox1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(42, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 42);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search direction:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Databases:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::AdvancedSqlServerDependencies.Properties.Resources._112_DownArrowLong_Blue_32x32_72;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Red;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.Location = new System.Drawing.Point(22, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(697, 22);
            this.labelInfo.TabIndex = 18;
            this.labelInfo.Text = "label3";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.labelInfo);
            this.panelInfo.Controls.Add(this.pictureBoxInfo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 42);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(719, 22);
            this.panelInfo.TabIndex = 19;
            this.panelInfo.Visible = false;
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.BackColor = System.Drawing.Color.Red;
            this.pictureBoxInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxInfo.Image = global::AdvancedSqlServerDependencies.Properties.Resources.StatusAnnotations_Warning_16xLG_color;
            this.pictureBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxInfo.TabIndex = 0;
            this.pictureBoxInfo.TabStop = false;
            // 
            // DependencyBrowserDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 392);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.toolStripObjects);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DependencyBrowserDockForm";
            this.Text = "Dependency Browser";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DependencyBrowserDockForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ctxObject.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripObjects.ResumeLayout(false);
            this.toolStripObjects.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeListView treeListView1;
        private OLVColumn olvColumnObjectName;
        private OLVColumn olvColumnObjectID;
        private OLVColumn olvColumnServerName;
        private OLVColumn olvColumnDatabaseName;
        private OLVColumn olvColumnSchemaName;
        private OLVColumn olvColumnObjectType;
        private OLVColumn olvColumnMaximumUnderlyingLevels;
        private OLVColumn olvColumnIsSelfReferencing;
        private StatusStrip statusStrip1;
        private ToolStrip toolStripObjects;
        private ToolStripButton expandSelectedObjectToolStripMenuItem;
        private ToolStripButton collapseSelectedObjectToolStripMenuItem;
        private ToolStripButton tsbExpandAllObjects;
        private ToolStripButton tsbCollapseAllObjects;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbAutoResizeColumns;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton tsbExport;
        private ToolStripStatusLabel tsslObjectCount;
        private ContextMenuStrip ctxObject;
        private ToolStripMenuItem expandSelectedObjectToolStripMenuItem1;
        private ToolStripMenuItem collapseSelectedObjectToolStripMenuItem1;
        private ToolStripMenuItem expandAllObjectsToolStripMenuItem1;
        private ToolStripMenuItem collapseAllObjectsToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem autoResizeColumnsToolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelInfo;
        private Panel panelInfo;
        private PictureBox pictureBoxInfo;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
    }
}