using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Progress;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class ProgressForm : Form
    {
        delegate void SetProgressBarProgressPercentageCallback(ProgressBar progressBar, int progressPercentage);
        delegate void SetProgressBarStyleCallback(ProgressBar progressBar, ProgressBarStyle progressBarStyle);

        private DateTime _dateTime;

        public ProgressForm()
        {
            InitializeComponent();

            //olvColumnOperationName.ImageGetter = delegate(object x)
            //{
            //    return ((LongRunningOperation)x).Image;
            //};
            olvColumnOperationName.ImageGetter = x => ((LongRunningOperation) x).Image;
        }

        public void Initialize2(IEnumerable<LongRunningOperation> longRunningOperations)
        {
            objectListView1.SetObjects(longRunningOperations);

            flowLayoutPanel1.Controls.Clear();
            foreach (LongRunningOperation longRunningOperation in longRunningOperations)
            {
                var pb = new ProgressBar
                {
                    Height = flowLayoutPanel1.Height - flowLayoutPanel1.Padding.All * 2,
                    Padding = new Padding(0, 0, 0, 0),
                    Margin = new Padding(0, 0, 0, 0),
                    Text = longRunningOperation.OperationName,
                    Tag = longRunningOperation.Weight,
                    Width = (int)(flowLayoutPanel1.Width * ((longRunningOperation.Weight != -1.0) ? longRunningOperation.Weight : (1.0 / longRunningOperations.Count()))),
                };

                //flowLayoutPanel1.Controls.Add(l);
                flowLayoutPanel1.Controls.Add(pb);
                //this.Refresh();
            }
            flowLayoutPanel1.Refresh();

            buttonCancel.Text = "Cancel";
        }

        public void Update(LongRunningOperation longRunningOperation)
        {
            objectListView1.UpdateObject(longRunningOperation);

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                ProgressBar pb = (ProgressBar) control;
                if (pb.Text.Equals(longRunningOperation.OperationName, StringComparison.InvariantCultureIgnoreCase))
                {
                    setProgress(pb, longRunningOperation.ProgressPercentage);
                }
            }
        }

        private void setProgress(ProgressBar progressBar, int progressPercentage)
        {

            if (progressPercentage >= 0)
                {
                    if (progressBar.Style != ProgressBarStyle.Blocks)
                        setProgressBarStyleThreadSafe(progressBar, ProgressBarStyle.Blocks);
                    setProgressBarProcessPercentageThreadSafe(progressBar, progressPercentage);
                }
                else
                {
                    if (progressBar.Style != ProgressBarStyle.Marquee)
                        setProgressBarStyleThreadSafe(progressBar, ProgressBarStyle.Marquee);
                }
            
        }

        private void setProgressBarProcessPercentageThreadSafe(ProgressBar progressBar, int progressPercentage)
        {
            if (progressBar.InvokeRequired)
            {
                SetProgressBarProgressPercentageCallback d = setProgressBarProcessPercentageThreadSafe;
                this.Invoke(d, progressBar, progressPercentage);
            }
            else
            {
                progressBar.Value = Convert.ToInt32(progressPercentage);
            }
        }

        private void setProgressBarStyleThreadSafe(ProgressBar progressBar, ProgressBarStyle progressBarStyle)
        {
            if (progressBar.InvokeRequired)
            {
                SetProgressBarStyleCallback d = setProgressBarStyleThreadSafe;
                this.Invoke(d, progressBar, progressBarStyle);
            }
            else
            {
                progressBar.Style = progressBarStyle;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = false;
            buttonCancel.Text = "Cancelling...";
            LongRunningOperationManager.CancelAsync();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimeElapsed.Text = (DateTime.Now - this._dateTime).ToString(@"mm\:ss");
        }

        private void ProgressForm_VisibleChanged(object sender, EventArgs e)
        {
            //base.OnVisibleChanged(sender, e);

            timer1.Enabled = this.Visible;

            if (this.Visible)
                _dateTime = DateTime.Now;
        }

        
    }
}
