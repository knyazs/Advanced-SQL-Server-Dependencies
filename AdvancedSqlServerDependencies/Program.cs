using System;
using System.Threading;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;

namespace AdvancedSqlServerDependencies
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Unhandled exceptions handler
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.Run(new MainFormMdi());
        }       

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var exForm = new ExceptionForm(e.Exception);
            exForm.ShowDialog();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exForm = new ExceptionForm((Exception)e.ExceptionObject);
            exForm.ShowDialog();
        }
    }
}
