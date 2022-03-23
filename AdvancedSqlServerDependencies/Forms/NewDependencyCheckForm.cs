using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class NewDependencyCheckForm : Form
    {
        public EMatchMethod MatchMethod
        {
            get
            {
                return EMatchMethod.Contains; // (EMatchMethod)Enum.Parse(typeof(EMatchMethod), AppSettings.Default.ObjectMatchMethod);
            }
        }

        public string ObjectName
        { get { return comboBox1.Text; } }


        public bool IsTopDownDiscovery
        {
            get
            {
                return rbDependencySearchTopDown.Checked;
            }
        }

        public string SearchObjectFullDescription
        {
            get
            {
                string s = string.Empty;
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    s = "All Objects";
                }
                else
                {
                    switch (MatchMethod)
                    {
                        case EMatchMethod.Contains: s = string.Format("Objects where name contains '{1}'", MatchMethod.ToString(), comboBox1.Text); break;
                        case EMatchMethod.StartsWith: s = string.Format("Objects where name starts with '{1}'", MatchMethod.ToString(), comboBox1.Text); break;
                        case EMatchMethod.EndsWith: s = string.Format("Objects where name ends with '{1}'", MatchMethod.ToString(), comboBox1.Text); break;
                        case EMatchMethod.Equals: s = string.Format("Object where name equals to '{1}'", MatchMethod.ToString(), comboBox1.Text); break;
                        //default: return string.Format("%{1}%", MatchMethod.ToString(), comboBox1.Text); break;
                    }
                }

                return s;
            }
        }

        public NewDependencyCheckForm()
        {
            InitializeComponent();
        }

        private void NewDependencyCheckForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(AppSettings.Default.LastSearches.Split(';'));
            if (comboBox1.Items.Count > 0)
                comboBox1.Text = comboBox1.Items[0].ToString();

            rbDependencySearchTopDown.Checked = AppSettings.Default.DependencySearchDirectionTopDown;
            rbDependencySearchBottomUp.Checked = !AppSettings.Default.DependencySearchDirectionTopDown;
        }

        private void searchObjectTextChanged(object sender, EventArgs e)
        {
            //btnViewDependencies.Enabled = comboBox1.Text.Length > 0;
        }

        private void saveSearch(string searchString)
        {
            List<string> lastSearches = new List<string>();
            lastSearches.AddRange(AppSettings.Default.LastSearches.Split(';'));
            if (lastSearches.Contains(searchString))
            {
                int idx = lastSearches.IndexOf(searchString);
                string temp = lastSearches[0];
                lastSearches.Insert(0, lastSearches[idx]);
                lastSearches.RemoveAt(idx + 1);

                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(lastSearches.ToArray());
            }
            else
            {
                comboBox1.Items.Insert(0, searchString);
                lastSearches.Insert(0, searchString);
            }
            //AppSettings.Default.LastSearches = string.Join(";", lastSearches.Where(x => !string.IsNullOrEmpty(x)).ToArray());
            AppSettings.Default.LastSearches = string.Join(";", lastSearches.ToArray());

            AppSettings.Default.Save();
        }

        private void rbTopDownDependencySearch_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Default.DependencySearchDirectionTopDown = rbDependencySearchTopDown.Checked;
            AppSettings.Default.Save();
        }

        //private void cbxDbObjectsForceReload_CheckedChanged(object sender, EventArgs e)
        //{
        //    AppSettings.Default.ForceObjectAndDependencyReload = cbxDbObjectsForceReload.Checked;
        //    AppSettings.Default.Save();
        //}

        private void btnViewDependencies_Click(object sender, EventArgs e)
        {
            saveSearch(comboBox1.Text);
        }
    }
}
