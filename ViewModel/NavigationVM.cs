using HelpDef.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    internal sealed class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
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

        public NavigationVM()
        {
            Home(new object());
            HomeCommand = new RelayCommand(execute: Home);
            BookCommand = new RelayCommand(execute: Book);
        }

        private void Home(object obj) => CurrentView = new HomeVM();

        private void Book(object obj) => CurrentView = new BookVM();
    }
}
