using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AdvancedSqlServerDependencies.Forms.Options
{
    partial class OptionsAppearancePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxUseAlternatingBackColors = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSport = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonAlternateBackColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonDefaultColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxUseAlternatingBackColors
            // 
            this.cbxUseAlternatingBackColors.AutoSize = true;
            this.cbxUseAlternatingBackColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUseAlternatingBackColors.Location = new System.Drawing.Point(13, 36);
            this.cbxUseAlternatingBackColors.Name = "cbxUseAlternatingBackColors";
            this.cbxUseAlternatingBackColors.Size = new System.Drawing.Size(185, 17);
            this.cbxUseAlternatingBackColors.TabIndex = 0;
            this.cbxUseAlternatingBackColors.Text = "Use Alternating Back Colors";
            this.cbxUseAlternatingBackColors.UseVisualStyleBackColor = true;
            this.cbxUseAlternatingBackColors.CheckedChanged += new System.EventHandler(this.cbxUseAlternatingBackColors_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Use alternating colors for all list view controls";
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumnSport);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumnSport});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(13, 146);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowItemCountOnGroups = true;
            this.objectListView1.Size = new System.Drawing.Size(383, 82);
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
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Id";
            this.olvColumn1.Text = "Id";
            this.olvColumn1.Width = 40;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "FirstName";
            this.olvColumn2.Text = "First Name";
            this.olvColumn2.Width = 80;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "LastName";
            this.olvColumn3.Text = "Last Name";
            this.olvColumn3.Width = 80;
            // 
            // olvColumnSport
            // 
            this.olvColumnSport.AspectName = "Sport";
            this.olvColumnSport.Text = "Sport";
            // 
            // buttonAlternateBackColor
            // 
            this.buttonAlternateBackColor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAlternateBackColor.Location = new System.Drawing.Point(151, 92);
            this.buttonAlternateBackColor.Name = "buttonAlternateBackColor";
            this.buttonAlternateBackColor.Size = new System.Drawing.Size(58, 23);
            this.buttonAlternateBackColor.TabIndex = 17;
            this.buttonAlternateBackColor.Text = "Choose";
            this.buttonAlternateBackColor.UseVisualStyleBackColor = true;
            this.buttonAlternateBackColor.Click += new System.EventHandler(this.buttonAlternateBackColor_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // buttonDefaultColor
            // 
            this.buttonDefaultColor.Location = new System.Drawing.Point(215, 92);
            this.buttonDefaultColor.Name = "buttonDefaultColor";
            this.buttonDefaultColor.Size = new System.Drawing.Size(58, 23);
            this.buttonDefaultColor.TabIndex = 18;
            this.buttonDefaultColor.Text = "Default";
            this.buttonDefaultColor.UseVisualStyleBackColor = true;
            this.buttonDefaultColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Alternate Back Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Sample:";
            // 
            // OptionsAppearancePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDefaultColor);
            this.Controls.Add(this.buttonAlternateBackColor);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxUseAlternatingBackColors);
            this.Name = "OptionsAppearancePanel";
            this.Size = new System.Drawing.Size(407, 246);
            this.Load += new System.EventHandler(this.OptionsAppearancePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox cbxUseAlternatingBackColors;
        private Label label2;
        private ObjectListView objectListView1;
        private OLVColumn olvColumn1;
        private OLVColumn olvColumn2;
        private OLVColumn olvColumn3;
        private Button buttonAlternateBackColor;
        private ColorDialog colorDialog1;
        private Button buttonDefaultColor;
        private Label label1;
        private Label label3;
        private OLVColumn olvColumnSport;
    }
}
