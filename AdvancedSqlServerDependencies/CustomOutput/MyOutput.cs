using AdvancedSqlServerDependencies.DockForms;
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AdvancedSqlServerDependencies.CustomOutput
{
    public static class MyOutput
    {
        private static bool _isInitialized = false;
        private static OutputDockForm _outputDockForm;
        
        private static List<MyOutputMessage> _outputMessageList = new List<MyOutputMessage>();

        public static void NewMessage(EOutputMessageType outputMessageType, string outputMessageText, bool displayMessageBox = false, double durationSec = -1)
        {
            if (!_isInitialized)
                MessageBox.Show("Custom output not initialized properly! Use MyOutput.Initialize(...) in code.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                _outputMessageList.Add(new MyOutputMessage { OutputMessageType = outputMessageType, OutputMessageTimestamp = DateTime.Now, OutputMessageDescription = outputMessageText, DurationSec = durationSec });

            _outputDockForm.objectListView1.SetObjects(_outputMessageList.OrderByDescending(m=>m.OutputMessageTimestamp).ToArray());

            if (displayMessageBox)
            {
                MessageBoxImage mbi;
                switch (outputMessageType)
                {
                    case EOutputMessageType.ERROR: mbi = MessageBoxImage.Error; break;
                    case EOutputMessageType.WARNING: mbi = MessageBoxImage.Warning; break;
                    case EOutputMessageType.INFORMATION: mbi = MessageBoxImage.Information; break;
                    case EOutputMessageType.PROGRESS: mbi = MessageBoxImage.None; break;
                    default: mbi = MessageBoxImage.Question; break;
                }

                MessageBox.Show(outputMessageText, "Output Message", MessageBoxButton.OK, mbi);
            }
        }

        public static void AppendToLastMessage(EOutputMessageType outputMessageType, string outputMessageAdditionalText, double durationSec = -1)
        {
            var msg = _outputMessageList.Last();
            msg.OutputMessageType = outputMessageType;
            msg.OutputMessageDescription += outputMessageAdditionalText;
            msg.DurationSec = durationSec;

            _outputDockForm.objectListView1.SetObjects(_outputMessageList.OrderByDescending(m => m.OutputMessageTimestamp));
        }

        public static void Initialize(ref OutputDockForm outputDockForm)
        {
            _outputDockForm = outputDockForm;
            _isInitialized = true;
        }
    }
}
