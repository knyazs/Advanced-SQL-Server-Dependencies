using AdvancedSqlServerDependencies.Components.Watermark;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.Forms
{
    partial class NewDependencyCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDependencyCheckForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDependencySearchBottomUp = new System.Windows.Forms.RadioButton();
            this.rbDependencySearchTopDown = new System.Windows.Forms.RadioButton();
            this.btnViewDependencies = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new AdvancedSqlServerDependencies.Components.Watermark.CueComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDependencySearchBottomUp);
            this.groupBox2.Controls.Add(this.rbDependencySearchTopDown);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 106);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search option";
            // 
            // rbDependencySearchBottomUp
            // 
            this.rbDependencySearchBottomUp.Image = global::AdvancedSqlServerDependencies.Properties.Resources._112_UpArrowLong_Orange_16x16_72;
            this.rbDependencySearchBottomUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbDependencySearchBottomUp.Location = new System.Drawing.Point(11, 63);
            this.rbDependencySearchBottomUp.Name = "rbDependencySearchBottomUp";
            this.rbDependencySearchBottomUp.Size = new System.Drawing.Size(244, 25);
            this.rbDependencySearchBottomUp.TabIndex = 1;
            this.rbDependencySearchBottomUp.Text = "Objects that depend on searched object";
            this.rbDependencySearchBottomUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDependencySearchBottomUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.rbDependencySearchBottomUp, resources.GetString("rbDependencySearchBottomUp.ToolTip"));
            this.rbDependencySearchBottomUp.UseVisualStyleBackColor = true;
            // 
            // rbDependencySearchTopDown
            // 
            this.rbDependencySearchTopDown.Checked = true;
            this.rbDependencySearchTopDown.Image = global::AdvancedSqlServerDependencies.Properties.Resources._112_DownArrowLong_Blue_16x16_72;
            this.rbDependencySearchTopDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbDependencySearchTopDown.Location = new System.Drawing.Point(11, 32);
            this.rbDependencySearchTopDown.Name = "rbDependencySearchTopDown";
            this.rbDependencySearchTopDown.Size = new System.Drawing.Size(266, 25);
            this.rbDependencySearchTopDown.TabIndex = 0;
            this.rbDependencySearchTopDown.TabStop = true;
            this.rbDependencySearchTopDown.Text = "Objects on which searched object depends on";
            this.rbDependencySearchTopDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDependencySearchTopDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.rbDependencySearchTopDown, resources.GetString("rbDependencySearchTopDown.ToolTip"));
            this.rbDependencySearchTopDown.UseVisualStyleBackColor = true;
            this.rbDependencySearchTopDown.CheckedChanged += new System.EventHandler(this.rbTopDownDependencySearch_CheckedChanged);
            // 
            // btnViewDependencies
            // 
            this.btnViewDependencies.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnViewDependencies.Location = new System.Drawing.Point(333, 31);
            this.btnViewDependencies.Name = "btnViewDependencies";
            this.btnViewDependencies.Size = new System.Drawing.Size(141, 23);
            this.btnViewDependencies.TabIndex = 13;
            this.btnViewDependencies.Text = "View Dependencies";
            this.btnViewDependencies.UseVisualStyleBackColor = true;
            this.btnViewDependencies.Click += new System.EventHandler(this.btnViewDependencies_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(333, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // comboBox1
            // 
            this.comboBox1.CueText = "Enter full or partial object name or leave it blank";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 21);
            this.comboBox1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox1, "Enter only object name without database or schema name.\r\nLeave this field empty i" +
        "f you want to search all objects.");
            this.comboBox1.TextChanged += new System.EventHandler(this.searchObjectTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Object name contains:";
            // 
            // NewDependencyCheckForm
            // 
            this.AcceptButton = this.btnViewDependencies;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(498, 195);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnViewDependencies);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDependencyCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick Dependency Search";
            this.Load += new System.EventHandler(this.NewDependencyCheckForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox2;
        private RadioButton rbDependencySearchBottomUp;
        private RadioButton rbDependencySearchTopDown;
        private Button btnViewDependencies;
        private Button btnCancel;
        private CueComboBox comboBox1;
        private ToolTip toolTip1;
        private Label label1;
    }
}