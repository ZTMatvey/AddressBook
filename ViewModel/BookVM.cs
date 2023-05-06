using AddressBook.Model;
using HelpDef.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    internal sealed class BookVM : ViewModelBase
    {
        public ObservableCollection<Person> People { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public BookVM(ObservableCollection<Person> people)
        {
            People = people;
            DeleteCommand = new RelayCommand(execute: Delete);
            EditCommand = new RelayCommand(execute: o => MessageBox.Show(""));
        }

        private void Delete(object? o)
        {
            if (_selectedPerson != null)
            {
                People.Remove(_selectedPerson);
            }
        }
    }
}
