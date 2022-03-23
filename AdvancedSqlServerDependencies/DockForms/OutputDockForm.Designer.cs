using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class OutputDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputDockForm));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnMessageType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessageTimestamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessageDescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDuration = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumnMessageType);
            this.objectListView1.AllColumns.Add(this.olvColumnMessageTimestamp);
            this.objectListView1.AllColumns.Add(this.olvColumnMessageDescription);
            this.objectListView1.AllColumns.Add(this.olvColumnDuration);
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnMessageType,
            this.olvColumnMessageTimestamp,
            this.olvColumnMessageDescription,
            this.olvColumnDuration});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.Size = new System.Drawing.Size(614, 177);
            this.objectListView1.TabIndex = 16;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseHotItem = true;
            this.objectListView1.UseTranslucentHotItem = true;
            this.objectListView1.UseTranslucentSelection = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnMessageType
            // 
            this.olvColumnMessageType.AspectName = "OutputMessageType";
            this.olvColumnMessageType.Groupable = false;
            this.olvColumnMessageType.Text = "";
            this.olvColumnMessageType.Width = 20;
            // 
            // olvColumnMessageTimestamp
            // 
            this.olvColumnMessageTimestamp.AspectName = "OutputMessageTimestamp";
            this.olvColumnMessageTimestamp.Groupable = false;
            this.olvColumnMessageTimestamp.Text = "Time";
            this.olvColumnMessageTimestamp.Width = 140;
            // 
            // olvColumnMessageDescription
            // 
            this.olvColumnMessageDescription.AspectName = "OutputMessageDescription";
            this.olvColumnMessageDescription.Groupable = false;
            this.olvColumnMessageDescription.Text = "Description";
            this.olvColumnMessageDescription.Width = 300;
            // 
            // olvColumnDuration
            // 
            this.olvColumnDuration.AspectName = "DurationSecString";
            this.olvColumnDuration.Text = "Duration";
            this.olvColumnDuration.Width = 90;
            // 
            // OutputDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 177);
            this.Controls.Add(this.objectListView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutputDockForm";
            this.Text = "Output";
            this.Resize += new System.EventHandler(this.OutputDockForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn olvColumnMessageTimestamp;
        private BrightIdeasSoftware.OLVColumn olvColumnMessageDescription;
        internal BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnMessageType;
        private BrightIdeasSoftware.OLVColumn olvColumnDuration;

    }
}