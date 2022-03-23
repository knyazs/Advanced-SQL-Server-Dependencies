namespace AdvancedSqlServerDependencies.Forms
{
    partial class RateAppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateAppForm));
            this.buttonRateNow = new System.Windows.Forms.Button();
            this.buttonRateLater = new System.Windows.Forms.Button();
            this.buttonDontRate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRateNow
            // 
            this.buttonRateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRateNow.Location = new System.Drawing.Point(25, 136);
            this.buttonRateNow.Name = "buttonRateNow";
            this.buttonRateNow.Size = new System.Drawing.Size(133, 35);
            this.buttonRateNow.TabIndex = 1;
            this.buttonRateNow.Text = "Rate now";
            this.buttonRateNow.UseVisualStyleBackColor = true;
            this.buttonRateNow.Click += new System.EventHandler(this.buttonRateNow_Click);
            // 
            // buttonRateLater
            // 
            this.buttonRateLater.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRateLater.Location = new System.Drawing.Point(164, 136);
            this.buttonRateLater.Name = "buttonRateLater";
            this.buttonRateLater.Size = new System.Drawing.Size(133, 35);
            this.buttonRateLater.TabIndex = 2;
            this.buttonRateLater.Text = "Ask me later";
            this.buttonRateLater.UseVisualStyleBackColor = true;
            this.buttonRateLater.Click += new System.EventHandler(this.buttonRateLater_Click);
            // 
            // buttonDontRate
            // 
            this.buttonDontRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDontRate.Location = new System.Drawing.Point(303, 136);
            this.buttonDontRate.Name = "buttonDontRate";
            this.buttonDontRate.Size = new System.Drawing.Size(133, 35);
            this.buttonDontRate.TabIndex = 3;
            this.buttonDontRate.Text = "No, thanks";
            this.buttonDontRate.UseVisualStyleBackColor = true;
            this.buttonDontRate.Click += new System.EventHandler(this.buttonDontRate_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(25, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(411, 78);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Please help us spread the word about\r\nAdvanced SQL Server Dependencies\r\napplicati" +
    "on by rating it.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(25, 177);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(409, 46);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.Visible = false;
            // 
            // RateAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 226);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDontRate);
            this.Controls.Add(this.buttonRateLater);
            this.Controls.Add(this.buttonRateNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RateAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rate Advanced SQL Server Dependencies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRateNow;
        private System.Windows.Forms.Button buttonRateLater;
        private System.Windows.Forms.Button buttonDontRate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;

    }
}