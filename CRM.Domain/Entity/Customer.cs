using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Common;

namespace CRM.Domain.Entity
{
    public class Customer : BaseEntity

    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }

        public Customer(int id,  string name, string surname, long phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public Customer()
        {
        }
    }

}
