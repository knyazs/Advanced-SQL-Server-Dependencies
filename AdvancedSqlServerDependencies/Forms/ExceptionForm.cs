using System;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;
using System.Diagnostics;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class ExceptionForm : Form
    {
        private bool _detailsVisible;

        public ExceptionForm(Exception e)
        {
            InitializeComponent();

            this.Height = 220;
            _detailsVisible = false;

            textBoxExceptionMessage.Text = e.Message;
            textBoxExceptionDetails.Text = e.StackTrace;
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if(!_detailsVisible)
            {
                this.Height = 420;
                _detailsVisible = true;
                buttonDetails.Image = Resources.arrow_Up_16xSM;
                toolTip1.SetToolTip(this.buttonDetails, "Hide exception details");
                textBoxExceptionDetails.Visible = true;
            }
            else
            {
                this.Height = 220;
                _detailsVisible = false;
                buttonDetails.Image = Resources.arrow_Down_16xSM;
                toolTip1.SetToolTip(this.buttonDetails, "Show exception details");
                textBoxExceptionDetails.Visible = false;
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEmailError_Click(object sender, EventArgs e)
        {
            //Process.Start(String.Format("mailto:{0}?subject={1}&body=Exception: {2}{3}{3}{4}", "miljan.radovic@outlook.com", "ASSD Exception Occured", textBoxExceptionMessage.Text, Environment.NewLine, textBoxExceptionDetails.Text));

            Process.Start("https://advancedsqlserverdependencies.codeplex.com/workitem/list/basic");
        }
    }
}
