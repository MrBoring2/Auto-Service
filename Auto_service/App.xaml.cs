using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Auto_service.Services;

namespace Auto_service
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        public WindowsController windowsController = new WindowsController();
        ViewModels.ClientsViewModel clientsViewModel;
        
        public App()
        {
            windowsController.RegisterWindowType<ViewModels.ClientsViewModel, Views.Clients>();
            windowsController.RegisterWindowType<ViewModels.AddClientViewModel, Views.AddClient>();
            windowsController.RegisterWindowType<ViewModels.RefactorClientViewModel, Views.RefactorClient>();
            windowsController.RegisterWindowType<ViewModels.ClientServicesViewModel, Views.ClientServices>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SplashScreen splashScreen = new SplashScreen("../Resources/service_logo.png");
            splashScreen.Show(true);
            splashScreen.Close(TimeSpan.FromSeconds(1));
            Auto_serviceEntities entities = new Auto_serviceEntities();
            
            clientsViewModel = new ViewModels.ClientsViewModel(new System.Collections.ObjectModel.ObservableCollection<Client>(entities.Client.ToList()));
            windowsController.ShowPresentation(clientsViewModel);
           
            entities.Dispose();
        }
    }
}
