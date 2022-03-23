//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Data.ConnectionUI;

namespace AdvancedSqlServerDependencies.Microsoft.Data.ConnectionUI
{
    /// <summary>
    /// Provide a default implementation for the storage of DataConnection Dialog UI configuration.
    /// </summary>
    public class DataConnectionConfiguration : IDataConnectionConfiguration
    {
        private const string _configFileName = @"DataConnection.xml";
        private readonly string _fullFilePath;
        private readonly XDocument _xDoc;

        // Available data sources:
        private IDictionary<string, DataSource> _dataSources;

        // Available data providers: 
        private IDictionary<string, DataProvider> _dataProviders;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Configuration file path.</param>
        public DataConnectionConfiguration(string path)
        {
            _fullFilePath = !String.IsNullOrEmpty(path) ? Path.GetFullPath(Path.Combine(path, _configFileName)) : Path.Combine(Environment.CurrentDirectory, _configFileName);

            if (!String.IsNullOrEmpty(_fullFilePath) && File.Exists(_fullFilePath))
            {
                _xDoc = XDocument.Load(_fullFilePath);
            }
            else
            {
                _xDoc = new XDocument();
                _xDoc.Add(new XElement("ConnectionDialog", new XElement("DataSourceSelection")));
            }

            this.RootElement = _xDoc.Root;
        }

        public XElement RootElement { get; set; }

        public void LoadConfiguration(DataConnectionDialog dialog)
        {
            dialog.DataSources.Add(DataSource.SqlDataSource);
            //dialog.DataSources.Add(DataSource.SqlFileDataSource);
            //dialog.DataSources.Add(DataSource.OracleDataSource);
            //dialog.DataSources.Add(DataSource.AccessDataSource);
            //dialog.DataSources.Add(DataSource.OdbcDataSource);
            //dialog.DataSources.Add(SqlCe.SqlCeDataSource);

            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.SqlDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OracleDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OleDBDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OdbcDataProvider);
            //dialog.DataSources.Add(dialog.UnspecifiedDataSource);

            this._dataSources = new Dictionary<string, DataSource>();
            this._dataSources.Add(DataSource.SqlDataSource.Name, DataSource.SqlDataSource);
            //this._dataSources.Add(DataSource.SqlFileDataSource.Name, DataSource.SqlFileDataSource);
            //this._dataSources.Add(DataSource.OracleDataSource.Name, DataSource.OracleDataSource);
            //this._dataSources.Add(DataSource.AccessDataSource.Name, DataSource.AccessDataSource);
            //this._dataSources.Add(DataSource.OdbcDataSource.Name, DataSource.OdbcDataSource);
            //this._dataSources.Add(SqlCe.SqlCeDataSource.Name, SqlCe.SqlCeDataSource);
            this._dataSources.Add(dialog.UnspecifiedDataSource.DisplayName, dialog.UnspecifiedDataSource);

            this._dataProviders = new Dictionary<string, DataProvider>();
            this._dataProviders.Add(DataProvider.SqlDataProvider.Name, DataProvider.SqlDataProvider);
            //this._dataProviders.Add(DataProvider.OracleDataProvider.Name, DataProvider.OracleDataProvider);
            //this._dataProviders.Add(DataProvider.OleDBDataProvider.Name, DataProvider.OleDBDataProvider);
            //this._dataProviders.Add(DataProvider.OdbcDataProvider.Name, DataProvider.OdbcDataProvider);
            //this._dataProviders.Add(SqlCe.SqlCeDataProvider.Name, SqlCe.SqlCeDataProvider);


            DataSource ds;
            string dsName = this.GetSelectedSource();
            if (!String.IsNullOrEmpty(dsName) && this._dataSources.TryGetValue(dsName, out ds))
            {
                dialog.SelectedDataSource = ds;
            }

            DataProvider dp;
            string dpName = this.GetSelectedProvider();
            if (!String.IsNullOrEmpty(dpName) && this._dataProviders.TryGetValue(dpName, out dp))
            {
                dialog.SelectedDataProvider = dp;
            }
        }

        public void SaveConfiguration(DataConnectionDialog dcd)
        {
            if (dcd.SaveSelection)
            {
                DataSource ds = dcd.SelectedDataSource;
                if (ds != null)
                {
                    this.SaveSelectedSource(ds == dcd.UnspecifiedDataSource ? ds.DisplayName : ds.Name);
                }
                DataProvider dp = dcd.SelectedDataProvider;
                if (dp != null)
                {
                    this.SaveSelectedProvider(dp.Name);
                }

                _xDoc.Save(_fullFilePath);
            }
        }

        public string GetSelectedSource()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement sourceElem = xElem.Element("SelectedSource");
                if (sourceElem != null)
                {
                    return sourceElem.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetSelectedProvider()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("SelectedProvider");
                if (providerElem != null)
                {
                    return providerElem.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public void SaveSelectedSource(string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                try
                {
                    XElement xElem = this.RootElement.Element("DataSourceSelection");
                    XElement sourceElem = xElem.Element("SelectedSource");
                    if (sourceElem != null)
                    {
                        sourceElem.Value = source;
                    }
                    else
                    {
                        xElem.Add(new XElement("SelectedSource", source));
                    }
                }
                catch
                {
                }
            }

        }

        public void SaveSelectedProvider(string provider)
        {
            if (String.IsNullOrEmpty(provider)) return;

            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement sourceElem = xElem.Element("SelectedProvider");
                if (sourceElem != null)
                {
                    sourceElem.Value = provider;
                }
                else
                {
                    xElem.Add(new XElement("SelectedProvider", provider));
                }
            }
            catch
            {
            }
        }
    }
}