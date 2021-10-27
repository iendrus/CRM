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

        public BaseService<Customer> customers = new BaseService<Customer>();
        public BaseService<Customer> foundCustomers;


        public int CustomerFind(string findField, string findValue)
        {
            foundCustomers = new BaseService<Customer>();

            foreach (var el in customers.GetAllItems())
            {
                switch (findField)
                {
                    case "Id":
                        if (Int32.Parse(findValue) == el.Id)
                        {
                            foundCustomers.AddItem(el);
                        }
                        break;
                    case "Surname":
                        if (findValue.ToLower() == el.Surname.ToLower())
                        {
                            foundCustomers.AddItem(el);
                        }
                        break;
                    case "PhoneNumber":
                        if (Int64.Parse(findValue) == el.PhoneNumber)
                        {
                            foundCustomers.AddItem(el);
                        }
                        break;
                }
            }
            return foundCustomers.GetAllItems().Count;
        }
    }
}
