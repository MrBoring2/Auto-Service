using Auto_service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Auto_service.ViewModels
{
    class ClientsViewModel : ListCollectionView, INotifyPropertyChanged
    {
        //Сонтекст данных из базы
        private Auto_serviceEntities entities = new Auto_serviceEntities();

        private ObservableCollection<Client> clients;
        private ObservableCollection<string> genders;
        private ObservableCollection<string> filterItems;
        private ObservableCollection<string> sortingParams;
        private ObservableCollection<Client> Filtered { get; set; }
        private ObservableCollection<Client> Standart { get; set; }

        private Client selectedClient { get; set; }

        private RelayCommand nextPage;
        private RelayCommand previousPage;

        private string showedClients;
        private int currentPage = 1;
        private string pageOf;
        private string pageTo;
        private string countOfClients;
        private string selectedGender;
        private string selectedItemsOnPage;
        private string selectedOrderBy;
        private string search;
        private string searchEmail;
        private string searchPhone;
        private int totalCountOfClients;
        public int TotalCountOfClients 
        { 
            get=>totalCountOfClients;
            set
            {
                totalCountOfClients = value;
                CountOfClients = totalCountOfClients.ToString();
            }
        }
        private int countFilteredClients;
        private int coutnOfVisit;
        private string orderBy;
        private bool orderByDesc;


        //Передаём базовому классу ListCollectionView список данных
        public ClientsViewModel(ObservableCollection<Client> clients)
            : base(clients)
        {
            InitColletions(clients);
            InitUIFields();
            //EventManager.RegisterClassHandler(typeof(Window),
            //    Keyboard.KeyUpEvent, new KeyEventHandler(keyUp), true);
        }

        private void InitColletions(ObservableCollection<Client> clients)
        {
           
            Genders = new ObservableCollection<string>();
            Genders.Add("Все");
            foreach (var gender in entities.Gender)
            {
                Genders.Add(gender.Name);
            }
            FilterItems = new ObservableCollection<string>();
            FilterItems.Add("Все");
            FilterItems.Add("10");
            FilterItems.Add("50");
            FilterItems.Add("200");
            SortingParams = new ObservableCollection<string>();
            SortingParams.Add("ID");
            SortingParams.Add("Фамилия");
            SortingParams.Add("Последнее посещение");
            SortingParams.Add("Количество посещений");
            Clients = clients;
        }

        private void InitUIFields()
        {
            SelectedItemsOnPage = Clients.Count().ToString();
            TotalCountOfClients = entities.Client.Count();
            CountOfClients = TotalCountOfClients.ToString();
            CountFilteredClients = TotalCountOfClients;

        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
                orderBy = "LastName";
            else if (e.Key == Key.F3)
                orderBy = "LastVisit";
            else if (e.Key == Key.F4)
                orderBy = "CountOfVisit";
            Sort(orderBy);
        }

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                Refresh();
                OnPropertyChanged("Clients");
            }
        }

        public ObservableCollection<string> Genders
        {
            get { return genders; }
            set
            {
                genders = value;
            }
        }
        public ObservableCollection<string> FilterItems
        {
            get { return filterItems; }
            set
            {
                filterItems = value;
            }
        }
        public ObservableCollection<string> SortingParams
        {
            get { return sortingParams; }
            set
            {
                sortingParams = value;
            }
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public int CoutnOfVisit
        {
            get => coutnOfVisit;
            set
            {
                coutnOfVisit = value;
                OnPropertyChanged("CoutnOfVisit");
            }
        }


        public string SelectedOrderBy
        {
            get => selectedOrderBy;
            set
            {
                selectedOrderBy = value;
                Sort(SelectedOrderBy);
                OnPropertyChanged("SelectedOrderBy");
            }
        }
        public string CountOfClients
        {
            get => countOfClients;
            set
            {
                countOfClients = value;
                OnPropertyChanged("CountOfClients");
            }
        }

        public string SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                Clients = FilterIt(new ObservableCollection<Client>(entities.Client.ToList()));
                Sort(SelectedOrderBy);
                ReloadPage();
                Refresh();
                OnPropertyChanged("SelectedGender");
            }
        }
        public string SelectedItemsOnPage
        {
            get
            {
                if (selectedItemsOnPage == "Все")
                    return TotalCountOfClients.ToString();
                else
                    return selectedItemsOnPage;
            }
            set
            {
                selectedItemsOnPage = value;
                //Обновляем общее количество элементов
                TotalPages = (this.Clients.Count + Convert.ToInt32(SelectedItemsOnPage) - 1) / Convert.ToInt32(SelectedItemsOnPage);
                ShowedClients = Count.ToString();
                //Если нужно, переходи назад по страницам
                ReloadPage();
                //Перезагружаем View
                Refresh();
                OnPropertyChanged("SelectedItemsOnPage");
            }
        }

        public string ShowedClients
        {
            get => showedClients;
            set
            {
                showedClients = value;
                OnPropertyChanged("ShowedClients");
            }
        }

        private int totalPages;
        public int TotalPages
        {
            get => totalPages;
            set
            {
                totalPages = value;
                OnPropertyChanged("TotalPages");
            }
        }

        public int CountFilteredClients
        {
            get => countFilteredClients;
            set
            {
                countFilteredClients = value;
                OnPropertyChanged("CountFilteredClients");
            }
        }

        public bool OrderByDesc
        {
            get => orderByDesc;
            set
            {
                orderByDesc = value;
                Sort(SelectedOrderBy);
                OnPropertyChanged("OrderByDesc");
            }
        }

        public string Search
        {
            get => search;
            set
            {
                search = value;
                //Фильтруем клиентов
                Clients = FilterIt(new ObservableCollection<Client>(entities.Client.ToList()));
                Sort(SelectedOrderBy);
                //Если нужно, переходи назад по страницам
                ReloadPage();
                //Перезагружаем View
                Refresh();
                OnPropertyChanged("SearchFIO");
            }
        }
        public string SearchEmail
        {
            get => searchEmail;
            set
            {
                searchEmail = value;
                OnPropertyChanged("SearchEmail");
            }
        }
        public string SearchPhone
        {
            get => searchPhone;
            set
            {
                searchPhone = value;
                OnPropertyChanged("SearchPhone");
            }
        }

        public override int Count
        {
            get
            {
                //Если кол-во клиентов = 0, то ничего не отображаем
                if (Clients.Count == 0)
                {
                    ShowedClients = "0";
                    TotalPages = 1;
                    return 0;
                }
                //Для страниц от 1 до n-1
                if (this.CurrentPage < this.PageCount)
                {
                    ShowedClients = SelectedItemsOnPage;
                    return Convert.ToInt32(SelectedItemsOnPage);
                }
                //Для страницы n
                else
                {
                    var clientsLeft = this.Clients.Count % Convert.ToInt32(SelectedItemsOnPage);
                    ShowedClients = clientsLeft.ToString();


                    if (0 == clientsLeft)
                    {
                        ShowedClients = SelectedItemsOnPage;
                        //Клиентов осталось ровно SelectedItemsOnPage
                        return Convert.ToInt32(SelectedItemsOnPage); // exactly itemsPerPage left
                    }
                    else
                    {
                        ShowedClients = clientsLeft.ToString();
                        //Возвращяем оставшихся клиентов
                        return clientsLeft;
                    }
                }
            }
        }



        public int CurrentPage
        {
            get { return this.currentPage; }
            set
            {
                this.currentPage = value;
                //Не даём текущей странице быть < 1
                if (currentPage < 1)
                    currentPage = 1;
                this.OnPropertyChanged("CurrentPage");
            }
        }

        public int ItemsPerPage { get { return Convert.ToInt32(SelectedItemsOnPage); } }

        public int PageCount
        {
            get
            {
                TotalPages = (this.Clients.Count + Convert.ToInt32(SelectedItemsOnPage) - 1) / Convert.ToInt32(SelectedItemsOnPage);
                return (this.Clients.Count + Convert.ToInt32(SelectedItemsOnPage) - 1)
                    / Convert.ToInt32(SelectedItemsOnPage);
            }
        }

        private void ReloadPage()
        {
            if (CurrentPage != 1)
            {
                //Если текущая странице больше, чем всего страниц после фильтрации,
                //то устанавливаем текущую страницу PageCount
                if (CurrentPage >= PageCount)
                    CurrentPage = PageCount;
            }
            //Иначе переходим на 1 страницу
            else CurrentPage = 1;
        }

        private int EndIndex
        {
            get
            {
                var end = this.currentPage * Convert.ToInt32(SelectedItemsOnPage) - 1;
                return (end > Clients.Count) ? this.Clients.Count : end;
            }
        }

        private int StartIndex
        {
            get { return (this.currentPage - 1) * Convert.ToInt32(SelectedItemsOnPage); }
        }

        public override object GetItemAt(int index)
        {
            //Если клиентов 0, то неичего не выбираем
            if (Clients.Count == 0)
            {
                return 0;
            }
            var offset = index % (Convert.ToInt32(SelectedItemsOnPage));
            return Clients[this.StartIndex + offset];
        }

        //команда перехода на следующую страницу
        public RelayCommand NextPage
        {
            get
            {
                return nextPage ??
                  (nextPage = new RelayCommand(obj =>
                  {
                      if (this.currentPage < this.PageCount)
                      {
                          this.CurrentPage += 1;
                          this.Refresh();
                      }
                      else
                      {
                          TotalPages = 1;
                      }
                     
                  }));
            }
        }

        //команда перехода на предыдущую страницу
        public RelayCommand PreviousPage
        {
            get
            {
                return previousPage ??
                  (previousPage = new RelayCommand(obj =>
                  {
                      if (this.currentPage > 1)
                      {
                          this.CurrentPage -= 1;
                          this.Refresh();
                      }
                      
                  }));
            }
        }

        //сортировка
        private void Sort(string sortBy)
        {
            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "ID":
                        {
                            if (!OrderByDesc)
                                Clients = new ObservableCollection<Client>(from p in Clients
                                                                           orderby p.ID
                                                                           select p);
                            else Clients = new ObservableCollection<Client>(Clients.OrderByDescending(p => p.ID));
                        }
                        break;
                    case "Фамилия":
                        {
                            if (!OrderByDesc)
                                Clients = new ObservableCollection<Client>(from p in Clients
                                                                           orderby p.LastName 
                                                                           select p);
                            else Clients = new ObservableCollection<Client>(Clients.OrderByDescending(p => p.LastName));
                        }
                        break;
                    case "Последнее посещение":
                        {
                            if (!OrderByDesc)
                                Clients = new ObservableCollection<Client>(from p in Clients
                                                                           where p.LastVisit!= "Не посещал"
                                                                           orderby p.LastVisit
                                                                           select p);
                            else Clients = new ObservableCollection<Client>(from p in Clients
                                                                            
                                                                            orderby p.LastVisit descending
                                                                            select p);
                        }
                        break;
                    case "Количество посещений":
                        {
                            if (!OrderByDesc)
                                Clients = new ObservableCollection<Client>(from p in Clients
                                                                           orderby p.CountOfVisit
                                                                           select p);
                            else Clients = new ObservableCollection<Client>(Clients.OrderByDescending(p => p.CountOfVisit));
                        }
                        break;
                }
            }
            Refresh();
        }


        //Фильтр
        private ObservableCollection<Client> FilterIt(ObservableCollection<Client> clients)
        {
            //Фильтруем клиентов по полу, если он выбран
            if (!String.IsNullOrEmpty(SelectedGender) && SelectedGender != "Все")
                clients = new ObservableCollection<Client>(clients.Where(p => p.Gender.Name == SelectedGender));
            //Фильтруем клиентов по поисковому слову, если поиск не пустой
            if (!String.IsNullOrEmpty(Search))
            {
                clients = new ObservableCollection<Client>(clients.Where(p => (p.FirstName + " " + p.LastName + " " + p.Patronymic).Contains(Search)
                                                                         || p.Phone.Contains(Search)
                                                                         || p.Email.Contains(Search)));
            }
            //Обновляем кол-во отфильтрованных клиентов
            CountFilteredClients = clients.Count();
            //Возвращаем отфильтрованный список

            return clients;
        }


        //команда вызова формы добавления клиента
        private RelayCommand addClient;
        public RelayCommand AddClient
        {
            get
            {
                return addClient ??
                  (addClient = new RelayCommand(obj =>
                  {
                      ShowModal(); 
                  }));
            }
        }

        //команда вызова формы редактирования клиента
        private RelayCommand refactorClient;
        public RelayCommand RefactorClient
        {
            get
            {
                return refactorClient ??
                  (refactorClient = new RelayCommand(obj =>
                  {
                      if(SelectedClient!=null)
                        ShowRefactor();
                      else
                      {
                           MessageBox.Show("Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

                      }
                  }));
            }
        }
        
        //команда удаления клиента
        private RelayCommand removeClient;
        public RelayCommand RemoveClient
        {
            get
            {
                return removeClient ??
                    (removeClient = new RelayCommand(obj =>
                    {
                        if (SelectedClient != null)
                        {
                            if (SelectedClient.CountOfVisit == 0)
                            {
                                try
                                {
                                    entities.Client.Remove(SelectedClient);
                                    entities.SaveChanges();
                                    Clients.Remove(SelectedClient);
                                    TotalCountOfClients = Clients.Count;
                                    File.Delete(@"../../Resources/" + SelectedClient.PhotoPath);
                                    FilterIt(Clients);
                                    Sort(SelectedOrderBy);
                                    MessageBox.Show("Клиент удалён!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                    SelectedClient = null;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("У клиента имеется информация о посещениях!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }));

            }
        }

        //вызоф формы списка услуг клиента
        private RelayCommand showClientServices;
        public RelayCommand ShowClientServices
        {
            get
            {
                return showClientServices ??
                  (showClientServices = new RelayCommand(obj =>
                  {
                      if (SelectedClient != null)
                      {
                          using (var entityes = new Auto_serviceEntities())
                          {
                              var displayRootRegistry = (Application.Current as App).windowsController;
                              var otherWindowViewModel = new ClientServicesViewModel(SelectedClient);
                              displayRootRegistry.ShowPresentation(otherWindowViewModel);
                              displayRootRegistry.HidePresentation(this);
                          }
                      }
                      else MessageBox.Show("Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                  }));
            }
        }

        //вызов окна редактирования клиента
        private async void ShowRefactor()
        {
            var displayRootRegistry = (Application.Current as App).windowsController;
            var otherWindowViewModel = new RefactorClientViewModel(SelectedClient);
            await displayRootRegistry.ShowModalPresentation(otherWindowViewModel);

            if (otherWindowViewModel.CurrentClient != null)
            {
                int id = Clients.ToList().FindIndex(p => p.ID == otherWindowViewModel.CurrentClient.ID);
                Clients[id] = otherWindowViewModel.CurrentClient;
                this.entities = new Auto_serviceEntities();
                Clients = FilterIt(new ObservableCollection<Client>(entities.Client.ToList()));
                Sort(SelectedOrderBy);
                SelectedClient = null;
            }
        }

        //вызов окна добавления клиента
        private async void ShowModal()
        {
            var displayRootRegistry = (Application.Current as App).windowsController;
            var otherWindowViewModel = new AddClientViewModel(new DialogService());
            await displayRootRegistry.ShowModalPresentation(otherWindowViewModel);

            if (otherWindowViewModel.CurrentClient != null)
            {
                TotalCountOfClients = entities.Client.Count();
                CountOfClients = TotalCountOfClients.ToString();
                this.entities = new Auto_serviceEntities();
                Clients.Add(otherWindowViewModel.CurrentClient);
                Clients = FilterIt(new ObservableCollection<Client>(entities.Client.ToList()));
                Sort(SelectedOrderBy);
                SelectedClient = null;
            }

        }



        //Событие при изменении какого-либо свойства
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
