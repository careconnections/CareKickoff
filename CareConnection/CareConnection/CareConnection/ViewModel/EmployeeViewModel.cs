using CareConnection.Core.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CareConnection.Core.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        private Employee loggedInEmmployee;

        public EmployeeViewModel()
        {
            LoginCommand = new Command(ProcessLogin);
        }

        #region Private Methods
        private void ProcessLogin()
        {
            loggedInEmmployee = EmployeeProvider.Instance.GetEmployeeByID(employeeID);

            if (loggedInEmmployee != null)
            {
                IsSuccessful = true;
                return;
            }
            else
                IsSuccessful = false;
        }
        #endregion

        #region Public Methods
        public List<Clients> GetAuthorizedClients()
        {
            var authorizedClients = ClientProvider.Instance.GetClientsByIds(this.loggedInEmmployee.AuthorizedClients);
            return authorizedClients;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { protected set; get; }
        #endregion

        #region Properties
        private bool isSuccessful;
        public bool IsSuccessful
        {
            get
            {
                return isSuccessful;
            }
            set
            {
                if (value != isSuccessful)
                {
                    isSuccessful = value;
                }
            }
        }

        private ObservableCollection<Employee> employee;
        public ObservableCollection<Employee> Employees
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employees");
            }
        }

        private int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                employeeID = value;
                OnPropertyChanged("EmployeeID");
            }
        }
        #endregion Properties
    }
}