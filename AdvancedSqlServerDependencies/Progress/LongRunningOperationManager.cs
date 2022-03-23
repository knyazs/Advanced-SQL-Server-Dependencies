using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AdvancedSqlServerDependencies.Forms;

namespace AdvancedSqlServerDependencies.Progress
{
    public static class LongRunningOperationManager
    {
        public static readonly List<LongRunningOperation> LongRunningOperationsList = new List<LongRunningOperation>();
        private static BackgroundWorker _worker;
        private static readonly ProgressForm _progressForm = new ProgressForm();
        private static int _currentStep = -1;

        //EV
        public static event DoWorkEventHandler DoWork;
        public static event RunWorkerCompletedEventHandler WorkCompleted;

        public delegate void CancelWorkerEventHandler();
        public static event CancelWorkerEventHandler WorkerPreCancel;
        public static event CancelWorkerEventHandler WorkerPostCancel;

        public static object ProcessResult;

        //public delegate void StepChangedEventHandler();
        //public event StepChangedEventHandler OnStepChanged;

        //

        private static LongRunningOperation CurrentLongRunningOperation
        {
            get
            {
                return LongRunningOperationsList.FirstOrDefault(l => l.State == EProgressState.Running);
            }
        }

        public static bool IsBusy
        {
            get { return (_worker != null && _worker.IsBusy); }
        }

        public static bool CancellationPending
        { get { return _worker.CancellationPending; } }

        public static void NewOperationBatch(bool reportsProgress, bool supportsCancellation, LongRunningOperation[] longRunningOperations)
        {
            LongRunningOperationsList.Clear();
            LongRunningOperationsList.AddRange(longRunningOperations);
            if (LongRunningOperationsList.Sum(l => l.Weight) != 1.0)
            {
                foreach (LongRunningOperation longRunningOperation in LongRunningOperationsList)
                {
                    longRunningOperation.Weight = -1;
                }
            }

            DoWork = null;
            WorkCompleted = null;

            if (_worker != null)
                _worker.Dispose();

            _progressForm.buttonCancel.Enabled = supportsCancellation;

            _currentStep = -1;

            _worker = new BackgroundWorker
            {
                WorkerReportsProgress = reportsProgress,
                WorkerSupportsCancellation = supportsCancellation
            };

            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }

        static void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                ProcessResult = e.Result;
            else
                ProcessResult = null;
            _progressForm.Hide();
        }

        static void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (CurrentLongRunningOperation == null)
                throw new NotImplementedException();
            else
                CurrentLongRunningOperation.ProgressPercentage = e.ProgressPercentage;
        }

        //private static void addOperation(string operationName, double weightPct)
        //{
        //    var lro = new LongRunningOperation(operationName, weightPct);
        //    LongRunningOperationsList.Add(lro);
        //}

        public static void StartNextStep()
        {
            _currentStep++;

            if (_currentStep - 1 >= 0)
            {
                ReportProgress(100);
                LongRunningOperationsList[_currentStep - 1].State = EProgressState.Finished;
                _progressForm.Update(LongRunningOperationsList[_currentStep - 1]);
            }
            LongRunningOperationsList[_currentStep].State = EProgressState.Running;
            _progressForm.Update(LongRunningOperationsList[_currentStep]);
        }

        public static void RunAsync(object argument)
        {
            if (!_worker.IsBusy)
            {
                _progressForm.Initialize2(LongRunningOperationsList);

                _worker.DoWork += DoWork;
                _worker.RunWorkerCompleted += WorkCompleted;

                if (argument != null)
                    _worker.RunWorkerAsync(argument);
                else
                    _worker.RunWorkerAsync();

                _progressForm.ShowDialog();
            }
        }

        public static void RunAsync()
        {
            RunAsync(null);
        }

        public static void ReportProgress(int progressPercentage)
        {
            if (_worker.WorkerReportsProgress && _worker.IsBusy)
            {
                _worker.ReportProgress(Convert.ToInt32(progressPercentage));
                _progressForm.Update(CurrentLongRunningOperation);
            }
        }

        public static void CancelAsync()
        {
            if (_worker.WorkerSupportsCancellation && _worker.IsBusy)
            {
                if (WorkerPreCancel != null)
                    WorkerPreCancel();

                _worker.CancelAsync();

                if (WorkerPostCancel != null)
                    WorkerPostCancel();
            }
        }
    }


}
