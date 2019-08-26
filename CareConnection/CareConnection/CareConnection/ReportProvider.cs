using CareConnection.Core.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CareConnection.Core
{
    class ReportProvider
    {
        List<Report> _reportList;

        private ReportProvider()
        {
            GetReportList();
        }

        private static ReportProvider instance = null;
        public static ReportProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReportProvider();
                }
                return instance;
            }
        }

        #region private methods
        private void GetReportList()
        {
            string reportFileName = "DataFiles.reports.json";

            var assembly = typeof(ReportProvider).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{reportFileName}");

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                _reportList = JsonConvert.DeserializeObject<List<Report>>(json);
            }
        }
        #endregion

        #region public methods
        public Report GetReportForClient(Clients client)
        {
            Report clientReport = null;

            foreach (Report report in _reportList)
            {
                if (report.ClientID == client.NativeID)
                {
                    clientReport = report;
                    break;
                }
            }
            return clientReport;
        }
        #endregion
    }
}