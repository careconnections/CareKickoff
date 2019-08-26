using CareConnection.Core.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CareConnection.Core.ViewModel
{
    public class ClientViewModel : BaseViewModel
    {
        public ClientViewModel()
        {
        }

        #region Properties
        private List<Clients> authorizedClients;
        public List<Clients> AuthorizedClients
        {
            get { return authorizedClients; }
            set
            {
                authorizedClients = value;
                OnPropertyChanged("AuthorizedClients");
            }
        }

        private ImageSource GenderImage
        {
            get
            {
                ImageSource image = null;
                foreach (var client in authorizedClients)
                {
                    if (client.Gender.Equals("Male"))
                        image = ImageSource.FromFile("Male.png");
                    else if (client.Gender.Equals("Female"))
                        image = ImageSource.FromFile("Female.png");
                }
                return image;
            }
        }
        #endregion
    }
}