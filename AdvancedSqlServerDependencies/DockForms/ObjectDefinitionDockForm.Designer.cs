using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class ObjectDefinitionDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectDefinitionDockForm));
            this.tsbOpenInSSMS = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstbHighlightText = new System.Windows.Forms.ToolStripTextBox();
            this.tslMatchesCount = new System.Windows.Forms.ToolStripLabel();
            this.richTextBoxObjectName = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonWrapText = new System.Windows.Forms.ToolStripButton();
            this.richTextBoxObjectDef = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbOpenInSSMS
            // 
            this.tsbOpenInSSMS.Image = global::AdvancedSqlServerDependencies.Properties.Resources.ssms2;
            this.tsbOpenInSSMS.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbOpenInSSMS.Name = "tsbOpenInSSMS";
            this.tsbOpenInSSMS.Size = new System.Drawing.Size(239, 22);
            this.tsbOpenInSSMS.Text = "Open in SQL Server Management Studio";
            this.tsbOpenInSSMS.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Find:";
            // 
            // tstbHighlightText
            // 
            this.tstbHighlightText.BackColor = System.Drawing.SystemColors.Window;
            this.tstbHighlightText.Name = "tstbHighlightText";
            this.tstbHighlightText.Size = new System.Drawing.Size(150, 25);
            this.tstbHighlightText.TextChanged += new System.EventHandler(this.objectDefinitionOrSearchPhrase_TextChanged);
            // 
            // tslMatchesCount
            // 
            this.tslMatchesCount.Name = "tslMatchesCount";
            this.tslMatchesCount.Size = new System.Drawing.Size(99, 22);
            this.tslMatchesCount.Text = "0 matches found.";
            this.tslMatchesCount.Visible = false;
            // 
            // richTextBoxObjectName
            // 
            this.richTextBoxObjectName.DetectUrls = false;
            this.richTextBoxObjectName.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxObjectName.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxObjectName.Multiline = false;
            this.richTextBoxObjectName.Name = "richTextBoxObjectName";
            this.richTextBoxObjectName.ReadOnly = true;
            this.richTextBoxObjectName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxObjectName.Size = new System.Drawing.Size(829, 20);
            this.richTextBoxObjectName.TabIndex = 9;
            this.richTextBoxObjectName.Text = "";
            this.richTextBoxObjectName.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenInSSMS,
            this.toolStripLabel1,
            this.tstbHighlightText,
            this.tslMatchesCount,
            this.tsbFindNext,
            this.toolStripSeparator1,
            this.toolStripButtonWrapText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFindNext
            // 
            this.tsbFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFindNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindNext.Image")));
            this.tsbFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindNext.Name = "tsbFindNext";
            this.tsbFindNext.Size = new System.Drawing.Size(61, 22);
            this.tsbFindNext.Text = "Find Next";
            this.tsbFindNext.Click += new System.EventHandler(this.tsbFindNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonWrapText
            // 
            this.toolStripButtonWrapText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonWrapText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWrapText.Image")));
            this.toolStripButtonWrapText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWrapText.Name = "toolStripButtonWrapText";
            this.toolStripButtonWrapText.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonWrapText.Text = "Wrap Text";
            this.toolStripButtonWrapText.Click += new System.EventHandler(this.toolStripButtonWrapText_Click);
            // 
            // richTextBoxObjectDef
            // 
            this.richTextBoxObjectDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxObjectDef.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxObjectDef.Location = new System.Drawing.Point(0, 45);
            this.richTextBoxObjectDef.Name = "richTextBoxObjectDef";
            this.richTextBoxObjectDef.ReadOnly = true;
            this.richTextBoxObjectDef.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBoxObjectDef.Size = new System.Drawing.Size(829, 124);
            this.richTextBoxObjectDef.TabIndex = 10;
            this.richTextBoxObjectDef.Text = "";
            this.richTextBoxObjectDef.WordWrap = false;
            this.richTextBoxObjectDef.TextChanged += new System.EventHandler(this.objectDefinitionOrSearchPhrase_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 169);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(829, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "0 lines";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel2.Text = "0 characters";
            // 
            // ObjectDefinitionDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 191);
            this.Controls.Add(this.richTextBoxObjectDef);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBoxObjectName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ObjectDefinitionDockForm";
            this.Text = "Object Definition";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbOpenInSSMS;
        private RichTextBox richTextBoxObjectName;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tstbHighlightText;
        private RichTextBox richTextBoxObjectDef;
        private ToolStripLabel tslMatchesCount;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonWrapText;
        private ToolStripButton tsbFindNext;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Timer timerScroll;
    }
}