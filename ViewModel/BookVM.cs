using AddressBook.Model;
using HelpDef.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.ViewModel
{
    internal sealed class BookVM : ViewModelBase
    {
        public ObservableCollection<Person> Addresses { get; set; }

        public BookVM()
        {
            var factory = new PersonFactory(0);
            Addresses = new ObservableCollection<Person>
            {
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123"),
                factory.Create("Alex", "123")
            };
        }
    }
}
