using CareConnection.Core.Model;
using System;

namespace CareConnection.Core.ViewModel
{
    public class ReportViewModel : BaseViewModel
    {
        public ReportViewModel()
        {
        }

        #region Properties
        private Clients client;
        public Clients Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }

        private Report report;
        public Report Report
        {
            get
            {
                GetReport();
                return report;
            }
            set
            {
                report = value;
                OnPropertyChanged("Report");
            }
        }

        private bool errorReportAvailable;
        public bool ErrorReportAvailable
        {
            get => errorReportAvailable;
            set
            {
                errorReportAvailable = value;
                OnPropertyChanged(nameof(ErrorReportAvailable));
            }
        }
        #endregion

        #region private methods
        private void GetReport()
        {
            CarePlan carePlan = CarePlanProvider.Instance.GetCarePlanByClient(client);
            report = ReportProvider.Instance.GetReportForClient(client);

            if (report != null)
            {
                Goal carePlanGoal = CarePlanProvider.Instance.GetGoalForCarePlan(carePlan, report.CarePlanGoalID);
                ErrorReportAvailable = false;
            }
            else
            {
                ErrorReportAvailable = true;
                Console.WriteLine("Report not available for " + client.FirstName);
            }
        }
        #endregion
    }
}