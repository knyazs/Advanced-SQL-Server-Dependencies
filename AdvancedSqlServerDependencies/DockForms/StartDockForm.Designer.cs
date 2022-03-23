using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.DockForms
{
    partial class StartDockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartDockForm));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNewDependencyCheck = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonNewDependencyCheckWizard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 49);
            this.label7.TabIndex = 25;
            this.label7.Text = "3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 49);
            this.label6.TabIndex = 24;
            this.label6.Text = "2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 49);
            this.label5.TabIndex = 23;
            this.label5.Text = "1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(67, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 49);
            this.label3.TabIndex = 22;
            this.label3.Text = "Click on \'New Dependency Check\' button, enter search criteria and click OK";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(67, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 49);
            this.label2.TabIndex = 21;
            this.label2.Text = "From Database Broswer select databases you would like to check dependency on";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 49);
            this.label1.TabIndex = 20;
            this.label1.Text = "Connect to the SQL Server";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "To start checking database dependencies, please:";
            // 
            // buttonNewDependencyCheck
            // 
            this.buttonNewDependencyCheck.Image = global::AdvancedSqlServerDependencies.Properties.Resources.Relation_8467_24;
            this.buttonNewDependencyCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewDependencyCheck.Location = new System.Drawing.Point(252, 131);
            this.buttonNewDependencyCheck.Name = "buttonNewDependencyCheck";
            this.buttonNewDependencyCheck.Size = new System.Drawing.Size(194, 49);
            this.buttonNewDependencyCheck.TabIndex = 18;
            this.buttonNewDependencyCheck.Text = "Quick Dependency Check";
            this.buttonNewDependencyCheck.UseVisualStyleBackColor = true;
            this.buttonNewDependencyCheck.Click += new System.EventHandler(this.buttonNewDependencyCheck_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Image = global::AdvancedSqlServerDependencies.Properties.Resources.AddConnection_477_32;
            this.buttonConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConnect.Location = new System.Drawing.Point(252, 33);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(194, 49);
            this.buttonConnect.TabIndex = 17;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNewDependencyCheckWizard
            // 
            this.buttonNewDependencyCheckWizard.Image = global::AdvancedSqlServerDependencies.Properties.Resources.wizard_16;
            this.buttonNewDependencyCheckWizard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewDependencyCheckWizard.Location = new System.Drawing.Point(252, 186);
            this.buttonNewDependencyCheckWizard.Name = "buttonNewDependencyCheckWizard";
            this.buttonNewDependencyCheckWizard.Size = new System.Drawing.Size(194, 49);
            this.buttonNewDependencyCheckWizard.TabIndex = 26;
            this.buttonNewDependencyCheckWizard.Text = "Dependency Check Wizard";
            this.buttonNewDependencyCheckWizard.UseVisualStyleBackColor = true;
            this.buttonNewDependencyCheckWizard.Click += new System.EventHandler(this.buttonNewDependencyCheck_Click);
            // 
            // StartDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 257);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.buttonNewDependencyCheckWizard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonNewDependencyCheck);
            this.Controls.Add(this.buttonConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartDockForm";
            this.Text = "Start Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Button buttonNewDependencyCheck;
        private Button buttonConnect;
        private Button buttonNewDependencyCheckWizard;


    }
}