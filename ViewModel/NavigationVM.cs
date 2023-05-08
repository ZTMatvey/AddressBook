using AddressBook.Model;
using HelpDef.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AddressBook.ViewModel
{
    internal sealed class NavigationVM : ViewModelBase
    {
        private ObservableCollection<Person> _people;
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get
            {
                return _currentView;
            }
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand HomeCommand { get; set; }

        public ICommand BookCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public NavigationVM()
        {
            Home(new object());
            LoadPeople();
            HomeCommand = new RelayCommand(execute: Home);
            BookCommand = new RelayCommand(execute: Book);
            AddCommand = new RelayCommand(execute: Add);
        }

        public void LoadPeople()
        {
            if (!File.Exists("people.xml"))
            {
                _people = new ObservableCollection<Person>();
                return;
            }

            using var stream = new FileStream("people.xml", FileMode.OpenOrCreate);
            using var reader = new StreamReader(stream);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            _people = (ObservableCollection<Person>)serializer.Deserialize(reader);
        }

        public void SavePeople()
        {
            using var stream = new FileStream("people.xml", FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            serializer.Serialize(stream, _people);
        }

        private void Home(object? obj) => CurrentView = new HomeVM();

        private void Book(object? obj) => CurrentView = new BookVM(_people);

        private void Add(object? obj) => CurrentView = new AddVM(_people);
    }
}
