using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class TopObjectsDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopObjectsDockForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTopTablesByRowCount = new System.Windows.Forms.TabPage();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnDatabaseName1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSchemaName1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableName1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnRowCount1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.objectListView2 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnDatabaseName2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSchemaName2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableName2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1.SuspendLayout();
            this.tabPageTopTablesByRowCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTopTablesByRowCount);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 399);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTopTablesByRowCount
            // 
            this.tabPageTopTablesByRowCount.Controls.Add(this.objectListView1);
            this.tabPageTopTablesByRowCount.Location = new System.Drawing.Point(4, 22);
            this.tabPageTopTablesByRowCount.Name = "tabPageTopTablesByRowCount";
            this.tabPageTopTablesByRowCount.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTopTablesByRowCount.Size = new System.Drawing.Size(684, 373);
            this.tabPageTopTablesByRowCount.TabIndex = 0;
            this.tabPageTopTablesByRowCount.Text = "Top Tables by Row Count";
            this.tabPageTopTablesByRowCount.UseVisualStyleBackColor = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumnDatabaseName1);
            this.objectListView1.AllColumns.Add(this.olvColumnSchemaName1);
            this.objectListView1.AllColumns.Add(this.olvColumnTableName1);
            this.objectListView1.AllColumns.Add(this.olvColumnRowCount1);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDatabaseName1,
            this.olvColumnSchemaName1,
            this.olvColumnTableName1,
            this.olvColumnRowCount1});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.objectListView1.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.objectListView1.Location = new System.Drawing.Point(3, 3);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(678, 367);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 16;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.UseHotItem = true;
            this.objectListView1.UseTranslucentHotItem = true;
            this.objectListView1.UseTranslucentSelection = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnDatabaseName1
            // 
            this.olvColumnDatabaseName1.AspectName = "DatabaseName";
            this.olvColumnDatabaseName1.ImageAspectName = "Image";
            this.olvColumnDatabaseName1.Text = "Database";
            this.olvColumnDatabaseName1.Width = 143;
            // 
            // olvColumnSchemaName1
            // 
            this.olvColumnSchemaName1.AspectName = "SchemaName";
            this.olvColumnSchemaName1.Text = "Schema";
            this.olvColumnSchemaName1.Width = 108;
            // 
            // olvColumnTableName1
            // 
            this.olvColumnTableName1.AspectName = "ObjectName";
            this.olvColumnTableName1.Text = "Table";
            this.olvColumnTableName1.Width = 127;
            // 
            // olvColumnRowCount1
            // 
            this.olvColumnRowCount1.AspectName = "RowCount";
            this.olvColumnRowCount1.AspectToStringFormat = "{0:#,##}";
            this.olvColumnRowCount1.Text = "Row Count";
            this.olvColumnRowCount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvColumnRowCount1.Width = 91;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.objectListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(684, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Top Tables by Size";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // objectListView2
            // 
            this.objectListView2.AllColumns.Add(this.olvColumnDatabaseName2);
            this.objectListView2.AllColumns.Add(this.olvColumnSchemaName2);
            this.objectListView2.AllColumns.Add(this.olvColumnTableName2);
            this.objectListView2.AllColumns.Add(this.olvColumnTableSize);
            this.objectListView2.CellEditUseWholeCell = false;
            this.objectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDatabaseName2,
            this.olvColumnSchemaName2,
            this.olvColumnTableName2,
            this.olvColumnTableSize});
            this.objectListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView2.FullRowSelect = true;
            this.objectListView2.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.objectListView2.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.objectListView2.Location = new System.Drawing.Point(3, 3);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.ShowGroups = false;
            this.objectListView2.Size = new System.Drawing.Size(678, 367);
            this.objectListView2.SortGroupItemsByPrimaryColumn = false;
            this.objectListView2.TabIndex = 17;
            this.objectListView2.UseAlternatingBackColors = true;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.UseFilterIndicator = true;
            this.objectListView2.UseFiltering = true;
            this.objectListView2.UseHotItem = true;
            this.objectListView2.UseTranslucentHotItem = true;
            this.objectListView2.UseTranslucentSelection = true;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnDatabaseName2
            // 
            this.olvColumnDatabaseName2.AspectName = "DatabaseName";
            this.olvColumnDatabaseName2.ImageAspectName = "Image";
            this.olvColumnDatabaseName2.Text = "Database";
            this.olvColumnDatabaseName2.Width = 143;
            // 
            // olvColumnSchemaName2
            // 
            this.olvColumnSchemaName2.AspectName = "SchemaName";
            this.olvColumnSchemaName2.Text = "Schema";
            this.olvColumnSchemaName2.Width = 108;
            // 
            // olvColumnTableName2
            // 
            this.olvColumnTableName2.AspectName = "ObjectName";
            this.olvColumnTableName2.Text = "Table";
            this.olvColumnTableName2.Width = 127;
            // 
            // olvColumnTableSize
            // 
            this.olvColumnTableSize.AspectName = "TotalSpaceUsed";
            this.olvColumnTableSize.AspectToStringFormat = "";
            this.olvColumnTableSize.Text = "Table Size";
            this.olvColumnTableSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvColumnTableSize.Width = 91;
            // 
            // TopObjectsDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 399);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TopObjectsDockForm";
            this.Text = "Top Objects";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TopObjectsDockForm_Paint);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTopTablesByRowCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private TabControl tabControl1;
        private TabPage tabPageTopTablesByRowCount;
        private TabPage tabPage2;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnDatabaseName1;
        private BrightIdeasSoftware.OLVColumn olvColumnSchemaName1;
        private BrightIdeasSoftware.OLVColumn olvColumnTableName1;
        private BrightIdeasSoftware.OLVColumn olvColumnRowCount1;
        private BrightIdeasSoftware.ObjectListView objectListView2;
        private BrightIdeasSoftware.OLVColumn olvColumnDatabaseName2;
        private BrightIdeasSoftware.OLVColumn olvColumnSchemaName2;
        private BrightIdeasSoftware.OLVColumn olvColumnTableName2;
        private BrightIdeasSoftware.OLVColumn olvColumnTableSize;
    }
}