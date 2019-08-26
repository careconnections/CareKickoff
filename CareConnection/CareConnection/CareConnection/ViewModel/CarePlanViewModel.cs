using CareConnection.Core.Model;

namespace CareConnection.Core.ViewModel
{
    public class CarePlanViewModel : BaseViewModel
    {
        public CarePlanViewModel()
        {
        }

        #region Properties
        private CarePlan carePlan;
        public CarePlan CarePlan
        {
            get {
                return GetCarePlans(); }
            set
            {
                carePlan = value;
                OnPropertyChanged("CarePlan");
            }
        }

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
        #endregion

        #region private methods
        private CarePlan GetCarePlans()
        {
            carePlan = CarePlanProvider.Instance.GetCarePlanByClient(client);
            return carePlan;
        }
        #endregion
    }
}