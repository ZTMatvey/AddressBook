using AddressBook.Model;
using HelpDef.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            _people = new ObservableCollection<Person>();
            HomeCommand = new RelayCommand(execute: Home);
            BookCommand = new RelayCommand(execute: Book);
            AddCommand = new RelayCommand(execute: Add);
        }

        private void Home(object? obj) => CurrentView = new HomeVM();

        private void Book(object? obj) => CurrentView = new BookVM(_people);

        private void Add(object? obj) => CurrentView = new AddVM(_people);
    }
}
