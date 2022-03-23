using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class ChildrenSummaryDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildrenSummaryDockForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnObjectType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnObjectCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnUniqueObjectCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslObjectCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(379, 20);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumnObjectType);
            this.objectListView1.AllColumns.Add(this.olvColumnObjectCount);
            this.objectListView1.AllColumns.Add(this.olvColumnUniqueObjectCount);
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnObjectType,
            this.olvColumnObjectCount,
            this.olvColumnUniqueObjectCount});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(0, 20);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(379, 277);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 16;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.UseHotItem = true;
            this.objectListView1.UseTranslucentHotItem = true;
            this.objectListView1.UseTranslucentSelection = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.objectListView1_FormatRow);
            // 
            // olvColumnObjectType
            // 
            this.olvColumnObjectType.AspectName = "ObjectType";
            this.olvColumnObjectType.ImageAspectName = "";
            this.olvColumnObjectType.Text = "Object Type";
            this.olvColumnObjectType.Width = 173;
            // 
            // olvColumnObjectCount
            // 
            this.olvColumnObjectCount.AspectName = "ObjectCount";
            this.olvColumnObjectCount.Text = "Objects Count";
            this.olvColumnObjectCount.Width = 89;
            // 
            // olvColumnUniqueObjectCount
            // 
            this.olvColumnUniqueObjectCount.AspectName = "UniqueObjectCount";
            this.olvColumnUniqueObjectCount.Text = "Unique";
            this.olvColumnUniqueObjectCount.Width = 81;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslObjectCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(379, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslObjectCount
            // 
            this.tsslObjectCount.Image = global::AdvancedSqlServerDependencies.Properties.Resources.ObjectDatasource_6037_24;
            this.tsslObjectCount.ImageTransparentColor = System.Drawing.Color.White;
            this.tsslObjectCount.Name = "tsslObjectCount";
            this.tsslObjectCount.Size = new System.Drawing.Size(122, 17);
            this.tsslObjectCount.Text = "0 objects, 0 unique";
            this.tsslObjectCount.ToolTipText = "Number of resulting database objects";
            // 
            // ChildrenSummaryDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 319);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChildrenSummaryDockForm";
            this.Text = "Children Summary";
            this.Load += new System.EventHandler(this.ChildrenSummaryDockForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChildrenSummaryDockForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private ObjectListView objectListView1;
        private OLVColumn olvColumnObjectType;
        private OLVColumn olvColumnObjectCount;
        private OLVColumn olvColumnUniqueObjectCount;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslObjectCount;
    }
}