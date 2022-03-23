using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.Forms
{
    partial class ExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.textBoxExceptionDetails = new System.Windows.Forms.TextBox();
            this.textBoxExceptionMessage = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonReportIssue = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDetails
            // 
            this.buttonDetails.Image = global::AdvancedSqlServerDependencies.Properties.Resources.arrow_Down_16xSM;
            this.buttonDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetails.Location = new System.Drawing.Point(12, 141);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 1;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonDetails, "Show exception details");
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinue.Location = new System.Drawing.Point(365, 141);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 3;
            this.buttonContinue.Text = "Continue";
            this.toolTip1.SetToolTip(this.buttonContinue, "Close this window and continue");
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.Location = new System.Drawing.Point(446, 141);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Quit";
            this.toolTip1.SetToolTip(this.buttonQuit, "Quit the application");
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // textBoxExceptionDetails
            // 
            this.textBoxExceptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExceptionDetails.Location = new System.Drawing.Point(12, 183);
            this.textBoxExceptionDetails.Multiline = true;
            this.textBoxExceptionDetails.Name = "textBoxExceptionDetails";
            this.textBoxExceptionDetails.ReadOnly = true;
            this.textBoxExceptionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxExceptionDetails.Size = new System.Drawing.Size(509, 180);
            this.textBoxExceptionDetails.TabIndex = 5;
            this.textBoxExceptionDetails.Text = "Exception details";
            this.textBoxExceptionDetails.Visible = false;
            this.textBoxExceptionDetails.WordWrap = false;
            // 
            // textBoxExceptionMessage
            // 
            this.textBoxExceptionMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExceptionMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxExceptionMessage.Location = new System.Drawing.Point(97, 12);
            this.textBoxExceptionMessage.Multiline = true;
            this.textBoxExceptionMessage.Name = "textBoxExceptionMessage";
            this.textBoxExceptionMessage.ReadOnly = true;
            this.textBoxExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExceptionMessage.Size = new System.Drawing.Size(424, 123);
            this.textBoxExceptionMessage.TabIndex = 0;
            this.textBoxExceptionMessage.Text = "Exception message";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdvancedSqlServerDependencies.Properties.Resources._109_AllAnnotations_Error_64x64_72;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 76);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonReportIssue
            // 
            this.buttonReportIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReportIssue.Location = new System.Drawing.Point(284, 141);
            this.buttonReportIssue.Name = "buttonReportIssue";
            this.buttonReportIssue.Size = new System.Drawing.Size(75, 23);
            this.buttonReportIssue.TabIndex = 2;
            this.buttonReportIssue.Text = "Report Issue";
            this.toolTip1.SetToolTip(this.buttonReportIssue, "Navigate to project web page and report new issue");
            this.buttonReportIssue.UseVisualStyleBackColor = true;
            this.buttonReportIssue.Click += new System.EventHandler(this.buttonEmailError_Click);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 375);
            this.Controls.Add(this.buttonReportIssue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxExceptionMessage);
            this.Controls.Add(this.textBoxExceptionDetails);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exception";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonDetails;
        private Button buttonContinue;
        private Button buttonQuit;
        private TextBox textBoxExceptionDetails;
        private TextBox textBoxExceptionMessage;
        private PictureBox pictureBox1;
        private Button buttonReportIssue;
        private ToolTip toolTip1;
    }
}