using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.Properties;
using AeroWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class NewDependencyCheckWizard : Form
    {
        private MySqlDatabase[] _checkedSqlDatabases;
        private bool _allObjectTypesChecked;

        public EMatchMethod MatchMethod
        {
            get
            {
                return (EMatchMethod)Enum.Parse(typeof(EMatchMethod), AppSettings.Default.ObjectMatchMethod);
            }
        }

        public string ObjectName
        { get { return cueComboBoxObjectName.Text; } }

        public string[] ObjectTypes
        {
            get
            {
                List<string> _objectTypes = new List<string>();

                for (int i = 0; i < checkedListBoxObjectTypes.Items.Count; i++)
                {
                    if (checkedListBoxObjectTypes.GetItemCheckState(i) == CheckState.Checked)
                    {
                        var txt = checkedListBoxObjectTypes.Items[i].ToString();
                        _objectTypes.Add(txt.Substring(txt.LastIndexOf('[') + 1, txt.Length - txt.LastIndexOf('[') - 2));
                    }
                }

                if (_allObjectTypesChecked)
                    return null;
                else
                    return _objectTypes.ToArray();
            }
        }

        public bool IsTopDownDiscovery
        {
            get
            {
                return radioButtonSearchDirectionTopDown.Checked;
            }
        }

        public bool IsForceReload
        {
            get { return checkBoxInternalDatabaseRefresh.Checked; }
        }

        public string SearchObjectFullDescription
        {
            get
            {
                string s = string.Empty;
                if (string.IsNullOrEmpty(cueComboBoxObjectName.Text))
                {
                    s = "All Objects";
                }
                else
                {
                    switch (MatchMethod)
                    {
                        case EMatchMethod.Contains: s = string.Format("Objects where name contains '{1}'", MatchMethod.ToString(), cueComboBoxObjectName.Text); break;
                        case EMatchMethod.StartsWith: s = string.Format("Objects where name starts with '{1}'", MatchMethod.ToString(), cueComboBoxObjectName.Text); break;
                        case EMatchMethod.EndsWith: s = string.Format("Objects where name ends with '{1}'", MatchMethod.ToString(), cueComboBoxObjectName.Text); break;
                        case EMatchMethod.Equals: s = string.Format("Object where name equals to '{1}'", MatchMethod.ToString(), cueComboBoxObjectName.Text); break;
                        //default: return string.Format("%{1}%", MatchMethod.ToString(), comboBox1.Text); break;
                    }
                }

                if (this.ObjectTypes != null)
                {
                    if (this.ObjectTypes.Length == 1)
                        s += " of type ";
                    else
                        s += " of types ";
                    s += ("[" + string.Join(",", this.ObjectTypes) + "]");
                }

                if (this.SearchDatabases != null)
                {
                    if (this.SearchDatabases.Length == 1)
                        s += " in database ";
                    else
                        s += " in databases ";
                    s += ("[" + string.Join(",", this.SearchDatabases.Select(d => d.DatabaseName)) + "]");
                }

                return s;
            }
        }


        public MySqlDatabase[] SearchDatabases
        {
            get
            {
                List<MySqlDatabase> mdb = new List<MySqlDatabase>();
                foreach (var d in checkedListBoxDatabasesToSearch.CheckedItems)
                {
                    mdb.Add((MySqlDatabase)d);
                }

                if (mdb.Count == checkedListBoxDatabasesToSearch.Items.Count)
                    return null;

                return mdb.ToArray();
            }
        }




        public NewDependencyCheckWizard(MySqlDatabase[] checkedSqlDatabases)
        {
            InitializeComponent();

            this._checkedSqlDatabases = checkedSqlDatabases;
            wizardPageWelcome.Suppress = AppSettings.Default.SuppressWelcomePage;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.Default.SuppressWelcomePage = checkBoxDoNotShowWelcomePage.Checked;
            AppSettings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cueComboBoxObjectName.Items.AddRange(AppSettings.Default.LastSearches.Split(';'));
            if (cueComboBoxObjectName.Items.Count > 0)
                cueComboBoxObjectName.Text = cueComboBoxObjectName.Items[0].ToString();

            EMatchMethod mm = (EMatchMethod)Enum.Parse(typeof(EMatchMethod), AppSettings.Default.ObjectMatchMethod);
            switch (mm)
            {
                case EMatchMethod.Contains: radioButtonObjectNameContains.Checked = true; break;
                case EMatchMethod.StartsWith: radioButtonObjectNameStartsWith.Checked = true; break;
                case EMatchMethod.EndsWith: radioButtonObjectNameEndsWith.Checked = true; break;
                case EMatchMethod.Equals: radioButtonObjectNameEquals.Checked = true; break;
            }


            radioButtonSearchDirectionTopDown.Checked = AppSettings.Default.DependencySearchDirectionTopDown;
            radioButtonSearchDirectionBottomUp.Checked = !AppSettings.Default.DependencySearchDirectionTopDown;
            /*

            cbxDbObjectsForceReload.Checked = AppSettings.Default.ForceObjectAndDependencyReload;
*/

            checkedListBoxObjectTypes.Items.Clear();
            checkedListBoxObjectTypes.Items.Add("Aggregate function (CLR) [AF]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Assembly (CLR) DML trigger [TA]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Assembly (CLR) scalar-function [FS]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Assembly (CLR) stored-procedure [PC]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Assembly (CLR) table-valued function [FT]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("CHECK constraint [C]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("DEFAULT (constraint or stand-alone) [D]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Extended stored procedure [X]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("External Table [ET]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("FOREIGN KEY constraint [F]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Internal table [IT]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Plan guide [PG]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("PRIMARY KEY constraint [PK]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Replication-filter-procedure [RF]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Rule (old-style, stand-alone) [R]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Sequence object [SO]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Service queue [SQ]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("SQL DML trigger [TR]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("SQL inline table-valued function [IF]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("SQL scalar function [FN]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("SQL Stored Procedure [P]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("SQL table-valued-function [TF]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Synonym [SN]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("System base table [S]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Table (user-defined) [U]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("Table type [TT]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("UNIQUE constraint [UQ]", CheckState.Checked);
            checkedListBoxObjectTypes.Items.Add("View [V]", CheckState.Checked);

            if (!string.IsNullOrEmpty(AppSettings.Default.LastObjectTypes))
            {

                string[] objectTypez = AppSettings.Default.LastObjectTypes.Split(',').ToArray();

                for (int i = 0; i < checkedListBoxObjectTypes.Items.Count; i++)
                {
                    checkedListBoxObjectTypes.SetItemChecked(i, false);

                    foreach (string objectType in objectTypez)
                    {
                        if (checkedListBoxObjectTypes.Items[i].ToString().Contains("[" + objectType + "]"))
                        {
                            checkedListBoxObjectTypes.SetItemChecked(i, true);
                            break;
                        }
                    }
                }

            }


            //
            checkedListBoxDatabasesToSearch.Items.Clear();
            foreach (var db in this._checkedSqlDatabases)
            {
                checkedListBoxDatabasesToSearch.Items.Add(db, true);
            }
        }

        private void cueComboBoxObjectName_TextUpdate(object sender, EventArgs e)
        {
            setLabelObjectNameMessage();

            label2.Enabled
                = radioButtonObjectNameContains.Enabled
                = radioButtonObjectNameStartsWith.Enabled
                = radioButtonObjectNameEndsWith.Enabled
                = radioButtonObjectNameEquals.Enabled
                = !string.IsNullOrEmpty(cueComboBoxObjectName.Text);
        }

        private void setLabelObjectNameMessage()
        {
            if (string.IsNullOrEmpty(cueComboBoxObjectName.Text))
            {
                labelObjectNameMessage.Text = "No filter will be applied on object name.";
            }
            else
            {
                labelObjectNameMessage.Text = "Objects ";
                if (radioButtonObjectNameContains.Checked)
                    labelObjectNameMessage.Text += "containing ";
                else if (radioButtonObjectNameStartsWith.Checked)
                    labelObjectNameMessage.Text += "starting with ";
                else if (radioButtonObjectNameEndsWith.Checked)
                    labelObjectNameMessage.Text += "ending with ";
                else if (radioButtonObjectNameEquals.Checked)
                    labelObjectNameMessage.Text += "equals to ";

                labelObjectNameMessage.Text += string.Format("'{0}' will be checked for dependencies.", cueComboBoxObjectName.Text);
                labelObjectNameMessage.Text += Environment.NewLine + "Unrelated to your SQL Server settings, application will conduct case insensitive search.";
            }
        }

        private void radioButtonObjectNameContains_CheckedChanged(object sender, EventArgs e)
        {
            setLabelObjectNameMessage();
        }

        private void radioButtonObjectNameStartsWith_CheckedChanged(object sender, EventArgs e)
        {
            setLabelObjectNameMessage();
        }

        private void radioButtonObjectNameEndsWith_CheckedChanged(object sender, EventArgs e)
        {
            setLabelObjectNameMessage();
        }

        private void radioButtonObjectNameEquals_CheckedChanged(object sender, EventArgs e)
        {
            setLabelObjectNameMessage();
        }

        private void radioButtonSearchDirectionTopDown_CheckedChanged(object sender, EventArgs e)
        {
            labelSearchDirection.Text = @"This option will list all objects on which searched object depends on.
For example, if you are looking for certain stored procedure, this option will list all objects (tables, views, synonyms, procedures, etc.) used inside searched procedure.";
        }

        private void radioButtonSearchDirectionBottomUp_CheckedChanged(object sender, EventArgs e)
        {
            labelSearchDirection.Text = @"This option will list all objects which depend on searched object.
For example, if you are looking for certain table, this option will list all objects (views, synonyms, procedures, etc.) where searched table can be found.";
        }

        private void buttonCheckAllObjectTypes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxObjectTypes.Items.Count; i++)
                checkedListBoxObjectTypes.SetItemChecked(i, true);
        }

        private void buttonUncheckAllObjectTypes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxObjectTypes.Items.Count; i++)
                checkedListBoxObjectTypes.SetItemChecked(i, false);
        }

        private void checkedListBoxObjectTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int totalItemCount = checkedListBoxObjectTypes.Items.Count;
            int checkedItemCount = checkedListBoxObjectTypes.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked)
                checkedItemCount++;
            if (e.NewValue == CheckState.Unchecked)
                checkedItemCount--;

            _allObjectTypesChecked = (checkedItemCount == totalItemCount) ? true : false;


            if (_allObjectTypesChecked)
                labelObjectTypeMessage.Text = "All object types selected.";
            else if (checkedItemCount == 0)
                labelObjectTypeMessage.Text = "No object types selected.";
            else
            {
                string qwe = "";
                for (int k = 0; k < checkedListBoxObjectTypes.Items.Count; k++)
                {
                    if ((k == e.Index && e.NewValue == CheckState.Checked) || (k != e.Index && checkedListBoxObjectTypes.GetItemChecked(k)))
                    {
                        if (qwe.Length > 0)
                            qwe += ", ";
                        qwe += checkedListBoxObjectTypes.Items[k].ToString();
                    }
                }
                labelObjectTypeMessage.Text = string.Format("{0} object types selected:{1}{2}", checkedItemCount, Environment.NewLine, qwe);
            }

            wizardPageObjectType.AllowNext = checkedItemCount > 0;
            //btnViewDependencies.Enabled = checkedItemCount > 0;
        }

        private void wizardPageSummary_Initialize(object sender, WizardPageInitEventArgs e)
        {
            string s;

            //var s = string.Format(@"\rtf1\ansi \b {0}\b0  {1}", ObjectName, ObjectNameFull);
            //return "{" + s + "}";

            // Object name 
            s = @"\rtf1\ansi \b Object name \b0 \line ";
            s += labelObjectNameMessage.Text + @" \line";

            // Object Types
            s += @"\line \b Object types \b0";
            if (_allObjectTypesChecked)
            {
                s += @"\line All object types will be searched for dependencies.";
            }
            else
            {
                for (int i = 0; i < checkedListBoxObjectTypes.Items.Count; i++)
                {
                    if (checkedListBoxObjectTypes.GetItemChecked(i))
                    {
                        s += @"\line " + checkedListBoxObjectTypes.Items[i].ToString();
                    }
                }
            }

            // Search direction
            s += @"\line \line \b Search direction \b0 \line ";
            if (radioButtonSearchDirectionTopDown.Checked)
                s += "Top - Down. ";
            else
                s += "Bottom - Up. ";
            s += labelSearchDirection.Text + @" \line";


            // Internal database refresh
            s += @"\line \b Internal database refresh \b0 \line ";
            if (checkBoxInternalDatabaseRefresh.Checked)
                s += "Internal database will be refreshed before searching for dependencies." + @" \line";
            else
                s += "Internal database will NOT be refreshed before searching for dependencies." + @" \line";


            richTextBoxSummary.Rtf = "{" + s + "}";
        }

        private void wizardControl1_Finished(object sender, EventArgs e)
        {
            //if(this.ObjectTypes!=null)
            //    saveSearch(cueComboBoxObjectName.Text, string.Join(",", this.ObjectTypes));
            //else
            //    saveSearch(cueComboBoxObjectName.Text, null);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void wizardPageObjectName_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            List<string> lastSearches = new List<string>();
            lastSearches.AddRange(AppSettings.Default.LastSearches.Split(';'));
            if (lastSearches.Contains(cueComboBoxObjectName.Text))
            {
                int idx = lastSearches.IndexOf(cueComboBoxObjectName.Text);
                string temp = lastSearches[0];
                lastSearches.Insert(0, lastSearches[idx]);
                lastSearches.RemoveAt(idx + 1);

                cueComboBoxObjectName.Items.Clear();
                cueComboBoxObjectName.Items.AddRange(lastSearches.ToArray());
            }
            else
            {
                cueComboBoxObjectName.Items.Insert(0, cueComboBoxObjectName.Text);
                lastSearches.Insert(0, cueComboBoxObjectName.Text);
            }

            AppSettings.Default.LastSearches = string.Join(";", lastSearches.ToArray());

            //

            if (radioButtonObjectNameContains.Checked)
                AppSettings.Default.ObjectMatchMethod = EMatchMethod.Contains.ToString();
            else if (radioButtonObjectNameStartsWith.Checked)
                AppSettings.Default.ObjectMatchMethod = EMatchMethod.StartsWith.ToString();
            else if (radioButtonObjectNameEndsWith.Checked)
                AppSettings.Default.ObjectMatchMethod = EMatchMethod.EndsWith.ToString();
            else if (radioButtonObjectNameEquals.Checked)
                AppSettings.Default.ObjectMatchMethod = EMatchMethod.Equals.ToString();


            //
            AppSettings.Default.Save();
        }

        private void wizardPageObjectType_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            if (this.ObjectTypes == null)
                AppSettings.Default.LastObjectTypes = null;
            else
                AppSettings.Default.LastObjectTypes = string.Join(",", this.ObjectTypes);

            AppSettings.Default.Save();
        }

        private void wizardPageSearchDirection_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            AppSettings.Default.DependencySearchDirectionTopDown = radioButtonSearchDirectionTopDown.Checked;
            AppSettings.Default.Save();
        }

        private void wizardPageInternalDatabaseRefresh_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            AppSettings.Default.ForceObjectAndDependencyReload = checkBoxInternalDatabaseRefresh.Checked;
            AppSettings.Default.Save();
        }

        private void wizardPageWelcome_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            AppSettings.Default.SuppressWelcomePage = checkBoxDoNotShowWelcomePage.Checked;
            AppSettings.Default.Save();
        }

        private void buttonCheckAllDatabases_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxDatabasesToSearch.Items.Count; i++)
                checkedListBoxDatabasesToSearch.SetItemChecked(i, true);
        }

        private void buttonUncheckAllDatabases_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxDatabasesToSearch.Items.Count; i++)
                checkedListBoxDatabasesToSearch.SetItemChecked(i, false);
        }

        private void checkedListBoxDatabasesToSearch_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkedItemCount = checkedListBoxDatabasesToSearch.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked)
                checkedItemCount++;
            if (e.NewValue == CheckState.Unchecked)
                checkedItemCount--;

            wizardPageDatabases.AllowNext = checkedItemCount > 0;
        }
    }

    public enum EMatchMethod
    {
        Contains,
        StartsWith,
        EndsWith,
        Equals
    }
}
