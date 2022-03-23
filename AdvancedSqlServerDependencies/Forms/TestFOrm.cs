using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Progress;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class TestFOrm : Form
    {
        private BackgroundWorker _bw;
        public TestFOrm()
        {
            InitializeComponent();
            _bw = new BackgroundWorker();
        }

        private void TestFOrm_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LongRunningOperationManager.NewOperationBatch(true, true, new [] {new LongRunningOperation("a", 0.6), new LongRunningOperation("b", 0.3), new LongRunningOperation("c", 0.1)});

            LongRunningOperationManager.DoWork += LongRunningOperationManager_DoWork;

            LongRunningOperationManager.RunAsync();            
        }

        void LongRunningOperationManager_DoWork(object sender, DoWorkEventArgs e)
        {
            LongRunningOperationManager.StartNextStep();
            for (int i = 0; i < 100; i++)
            {
                LongRunningOperationManager.ReportProgress(i+1);
                Thread.Sleep(100);

                //if (LongRunningOperationManager.CancellationPending)
                //{
                //    e.Cancel = true;
                //    return;
                //}
            }

            
            LongRunningOperationManager.StartNextStep();
            for (int i = 0; i < 100; i++)
            {
                LongRunningOperationManager.ReportProgress(i + 1);
                Thread.Sleep(50);

                if (LongRunningOperationManager.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //LongRunningOperationManager.ReportProgress(100);

            LongRunningOperationManager.StartNextStep();
            for (int i = 0; i < 100; i++)
            {
                LongRunningOperationManager.ReportProgress(i + 1);
                Thread.Sleep(20);

                if (LongRunningOperationManager.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
