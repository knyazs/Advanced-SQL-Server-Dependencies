using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;
using WeifenLuo.WinFormsUI.Docking;
using AdvancedSqlServerDependencies.MySqlObjects;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using AdvancedSqlServerDependencies.SqlServer;
using System.Diagnostics;
using AdvancedSqlServerDependencies.Util;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class SqlServerPropertiesDockForm : DockContent
    {
        private MySqlServer _mySqlServer;

        // Counters
        private PerformanceCounter privateRamCounter;
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private int physicalCpuCount;
        private int coreCount;
        private int logicalCpuCount;

        private const int SAMPLE_COUNT = 60;
        private List<float> _cpuUsageList;
        private List<float> _ramUsageList;
        private List<float> _privateMemoryUsageList;

        public SqlServerPropertiesDockForm(ref MySqlServer mySqlServer)
        {
            InitializeComponent();

            _mySqlServer = mySqlServer;

            var p = Process.GetCurrentProcess();
            privateRamCounter = new PerformanceCounter("Process", "Working Set - Private", p.ProcessName, true);
            cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName, true);
            ramCounter = new PerformanceCounter("Process", "Working Set", p.ProcessName, true);

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                physicalCpuCount = int.Parse(item["NumberOfProcessors"].ToString());
                logicalCpuCount = int.Parse(item["NumberOfLogicalProcessors"].ToString());
            }

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }


            // Preinitialize lists
            _cpuUsageList = new List<float>();
            _ramUsageList = new List<float>();
            _privateMemoryUsageList = new List<float>();
            for (int i=0; i<SAMPLE_COUNT; i++)
            {
                _cpuUsageList.Add(0);
                _ramUsageList.Add(0);
                _privateMemoryUsageList.Add(0);
            }
        }

        public void RefreshInfo()
        {
            textBoxDataSource.Text = _mySqlServer.DataSource;

            if (textBoxServerObjects.InvokeRequired)
            {
                textBoxServerObjects.Invoke(new MethodInvoker(delegate () { textBoxServerObjects.Text = string.Format("{0:n0}", _mySqlServer.SqlServerObjects.Length); }));
            }
            else
            {
                textBoxServerObjects.Text = string.Format("{0:n0}", _mySqlServer.SqlServerObjects.Length);
            }

            if (textBoxDatabases.InvokeRequired)
            {
                textBoxDatabases.Invoke(new MethodInvoker(delegate () { textBoxDatabases.Text = string.Format("{0:n0} of {1:n0}", _mySqlServer.CheckedDatabasesCount, _mySqlServer.SqlDatabases.Length); }));
            }
            else
            {
                textBoxDatabases.Text = string.Format("{0:n0} of {1:n0}", _mySqlServer.CheckedDatabasesCount, _mySqlServer.SqlDatabases.Length);
            }

            if (textBoxObjects.InvokeRequired)
            {
                textBoxObjects.Invoke(new MethodInvoker(delegate () { textBoxObjects.Text = string.Format("{0:n0}", _mySqlServer.SqlObjects.Length); }));
            }
            else
            {
                textBoxObjects.Text = string.Format("{0:n0}", _mySqlServer.SqlObjects.Length);
            }
            if (textBoxDependencies.InvokeRequired)
            {
                textBoxDependencies.Invoke(new MethodInvoker(delegate () { textBoxDependencies.Text = string.Format("{0:n0}", _mySqlServer.SqlExpressionDependencies.Length); }));
            }
            else
            {
                textBoxDependencies.Text = string.Format("{0:n0}", _mySqlServer.SqlExpressionDependencies.Length);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var cpu = cpuCounter.NextValue() / logicalCpuCount;
            var ram = ramCounter.NextValue();
            var pRam = privateRamCounter.NextValue();

            _cpuUsageList.RemoveAt(0);
            _cpuUsageList.Add(cpu);

            _ramUsageList.RemoveAt(0);
            _ramUsageList.Add(ram / 1024 / 1024);

            _privateMemoryUsageList.RemoveAt(0);
            _privateMemoryUsageList.Add(pRam / 1024 / 1024);
            
            refreshCharts();
        }

        private void refreshCharts()
        {
            chart1.Series[0].Points.DataBindY(_cpuUsageList);
            chart2.Series[0].Points.DataBindY(_ramUsageList);
            chart2.Series[1].Points.DataBindY(_privateMemoryUsageList);
        }
    }
}
