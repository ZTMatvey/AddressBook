﻿using AddressBook.Model;
using AddressBook.Validators;
using HelpDef.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    internal sealed class AddVM : ViewModelBase
    {
        private int MIN_CHARACTERS = 2;
        private int MAX_CHARACTERS = 50;
        private ICollection<Person> _people;
        private PersonFactory _personFactory;

        public ICommand AddCommand { get; set; }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();
                UpdateButtonState();
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
                UpdateButtonState();
            }
        }

        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public AddVM(ICollection<Person> people)
        {
            _people = people;
            _personFactory = new PersonFactory(people.Count > 0 ? people.Max(e => e.Id) : 0);
            AddCommand = new RelayCommand(execute: Add);
            IsButtonEnabled = false;
        }

        private void Add(object? o)
        {
            _people.Add(_personFactory.Create(FullName, Phone));
            FullName = string.Empty;
            Phone = string.Empty;
        }

        private void UpdateButtonState()
        {
            IsButtonEnabled = MinMaxCharacters.IsValid(FullName, MIN_CHARACTERS, MAX_CHARACTERS) && PhoneText.IsValid(Phone);
        }
    }
}
