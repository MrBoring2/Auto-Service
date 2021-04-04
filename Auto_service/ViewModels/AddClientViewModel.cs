using Auto_service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Auto_service.ViewModels
{
    class AddClientViewModel : INotifyPropertyChanged
    {
        //поля для FileDialog
        private IDialogService dialogService;
        private IFileService fileService;

        //поле для результата диалогового окна
        private bool? dialogResult;
        public bool? DialogResult 
        {
            get => dialogResult;
            set
            {
                dialogResult = value;
                OnPropertyChanged("DialogResult");
            }
        }
        private Client currentClient;       
        private ObservableCollection<string> genders;
        
        private string selectedGender;

        private string photoSource="";
        private string firstName="";
        private string lasName="";
        private string patronomic="";
        private string email="";
        private string phone="";
        private string photo="";
        private DateTime birthDay;

        public AddClientViewModel(DialogService dialogService)
        {
            this.dialogService = dialogService;
            fileService = new ImageFileService();
            BirthDay = DateTime.Now;

            //заполянем коллекцию полов
            Genders = new ObservableCollection<string>();
            using (var entities = new Auto_serviceEntities())
            {
                foreach (var gender in entities.Gender)
                {
                    Genders.Add(gender.Name);
                }
            }
            SelectedGender = Genders[0];
        }
        public ObservableCollection<string> Genders
        {
            get => genders;
            set
            {
                genders = value;
                OnPropertyChanged("Genders");
            }
        }

        public Client CurrentClient
        {
            get => currentClient;
            set => currentClient = value;
        }

        public string SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => lasName;
            set
            {
                lasName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Patronomic
        {
            get => patronomic;
            set
            {
                patronomic = value;
                OnPropertyChanged("Patronomic");
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime BirthDay
        {
            get => birthDay;
            set
            {
                birthDay = value;
                OnPropertyChanged("BirthDay");
            }
        }

        public string PhotoSource
        {
            get => photoSource;
            set
            {
                photoSource = value;
                OnPropertyChanged("PhotoSource");
            }
        }
      
        //комманда добавления клиента
        private RelayCommand addClient;
        public RelayCommand AddClient
        {
            get
            {
                return addClient ??
                    (addClient = new RelayCommand(obj =>
                    {
                        currentClient = new Client
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            Patronymic = Patronomic,
                            Phone = Phone,
                            Email = Email,
                            RegistrationDate = DateTime.Now,
                            Birthday = BirthDay,                          
                            GenderCode = SelectedGender[0].ToString(),                         
                            PhotoPath = @"Клиенты\" + photo
                        };
                        if (Validate(currentClient))
                        {
                            using(var entites = new Auto_serviceEntities())
                            {
                                WindowsController w = new WindowsController();
                                entites.Client.Add(currentClient);
                                entites.SaveChanges();
                                fileService.Save(PhotoSource, photo);                              
                                MessageBox.Show("Клиент добавлен!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                DialogResult = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные данные!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }));
                    
            }
        }


        //Валидация клиента
        private bool Validate(Client client)
        {
            if (ValidateString(LastName, 50)
                && ValidateString(FirstName, 50)
                && ValidateString(Patronomic, 50)
                && ValidateEmail(Email)
                && ValidatePhone(Phone)
                && !String.IsNullOrEmpty(photo))
                return true;
            return false;
        }

        //Валидация имени, фамилии и отчества
        private bool ValidateString(string str, int countOfSymbols)
        {
            if(str.Length <= countOfSymbols)
            {
                foreach (var ch in str)
                {
                    if (!char.IsLetter(ch))
                    {
                        if(!char.IsWhiteSpace(ch) || ch != '-')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else return false;
        }

        //валидация телефона
        private bool ValidatePhone(string phone)
        {
            foreach (var ch in phone)
            {
                if(!char.IsNumber(ch))
                {
                    if (ch != '+' && ch != '-' && ch != '(' && ch != ')' && ch != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //валидация email
        private bool ValidateEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }


        //команда отрытия FileDialog

        private RelayCommand openFile;
        public RelayCommand OpenFile
        {
            get
            {
                return openFile ??
                  (openFile = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              PhotoSource = dialogService.FilePath;
                              photo = Guid.NewGuid().ToString() + ".png";                           
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
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
