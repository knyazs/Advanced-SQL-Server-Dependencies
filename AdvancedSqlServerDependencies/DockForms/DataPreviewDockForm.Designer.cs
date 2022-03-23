using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class DataPreviewDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataPreviewDockForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbShowInThisWindow = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenInSSMS = new System.Windows.Forms.ToolStripButton();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(633, 20);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowInThisWindow,
            this.tsbOpenInSSMS});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbShowInThisWindow
            // 
            this.tsbShowInThisWindow.Enabled = false;
            this.tsbShowInThisWindow.Image = global::AdvancedSqlServerDependencies.Properties.Resources.window;
            this.tsbShowInThisWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowInThisWindow.Name = "tsbShowInThisWindow";
            this.tsbShowInThisWindow.Size = new System.Drawing.Size(95, 22);
            this.tsbShowInThisWindow.Text = "Preview Data";
            this.tsbShowInThisWindow.Click += new System.EventHandler(this.tsbShowInThisWindow_Click);
            // 
            // tsbOpenInSSMS
            // 
            this.tsbOpenInSSMS.Enabled = false;
            this.tsbOpenInSSMS.Image = global::AdvancedSqlServerDependencies.Properties.Resources.ssms2;
            this.tsbOpenInSSMS.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbOpenInSSMS.Name = "tsbOpenInSSMS";
            this.tsbOpenInSSMS.Size = new System.Drawing.Size(239, 22);
            this.tsbOpenInSSMS.Text = "Open in SQL Server Management Studio";
            this.tsbOpenInSSMS.Visible = false;
            this.tsbOpenInSSMS.Click += new System.EventHandler(this.tsbOpenInSSMS_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.GridLines = true;
            this.objectListView1.Location = new System.Drawing.Point(0, 45);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(633, 217);
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
            // DataPreviewDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 262);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataPreviewDockForm";
            this.Text = "Data Preview";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DataPreviewDockForm_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbShowInThisWindow;
        private ToolStripButton tsbOpenInSSMS;
        private ObjectListView objectListView1;
    }
}