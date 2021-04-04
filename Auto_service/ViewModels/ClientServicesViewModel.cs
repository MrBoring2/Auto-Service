using Auto_service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Auto_service.ViewModels
{
    class ClientServicesViewModel : INotifyPropertyChanged
    {

        public ClientServicesViewModel(Client currentClient)
        {
            CurrentClient = currentClient;
            ClientServices = new ObservableCollection<ClientService>(currentClient.ClientService);
        }

        private Client currentClient;
        public Client CurrentClient
        {
            get => currentClient;
            set
            {
                currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }

        private ObservableCollection<ClientService> clientServices;
        public ObservableCollection<ClientService> ClientServices
        {
            get => clientServices;
            set
            {
                clientServices = value;
                OnPropertyChanged("ClientServices");
            }
        }


        private RelayCommand back;
        public RelayCommand Back
        {
            get
            {
                return back ??
                  (back = new RelayCommand(obj =>
                  {
                      using (var entityes = new Auto_serviceEntities())
                      {
                          var displayRootRegistry = (Application.Current as App).windowsController;
                          var otherWindowViewModel = new ClientsViewModel(new ObservableCollection<Client>(entityes.Client.ToList()));
                          displayRootRegistry.ShowPresentation(otherWindowViewModel);
                          displayRootRegistry.HidePresentation(this);
                      }
                  }));
            }
        }


        //реаализация события OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
