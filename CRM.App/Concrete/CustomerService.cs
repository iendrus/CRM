using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.App.Abstract;
using CRM.App.Common;
using CRM.Domain.Entity;

namespace CRM.App
{ 
    public class CustomerService : BaseService<Customer>
    {

        public BaseService<Customer> Customers = new BaseService<Customer>();
        public BaseService<Customer> FoundCustomers;


        public int CustomerFind(string findField, string findValue)
        {
            FoundCustomers = new BaseService<Customer>();

            foreach (var el in Customers.GetAllItems())
            {
                switch (findField)
                {
                    case "Id":
                        if (Int32.Parse(findValue) == el.Id)
                        {
                            FoundCustomers.AddItem(el);
                        }
                        break;
                    case "Surname":
                        if (findValue.ToLower() == el.Surname.ToLower())
                        {
                            FoundCustomers.AddItem(el);
                        }
                        break;
                    case "PhoneNumber":
                        if (Int64.Parse(findValue) == el.PhoneNumber)
                        {
                            FoundCustomers.AddItem(el);
                        }
                        break;
                }
            }
            return FoundCustomers.GetAllItems().Count;
        }
    }
}
