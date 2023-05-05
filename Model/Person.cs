using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    internal sealed class Person
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public Person(int id, string fullName, string phone)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
        }
    }
}
