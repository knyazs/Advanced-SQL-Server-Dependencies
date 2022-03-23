namespace AdvancedSqlServerDependencies.Forms
{
    partial class NewDependencyCheckWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDependencyCheckWizard));
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.wizardPageWelcome = new AeroWizard.WizardPage();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDoNotShowWelcomePage = new System.Windows.Forms.CheckBox();
            this.wizardPageObjectName = new AeroWizard.WizardPage();
            this.label4 = new System.Windows.Forms.Label();
            this.labelObjectNameMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonObjectNameContains = new System.Windows.Forms.RadioButton();
            this.radioButtonObjectNameStartsWith = new System.Windows.Forms.RadioButton();
            this.radioButtonObjectNameEndsWith = new System.Windows.Forms.RadioButton();
            this.radioButtonObjectNameEquals = new System.Windows.Forms.RadioButton();
            this.cueComboBoxObjectName = new AdvancedSqlServerDependencies.Components.Watermark.CueComboBox();
            this.wizardPageObjectType = new AeroWizard.WizardPage();
            this.buttonUncheckAllObjectTypes = new System.Windows.Forms.Button();
            this.labelObjectTypeMessage = new System.Windows.Forms.Label();
            this.buttonCheckAllObjectTypes = new System.Windows.Forms.Button();
            this.checkedListBoxObjectTypes = new System.Windows.Forms.CheckedListBox();
            this.wizardPageDatabases = new AeroWizard.WizardPage();
            this.buttonUncheckAllDatabases = new System.Windows.Forms.Button();
            this.buttonCheckAllDatabases = new System.Windows.Forms.Button();
            this.labelDatabasesMessage = new System.Windows.Forms.Label();
            this.checkedListBoxDatabasesToSearch = new System.Windows.Forms.CheckedListBox();
            this.wizardPageSearchDirection = new AeroWizard.WizardPage();
            this.labelSearchDirection = new System.Windows.Forms.Label();
            this.radioButtonSearchDirectionTopDown = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchDirectionBottomUp = new System.Windows.Forms.RadioButton();
            this.wizardPageInternalDatabaseRefresh = new AeroWizard.WizardPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelInternalDatabaseRefreshMessage = new System.Windows.Forms.Label();
            this.checkBoxInternalDatabaseRefresh = new System.Windows.Forms.CheckBox();
            this.wizardPageSummary = new AeroWizard.WizardPage();
            this.richTextBoxSummary = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPageWelcome.SuspendLayout();
            this.wizardPageObjectName.SuspendLayout();
            this.wizardPageObjectType.SuspendLayout();
            this.wizardPageDatabases.SuspendLayout();
            this.wizardPageSearchDirection.SuspendLayout();
            this.wizardPageInternalDatabaseRefresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wizardPageSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.ClassicStyle = AeroWizard.WizardClassicStyle.Automatic;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishButtonText = "&View Dependencies";
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wizardPageWelcome);
            this.wizardControl1.Pages.Add(this.wizardPageObjectName);
            this.wizardControl1.Pages.Add(this.wizardPageObjectType);
            this.wizardControl1.Pages.Add(this.wizardPageDatabases);
            this.wizardControl1.Pages.Add(this.wizardPageSearchDirection);
            this.wizardControl1.Pages.Add(this.wizardPageInternalDatabaseRefresh);
            this.wizardControl1.Pages.Add(this.wizardPageSummary);
            this.wizardControl1.Size = new System.Drawing.Size(708, 450);
            this.wizardControl1.TabIndex = 1;
            this.wizardControl1.Title = "Dependency Check Wizard";
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Controls.Add(this.label3);
            this.wizardPageWelcome.Controls.Add(this.checkBoxDoNotShowWelcomePage);
            this.wizardPageWelcome.Name = "wizardPageWelcome";
            this.wizardPageWelcome.Size = new System.Drawing.Size(661, 296);
            this.wizardPageWelcome.TabIndex = 3;
            this.wizardPageWelcome.Text = "Welcome";
            this.wizardPageWelcome.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPageWelcome_Commit);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(628, 151);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Dependency Check Wizard will help you define search criteria to properly iden" +
    "tify objects for which you would like to check dependencies.";
            // 
            // checkBoxDoNotShowWelcomePage
            // 
            this.checkBoxDoNotShowWelcomePage.AutoSize = true;
            this.checkBoxDoNotShowWelcomePage.Location = new System.Drawing.Point(13, 263);
            this.checkBoxDoNotShowWelcomePage.Name = "checkBoxDoNotShowWelcomePage";
            this.checkBoxDoNotShowWelcomePage.Size = new System.Drawing.Size(176, 19);
            this.checkBoxDoNotShowWelcomePage.TabIndex = 2;
            this.checkBoxDoNotShowWelcomePage.Text = "Do not show this page again";
            this.checkBoxDoNotShowWelcomePage.UseVisualStyleBackColor = true;
            // 
            // wizardPageObjectName
            // 
            this.wizardPageObjectName.Controls.Add(this.label4);
            this.wizardPageObjectName.Controls.Add(this.labelObjectNameMessage);
            this.wizardPageObjectName.Controls.Add(this.label2);
            this.wizardPageObjectName.Controls.Add(this.label1);
            this.wizardPageObjectName.Controls.Add(this.radioButtonObjectNameContains);
            this.wizardPageObjectName.Controls.Add(this.radioButtonObjectNameStartsWith);
            this.wizardPageObjectName.Controls.Add(this.radioButtonObjectNameEndsWith);
            this.wizardPageObjectName.Controls.Add(this.radioButtonObjectNameEquals);
            this.wizardPageObjectName.Controls.Add(this.cueComboBoxObjectName);
            this.wizardPageObjectName.Name = "wizardPageObjectName";
            this.wizardPageObjectName.Size = new System.Drawing.Size(661, 296);
            this.wizardPageObjectName.TabIndex = 0;
            this.wizardPageObjectName.Text = "Object Name";
            this.wizardPageObjectName.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPageObjectName_Commit);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(111, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Leave this field empty if you don\'t want to filter by object name";
            // 
            // labelObjectNameMessage
            // 
            this.labelObjectNameMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelObjectNameMessage.Location = new System.Drawing.Point(0, 207);
            this.labelObjectNameMessage.Name = "labelObjectNameMessage";
            this.labelObjectNameMessage.Size = new System.Drawing.Size(660, 89);
            this.labelObjectNameMessage.TabIndex = 8;
            this.labelObjectNameMessage.Text = "No filter applied on object name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(1, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Match type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Object name:";
            // 
            // radioButtonObjectNameContains
            // 
            this.radioButtonObjectNameContains.AutoSize = true;
            this.radioButtonObjectNameContains.Enabled = false;
            this.radioButtonObjectNameContains.Location = new System.Drawing.Point(114, 67);
            this.radioButtonObjectNameContains.Name = "radioButtonObjectNameContains";
            this.radioButtonObjectNameContains.Size = new System.Drawing.Size(72, 19);
            this.radioButtonObjectNameContains.TabIndex = 2;
            this.radioButtonObjectNameContains.TabStop = true;
            this.radioButtonObjectNameContains.Text = "Contains";
            this.radioButtonObjectNameContains.UseVisualStyleBackColor = true;
            this.radioButtonObjectNameContains.CheckedChanged += new System.EventHandler(this.radioButtonObjectNameContains_CheckedChanged);
            // 
            // radioButtonObjectNameStartsWith
            // 
            this.radioButtonObjectNameStartsWith.AutoSize = true;
            this.radioButtonObjectNameStartsWith.Enabled = false;
            this.radioButtonObjectNameStartsWith.Location = new System.Drawing.Point(114, 92);
            this.radioButtonObjectNameStartsWith.Name = "radioButtonObjectNameStartsWith";
            this.radioButtonObjectNameStartsWith.Size = new System.Drawing.Size(120, 19);
            this.radioButtonObjectNameStartsWith.TabIndex = 3;
            this.radioButtonObjectNameStartsWith.TabStop = true;
            this.radioButtonObjectNameStartsWith.Text = "Starts with (Prefix)";
            this.radioButtonObjectNameStartsWith.UseVisualStyleBackColor = true;
            this.radioButtonObjectNameStartsWith.CheckedChanged += new System.EventHandler(this.radioButtonObjectNameStartsWith_CheckedChanged);
            // 
            // radioButtonObjectNameEndsWith
            // 
            this.radioButtonObjectNameEndsWith.AutoSize = true;
            this.radioButtonObjectNameEndsWith.Enabled = false;
            this.radioButtonObjectNameEndsWith.Location = new System.Drawing.Point(114, 117);
            this.radioButtonObjectNameEndsWith.Name = "radioButtonObjectNameEndsWith";
            this.radioButtonObjectNameEndsWith.Size = new System.Drawing.Size(116, 19);
            this.radioButtonObjectNameEndsWith.TabIndex = 4;
            this.radioButtonObjectNameEndsWith.TabStop = true;
            this.radioButtonObjectNameEndsWith.Text = "Ends with (Suffix)";
            this.radioButtonObjectNameEndsWith.UseVisualStyleBackColor = true;
            this.radioButtonObjectNameEndsWith.CheckedChanged += new System.EventHandler(this.radioButtonObjectNameEndsWith_CheckedChanged);
            // 
            // radioButtonObjectNameEquals
            // 
            this.radioButtonObjectNameEquals.AutoSize = true;
            this.radioButtonObjectNameEquals.Enabled = false;
            this.radioButtonObjectNameEquals.Location = new System.Drawing.Point(114, 142);
            this.radioButtonObjectNameEquals.Name = "radioButtonObjectNameEquals";
            this.radioButtonObjectNameEquals.Size = new System.Drawing.Size(59, 19);
            this.radioButtonObjectNameEquals.TabIndex = 5;
            this.radioButtonObjectNameEquals.TabStop = true;
            this.radioButtonObjectNameEquals.Text = "Equals";
            this.radioButtonObjectNameEquals.UseVisualStyleBackColor = true;
            this.radioButtonObjectNameEquals.CheckedChanged += new System.EventHandler(this.radioButtonObjectNameEquals_CheckedChanged);
            // 
            // cueComboBoxObjectName
            // 
            this.cueComboBoxObjectName.CueText = "Enter full or partial object name or leave it blank";
            this.cueComboBoxObjectName.FormattingEnabled = true;
            this.cueComboBoxObjectName.Location = new System.Drawing.Point(114, 3);
            this.cueComboBoxObjectName.Name = "cueComboBoxObjectName";
            this.cueComboBoxObjectName.Size = new System.Drawing.Size(508, 23);
            this.cueComboBoxObjectName.TabIndex = 0;
            this.cueComboBoxObjectName.SelectedIndexChanged += new System.EventHandler(this.cueComboBoxObjectName_TextUpdate);
            this.cueComboBoxObjectName.TextUpdate += new System.EventHandler(this.cueComboBoxObjectName_TextUpdate);
            // 
            // wizardPageObjectType
            // 
            this.wizardPageObjectType.Controls.Add(this.buttonUncheckAllObjectTypes);
            this.wizardPageObjectType.Controls.Add(this.labelObjectTypeMessage);
            this.wizardPageObjectType.Controls.Add(this.buttonCheckAllObjectTypes);
            this.wizardPageObjectType.Controls.Add(this.checkedListBoxObjectTypes);
            this.wizardPageObjectType.Name = "wizardPageObjectType";
            this.wizardPageObjectType.Size = new System.Drawing.Size(661, 296);
            this.wizardPageObjectType.TabIndex = 1;
            this.wizardPageObjectType.Text = "Object Type";
            this.wizardPageObjectType.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPageObjectType_Commit);
            // 
            // buttonUncheckAllObjectTypes
            // 
            this.buttonUncheckAllObjectTypes.Location = new System.Drawing.Point(585, 29);
            this.buttonUncheckAllObjectTypes.Name = "buttonUncheckAllObjectTypes";
            this.buttonUncheckAllObjectTypes.Size = new System.Drawing.Size(75, 23);
            this.buttonUncheckAllObjectTypes.TabIndex = 3;
            this.buttonUncheckAllObjectTypes.Text = "None";
            this.buttonUncheckAllObjectTypes.UseVisualStyleBackColor = true;
            this.buttonUncheckAllObjectTypes.Click += new System.EventHandler(this.buttonUncheckAllObjectTypes_Click);
            // 
            // labelObjectTypeMessage
            // 
            this.labelObjectTypeMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelObjectTypeMessage.Location = new System.Drawing.Point(0, 207);
            this.labelObjectTypeMessage.Name = "labelObjectTypeMessage";
            this.labelObjectTypeMessage.Size = new System.Drawing.Size(660, 89);
            this.labelObjectTypeMessage.TabIndex = 2;
            this.labelObjectTypeMessage.Text = "label3";
            // 
            // buttonCheckAllObjectTypes
            // 
            this.buttonCheckAllObjectTypes.Location = new System.Drawing.Point(585, 0);
            this.buttonCheckAllObjectTypes.Name = "buttonCheckAllObjectTypes";
            this.buttonCheckAllObjectTypes.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckAllObjectTypes.TabIndex = 2;
            this.buttonCheckAllObjectTypes.Text = "All";
            this.buttonCheckAllObjectTypes.UseVisualStyleBackColor = true;
            this.buttonCheckAllObjectTypes.Click += new System.EventHandler(this.buttonCheckAllObjectTypes_Click);
            // 
            // checkedListBoxObjectTypes
            // 
            this.checkedListBoxObjectTypes.FormattingEnabled = true;
            this.checkedListBoxObjectTypes.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxObjectTypes.Name = "checkedListBoxObjectTypes";
            this.checkedListBoxObjectTypes.Size = new System.Drawing.Size(579, 184);
            this.checkedListBoxObjectTypes.TabIndex = 2;
            this.checkedListBoxObjectTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxObjectTypes_ItemCheck);
            // 
            // wizardPageDatabases
            // 
            this.wizardPageDatabases.Controls.Add(this.buttonUncheckAllDatabases);
            this.wizardPageDatabases.Controls.Add(this.buttonCheckAllDatabases);
            this.wizardPageDatabases.Controls.Add(this.labelDatabasesMessage);
            this.wizardPageDatabases.Controls.Add(this.checkedListBoxDatabasesToSearch);
            this.wizardPageDatabases.Name = "wizardPageDatabases";
            this.wizardPageDatabases.Size = new System.Drawing.Size(661, 296);
            this.wizardPageDatabases.TabIndex = 2;
            this.wizardPageDatabases.Text = "Databases";
            // 
            // buttonUncheckAllDatabases
            // 
            this.buttonUncheckAllDatabases.Location = new System.Drawing.Point(586, 29);
            this.buttonUncheckAllDatabases.Name = "buttonUncheckAllDatabases";
            this.buttonUncheckAllDatabases.Size = new System.Drawing.Size(75, 23);
            this.buttonUncheckAllDatabases.TabIndex = 2;
            this.buttonUncheckAllDatabases.Text = "None";
            this.buttonUncheckAllDatabases.UseVisualStyleBackColor = true;
            this.buttonUncheckAllDatabases.Click += new System.EventHandler(this.buttonUncheckAllDatabases_Click);
            // 
            // buttonCheckAllDatabases
            // 
            this.buttonCheckAllDatabases.Location = new System.Drawing.Point(586, 0);
            this.buttonCheckAllDatabases.Name = "buttonCheckAllDatabases";
            this.buttonCheckAllDatabases.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckAllDatabases.TabIndex = 2;
            this.buttonCheckAllDatabases.Text = "All";
            this.buttonCheckAllDatabases.UseVisualStyleBackColor = true;
            this.buttonCheckAllDatabases.Click += new System.EventHandler(this.buttonCheckAllDatabases_Click);
            // 
            // labelDatabasesMessage
            // 
            this.labelDatabasesMessage.Location = new System.Drawing.Point(0, 207);
            this.labelDatabasesMessage.Name = "labelDatabasesMessage";
            this.labelDatabasesMessage.Size = new System.Drawing.Size(660, 89);
            this.labelDatabasesMessage.TabIndex = 2;
            this.labelDatabasesMessage.Text = resources.GetString("labelDatabasesMessage.Text");
            // 
            // checkedListBoxDatabasesToSearch
            // 
            this.checkedListBoxDatabasesToSearch.FormattingEnabled = true;
            this.checkedListBoxDatabasesToSearch.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxDatabasesToSearch.Name = "checkedListBoxDatabasesToSearch";
            this.checkedListBoxDatabasesToSearch.Size = new System.Drawing.Size(580, 184);
            this.checkedListBoxDatabasesToSearch.TabIndex = 2;
            this.checkedListBoxDatabasesToSearch.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDatabasesToSearch_ItemCheck);
            // 
            // wizardPageSearchDirection
            // 
            this.wizardPageSearchDirection.Controls.Add(this.labelSearchDirection);
            this.wizardPageSearchDirection.Controls.Add(this.radioButtonSearchDirectionTopDown);
            this.wizardPageSearchDirection.Controls.Add(this.radioButtonSearchDirectionBottomUp);
            this.wizardPageSearchDirection.Name = "wizardPageSearchDirection";
            this.wizardPageSearchDirection.Size = new System.Drawing.Size(661, 296);
            this.wizardPageSearchDirection.TabIndex = 4;
            this.wizardPageSearchDirection.Text = "Search Direction";
            this.wizardPageSearchDirection.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPageSearchDirection_Commit);
            // 
            // labelSearchDirection
            // 
            this.labelSearchDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSearchDirection.Location = new System.Drawing.Point(0, 207);
            this.labelSearchDirection.Name = "labelSearchDirection";
            this.labelSearchDirection.Size = new System.Drawing.Size(660, 89);
            this.labelSearchDirection.TabIndex = 2;
            this.labelSearchDirection.Text = "asd";
            // 
            // radioButtonSearchDirectionTopDown
            // 
            this.radioButtonSearchDirectionTopDown.Image = global::AdvancedSqlServerDependencies.Properties.Resources._112_DownArrowLong_Blue_32x32_72;
            this.radioButtonSearchDirectionTopDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButtonSearchDirectionTopDown.Location = new System.Drawing.Point(0, 0);
            this.radioButtonSearchDirectionTopDown.Name = "radioButtonSearchDirectionTopDown";
            this.radioButtonSearchDirectionTopDown.Size = new System.Drawing.Size(481, 62);
            this.radioButtonSearchDirectionTopDown.TabIndex = 2;
            this.radioButtonSearchDirectionTopDown.TabStop = true;
            this.radioButtonSearchDirectionTopDown.Text = "Objects on which searched object depends on (Top - Down)";
            this.radioButtonSearchDirectionTopDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonSearchDirectionTopDown.UseVisualStyleBackColor = true;
            this.radioButtonSearchDirectionTopDown.CheckedChanged += new System.EventHandler(this.radioButtonSearchDirectionTopDown_CheckedChanged);
            // 
            // radioButtonSearchDirectionBottomUp
            // 
            this.radioButtonSearchDirectionBottomUp.Image = global::AdvancedSqlServerDependencies.Properties.Resources._112_UpArrowLong_Orange_32x42_72;
            this.radioButtonSearchDirectionBottomUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButtonSearchDirectionBottomUp.Location = new System.Drawing.Point(0, 68);
            this.radioButtonSearchDirectionBottomUp.Name = "radioButtonSearchDirectionBottomUp";
            this.radioButtonSearchDirectionBottomUp.Size = new System.Drawing.Size(428, 69);
            this.radioButtonSearchDirectionBottomUp.TabIndex = 3;
            this.radioButtonSearchDirectionBottomUp.TabStop = true;
            this.radioButtonSearchDirectionBottomUp.Text = "Objects that depend on searched object (Bottom - Up)";
            this.radioButtonSearchDirectionBottomUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonSearchDirectionBottomUp.UseVisualStyleBackColor = true;
            this.radioButtonSearchDirectionBottomUp.CheckedChanged += new System.EventHandler(this.radioButtonSearchDirectionBottomUp_CheckedChanged);
            // 
            // wizardPageInternalDatabaseRefresh
            // 
            this.wizardPageInternalDatabaseRefresh.Controls.Add(this.pictureBox1);
            this.wizardPageInternalDatabaseRefresh.Controls.Add(this.labelInternalDatabaseRefreshMessage);
            this.wizardPageInternalDatabaseRefresh.Controls.Add(this.checkBoxInternalDatabaseRefresh);
            this.wizardPageInternalDatabaseRefresh.Name = "wizardPageInternalDatabaseRefresh";
            this.wizardPageInternalDatabaseRefresh.Size = new System.Drawing.Size(661, 296);
            this.wizardPageInternalDatabaseRefresh.TabIndex = 5;
            this.wizardPageInternalDatabaseRefresh.Text = "Internal Database Refresh";
            this.wizardPageInternalDatabaseRefresh.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPageInternalDatabaseRefresh_Commit);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdvancedSqlServerDependencies.Properties.Resources.StatusAnnotations_Warning_32xLG_color;
            this.pictureBox1.Location = new System.Drawing.Point(22, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelInternalDatabaseRefreshMessage
            // 
            this.labelInternalDatabaseRefreshMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInternalDatabaseRefreshMessage.Location = new System.Drawing.Point(0, 207);
            this.labelInternalDatabaseRefreshMessage.Name = "labelInternalDatabaseRefreshMessage";
            this.labelInternalDatabaseRefreshMessage.Size = new System.Drawing.Size(660, 93);
            this.labelInternalDatabaseRefreshMessage.TabIndex = 2;
            this.labelInternalDatabaseRefreshMessage.Text = resources.GetString("labelInternalDatabaseRefreshMessage.Text");
            // 
            // checkBoxInternalDatabaseRefresh
            // 
            this.checkBoxInternalDatabaseRefresh.AutoSize = true;
            this.checkBoxInternalDatabaseRefresh.Location = new System.Drawing.Point(82, 33);
            this.checkBoxInternalDatabaseRefresh.Name = "checkBoxInternalDatabaseRefresh";
            this.checkBoxInternalDatabaseRefresh.Size = new System.Drawing.Size(144, 19);
            this.checkBoxInternalDatabaseRefresh.TabIndex = 2;
            this.checkBoxInternalDatabaseRefresh.Text = "Refresh Internal Cache";
            this.checkBoxInternalDatabaseRefresh.UseVisualStyleBackColor = true;
            // 
            // wizardPageSummary
            // 
            this.wizardPageSummary.Controls.Add(this.richTextBoxSummary);
            this.wizardPageSummary.Name = "wizardPageSummary";
            this.wizardPageSummary.Size = new System.Drawing.Size(661, 296);
            this.wizardPageSummary.TabIndex = 6;
            this.wizardPageSummary.Text = "Dependency Check Summary";
            this.wizardPageSummary.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.wizardPageSummary_Initialize);
            // 
            // richTextBoxSummary
            // 
            this.richTextBoxSummary.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSummary.Name = "richTextBoxSummary";
            this.richTextBoxSummary.ReadOnly = true;
            this.richTextBoxSummary.Size = new System.Drawing.Size(655, 290);
            this.richTextBoxSummary.TabIndex = 2;
            this.richTextBoxSummary.Text = "";
            // 
            // NewDependencyCheckWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.wizardControl1);
            this.Name = "NewDependencyCheckWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Dependency Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPageWelcome.ResumeLayout(false);
            this.wizardPageWelcome.PerformLayout();
            this.wizardPageObjectName.ResumeLayout(false);
            this.wizardPageObjectName.PerformLayout();
            this.wizardPageObjectType.ResumeLayout(false);
            this.wizardPageDatabases.ResumeLayout(false);
            this.wizardPageSearchDirection.ResumeLayout(false);
            this.wizardPageInternalDatabaseRefresh.ResumeLayout(false);
            this.wizardPageInternalDatabaseRefresh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wizardPageSummary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage wizardPageObjectName;
        private AeroWizard.WizardPage wizardPageObjectType;
        private AeroWizard.WizardPage wizardPageDatabases;
        private AeroWizard.WizardPage wizardPageWelcome;
        private Components.Watermark.CueComboBox cueComboBoxObjectName;
        private System.Windows.Forms.RadioButton radioButtonObjectNameContains;
        private System.Windows.Forms.RadioButton radioButtonObjectNameStartsWith;
        private System.Windows.Forms.RadioButton radioButtonObjectNameEndsWith;
        private System.Windows.Forms.RadioButton radioButtonObjectNameEquals;
        private System.Windows.Forms.CheckBox checkBoxDoNotShowWelcomePage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelObjectNameMessage;
        private AeroWizard.WizardPage wizardPageSearchDirection;
        private System.Windows.Forms.RadioButton radioButtonSearchDirectionTopDown;
        private System.Windows.Forms.RadioButton radioButtonSearchDirectionBottomUp;
        private System.Windows.Forms.Label labelSearchDirection;
        private System.Windows.Forms.CheckedListBox checkedListBoxObjectTypes;
        private System.Windows.Forms.Label labelObjectTypeMessage;
        private System.Windows.Forms.Button buttonCheckAllObjectTypes;
        private System.Windows.Forms.Button buttonUncheckAllObjectTypes;
        private AeroWizard.WizardPage wizardPageInternalDatabaseRefresh;
        private System.Windows.Forms.CheckBox checkBoxInternalDatabaseRefresh;
        private System.Windows.Forms.Label labelInternalDatabaseRefreshMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AeroWizard.WizardPage wizardPageSummary;
        private System.Windows.Forms.RichTextBox richTextBoxSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBoxDatabasesToSearch;
        private System.Windows.Forms.Label labelDatabasesMessage;
        private System.Windows.Forms.Button buttonUncheckAllDatabases;
        private System.Windows.Forms.Button buttonCheckAllDatabases;
        private System.Windows.Forms.Label label4;
    }
}