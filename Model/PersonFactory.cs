using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    internal sealed class PersonFactory
    {
        private int _lastId;

        public PersonFactory(int lastId)
        {
            _lastId = lastId;
        }

        public Person Create(string fullName, string phone)=> new Person(GetId(), fullName, phone);

        private int GetId() => ++_lastId;
    }
}
