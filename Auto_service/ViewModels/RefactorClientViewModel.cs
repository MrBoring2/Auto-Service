using Auto_service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Auto_service.ViewModels
{
    class RefactorClientViewModel : INotifyPropertyChanged
    {
        //контекст базы данных
        Auto_serviceEntities entities = new Auto_serviceEntities();

        //результат диалогового окна
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

        //поля для FileDialog
        private IDialogService dialogService;
        private IFileService fileService;
        private string standartPhoto;
        private ObservableCollection<string> genders;
        private ObservableCollection<Tag> allTags;
        private List<Tag> listTag;
        private List<Tag> totalListTag;

        private string selectedGender;
        private int id;
        private string photoSource = "";
        private string firstName = "";
        private string lasName = "";
        private string patronomic = "";
        private string email = "";
        private string phone = "";
        private string photo = "";
        private string tagTitle = "";
        private string colorHex = "";
        private DateTime birthDay;
       
        private Client currentClient;
       
        private Tag selectedAddTag;
        private Tag selectedRemoveTag;
        public ObservableCollection<Tag> AllTags
        {
            get => allTags;
            set
            {
                allTags = value;
                OnPropertyChanged("AllTags");
            }
        }
        public RefactorClientViewModel(Client client)
        {

            AllTags = new ObservableCollection<Tag>();
            this.dialogService = new DialogService();
            fileService = new ImageFileService();
            CurrentClient = client;

            //заполняем коллекцию тегов клиента
            Tags = new ObservableCollection<Tag>();
            foreach (var tag in CurrentClient.Tag)
            {
                Tags.Add(tag);
            }
            listTag = Tags.ToList();
           
            //заполняем коллекцию полов
            Genders = new ObservableCollection<string>();
            foreach (var gender in entities.Gender)
            {
                Genders.Add(gender.Name);
            }

            //заполняем коллекцию все тегов из базы
            foreach (var tag in entities.Tag)
            {
                AllTags.Add(tag);
            }

            totalListTag = AllTags.ToList();
            ID = CurrentClient.ID;
            FirstName = CurrentClient.FirstName;
            LastName = CurrentClient.LastName;
            Patronomic = CurrentClient.Patronymic;
            Email = CurrentClient.Email;
            Phone = CurrentClient.Phone;
            BirthDay = CurrentClient.Birthday.Value;
            SelectedGender = CurrentClient.Gender.Name;
            PhotoSource = CurrentClient.PhotoPath;
            Photo = CurrentClient.PhotoPath;
            standartPhoto = PhotoSource;
        }
        public Client CurrentClinet
        {
            get => currentClient;
            set
            {
                currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }


        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags
        {
            get => tags;
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged();
                }
            }
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

        public Tag SelectedAddTeg
        {
            get => selectedAddTag;
            set
            {
                selectedAddTag = value;
                OnPropertyChanged("SelectedAddTeg");
            }
        }
        public Tag SelectedRemoveTag
        {
            get => selectedRemoveTag;
            set
            {
                selectedRemoveTag = value;
            }
        }

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
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

        public string Photo
        {
            get => photo;
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
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
        public string TagTitle
        {
            get => tagTitle;
            set
            {
                tagTitle = value;
                OnPropertyChanged("TagTitle");
            }
        }

        public string ColorHex
        {
            get => colorHex;
            set
            {
                colorHex = value;
                OnPropertyChanged("ColorHex");
            }
        }


        //комманда загрузки изображения (FileDialog)
        private RelayCommand loadImage;
        public RelayCommand LoadImage
        {
            get
            {
                return loadImage ??
                  (loadImage = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              PhotoSource = dialogService.FilePath;
                              Photo = Guid.NewGuid().ToString() + ".png"; ;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }

                  }));
            }
        }

        //Валидация данных
        private bool Validate()
        {
            if (ValidateString(LastName, 50)
                && ValidateString(FirstName, 50)
                && ValidateString(Patronomic, 50)
                && ValidateEmail(Email)
                && ValidatePhone(Phone)
                && !String.IsNullOrEmpty(Photo))
                return true;

            return false;
        }

        //валидация имени, фамилии и отчества
        private bool ValidateString(string str, int countOfSymbols)
        {
            if (str.Length <= countOfSymbols)
            {
                foreach (var ch in str)
                {
                    if (!char.IsLetter(ch))
                    {
                        if (!char.IsWhiteSpace(ch) || ch != '-')
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
                if (!char.IsNumber(ch))
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

        //команда добавления тега клиента
        private RelayCommand addTagToClient;
        public RelayCommand AddTagToClient
        {
            get
            {
                return addTagToClient ??
                  (addTagToClient = new RelayCommand(obj =>
                  {
                      if (SelectedAddTeg != null)
                      {
                          bool exist = false;
                          listTag = Tags.ToList();
                          foreach (var tag in listTag)
                          {
                              if (tag.Title.Equals(SelectedAddTeg.Title))
                              {
                                  exist = true;
                              }
                          }
                          if (exist == false)
                          {
                              listTag.Add(SelectedAddTeg);
                              Tags = new ObservableCollection<Tag>(listTag);
                          }
                          else MessageBox.Show("Такой тег у клиента уже есть!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                      }
                  }));
            }
        }
        
        //команда удаления тега клиента
        private RelayCommand removeTagFromClient;
        public RelayCommand RemoveTagFromClient
        {
            get
            {
                return removeTagFromClient ??
                  (removeTagFromClient = new RelayCommand(obj =>
                  {
                      if (SelectedRemoveTag != null)
                      {
                          foreach (var tag in listTag)
                          {
                              if (tag.Title.Equals(SelectedRemoveTag.Title))
                              {
                                  listTag.Remove(tag);
                                  break;
                              }
                          }
                          Tags = new ObservableCollection<Tag>(listTag);
                      }
                      else
                      {
                          MessageBox.Show("Выберите тег!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }

        //комманда удаления тега из бд
        private RelayCommand removeTagFromDB;
        public RelayCommand RemoveTagFromDB
        {
            get
            {
                return removeTagFromDB ??
                  (removeTagFromDB = new RelayCommand(obj =>
                  {
                      bool exist = false;
                      if (SelectedAddTeg != null)
                      {
                          foreach (var usertag in listTag)
                          {
                              if (usertag.Title.Equals(SelectedAddTeg.Title))
                              {
                                  exist = true;
                              }
                          }
                          if (!exist)
                          {
                              if (entities.Tag.FirstOrDefault(p => p.Title.Equals(SelectedAddTeg.Title)).Client.Count == 0)
                              {
                                  foreach (var tag in totalListTag)
                                  {
                                      if (tag.Title.Equals(SelectedAddTeg.Title))
                                      {
                                          totalListTag.Remove(tag);
                                          entities.Tag.Remove(tag);
                                          entities.SaveChanges();
                                          break;
                                      }
                                  }

                                  AllTags = new ObservableCollection<Tag>(totalListTag);

                              }
                              else MessageBox.Show("Этот тег привязан к одному или нескольким клиентам!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                          }
                          else MessageBox.Show("Этот тег привязан к этому клиенту!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

                      }
                      else
                      {
                          MessageBox.Show("Выберите тег!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }
         
        //комманда добавления тега в бд
        private RelayCommand addTagToDB;
        public RelayCommand AddTagToDB
        {
            get
            {
                return addTagToDB ??
                  (addTagToDB = new RelayCommand(obj =>
                  {
                      bool exist = false;
                      Tag newTag = new Tag
                      {
                          Title = TagTitle,
                          Color = ColorHex
                      };
                      if (ValidateTag(newTag))
                      {
                          foreach(var tag in totalListTag)
                          {
                              if (newTag.Title.Equals(tag.Title))
                              {
                                  exist = true;
                              }
                          }
                          if (exist == false)
                          {
                              totalListTag.Add(newTag);
                              AllTags = new ObservableCollection<Tag>(totalListTag);
                              entities.Tag.Add(newTag);
                              entities.SaveChanges();
                          }
                          else
                          {
                              MessageBox.Show("Такой тег уже существует!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                      }
                      else
                      {
                          MessageBox.Show("Введите корректные данные!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }


        //валидация тега
        private bool ValidateTag(Tag tag)
        {
            if(tag.Color.Length == 6)
            {
                foreach (var ch in tag.Color)
                {
                    if(ch!='A' && ch!= 'B' && ch!='C' && ch!='D' && ch!='F' && !char.IsDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //комманда сохранения изменений
        private RelayCommand saveChanges;
        public RelayCommand SaveChanges
        {
            get
            {

                return saveChanges ??
                  (saveChanges = new RelayCommand(obj =>
                  {

                      if (Validate())
                      {
                          int ownerId;
                          List<int> childIds = new List<int>();
                          Client refactorClient = entities.Client.Find(ID);
                          using (var context = new Auto_serviceEntities())
                          {
                              ownerId = (from c in context.Client
                                         where c.ID == refactorClient.ID
                                         select c).First().ID;
                          }
                          using (var context = new Auto_serviceEntities())
                          {
                              for (int i = 0; i < Tags.Count; i++)
                              {
                                  childIds.Add(context.Tag.ToList().FirstOrDefault(p => p.Title.Equals(Tags[i].Title)).ID);
                              }
                          }
                          refactorClient.FirstName = FirstName;
                          refactorClient.LastName = LastName;
                          refactorClient.Patronymic = Patronomic;
                          refactorClient.Email = Email;
                          refactorClient.GenderCode = SelectedGender[0].ToString();
                          refactorClient.Birthday = BirthDay;
                          refactorClient.Phone = Phone;

                          using (var context = new Auto_serviceEntities())
                          {
                              var owner = (from o in context.Client
                                           select o).FirstOrDefault(o => o.ID == ownerId);
                              owner.Tag.Clear();
                              for (int i = 0; i < childIds.Count; i++)
                              {
                                  var child = (from o in context.Tag
                                               select o).ToList().FirstOrDefault(c => c.ID == childIds[i]);
                                  owner.Tag.Add(child);
                                  context.Tag.Attach(child);
                              }
                              context.SaveChanges();
                          }


                          if (PhotoSource != standartPhoto)
                          {
                              //File.Delete(@"../../Resources/" + standartPhoto);
                              refactorClient.PhotoPath = @"Клиенты\" + Photo;
                              fileService.Save(PhotoSource, Photo);
                          }
                          else
                          {
                              refactorClient.PhotoPath = Photo;
                          }
                          CurrentClient = refactorClient;

                          entities.SaveChanges();

                          MessageBox.Show("Клиент Обновлён!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                          DialogResult = true;
                      }
                      else
                      {
                          MessageBox.Show("Введите корректные данные!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }


                  }));
            }
        }


        //реализация события OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
