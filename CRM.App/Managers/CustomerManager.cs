
using CRM.Domain.Entity;
using CRM.App.Abstract;
using CRM.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.App.Common;

namespace CRM.App.Managers
{

    public class CustomerManager
    {

        CustomerService _customerService = new CustomerService();

        public CustomerManager()
        {

        }
        public void AddNewCustomerView(bool getAutoId = true, int id = 0)
        {
            long phoneNumber = 0;
            int idCustomer = 0;
            if (getAutoId)
            {
                Console.WriteLine("Dodawanie nowego Klienta:\r\n");
            }
            Console.WriteLine("Podaj nazwisko Klienta:");
            string surname = Console.ReadLine();
            Console.WriteLine("Podaj imię Klienta:");
            string name = Console.ReadLine();
            string prompt = "Podaj numer telefonu Klienta:";
            bool correct;
            do
            {
                Console.WriteLine(prompt);
                correct = Int64.TryParse(Console.ReadLine(), out phoneNumber);
                if (!correct)
                {
                    prompt = $"Numer telefonu ma nie poprawny format!\r\nSpróbuj ponownie.";
                }
            }
            while (correct == false);

            if (getAutoId)
            {
                idCustomer = _customerService.customers.GetNewId();
                
            }
            else
            {
                idCustomer = id;
            }
            
            Customer customer = new Customer(idCustomer, name, surname, phoneNumber);
            _customerService.customers.AddItem(customer);
            Console.Clear();
            Console.WriteLine($"Zapisano poprawnie dane Klienta Id: {idCustomer}\r\n");
        }


        public void RemoveCustomer(int id, bool showInfo = true)
        {
            int _id = 0;
            foreach (var el in _customerService.customers.GetAllItems())

            {
                if (el.Id == id)
                {
                    _customerService.customers.RemoveItem(el);
                    _id = id;
                    if (showInfo)
                    {
                        Console.WriteLine($"Usunięto dane Klienta Id: {id}\r\n");
                    }
                    break;
                }
            }
            if (_id != id)
            {
                Console.WriteLine($"Nie znaleziono Klienta o Id: {id}\r\n");
            }
        }


        public int ChoiseCustomerView()
        {
            bool correct;
            int customerId;
            do
            {
                Console.Clear();
                Console.WriteLine("Podaj Id Klienta");
                correct = Int32.TryParse(Console.ReadLine(), out customerId);
            }
            while (!correct);
            return customerId;
        }


        public void ShowAllCustomersList()
        {
            Console.WriteLine($"===== Lista Klientów ===== \r\n\r\nId | Imię i nazwisko | Numer tel.");
            foreach (var el in _customerService.customers.GetAllItems())
            {
                Console.WriteLine(el.Id + " | " + el.Name + " " + el.Surname + " | " + el.PhoneNumber);
            }
        }


        public bool CustomerFindView(int chosenField)
        {
            string fieldName = "";
            //switch (Int32.Parse(fieldName))
            switch (chosenField)
            {
                case 1:
                    fieldName = "Id";
                    break;
                case 2:
                    fieldName = "Surname";
                    break;
                case 3:
                    fieldName = "PhoneNumber";
                    break;
            }
            Console.WriteLine("Wprowadzć wyszukiwaną wartość:");

            if (_customerService.CustomerFind(fieldName, Console.ReadLine()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShowCustomersFoundList()
        {
            Console.Clear();
            Console.WriteLine($"===== Lista Klientów spełniającyh kryteria ({_customerService.foundCustomers.GetAllItems().Count}) =====  " +
                $"\r\n\r\nId | Imię i nazwisko | Numer tel.");
            foreach (var el in _customerService.foundCustomers.GetAllItems())
            {
                Console.WriteLine(el.Id + " | " + el.Name + " " + el.Surname + " | " + el.PhoneNumber);
            }
        }

        public int ShowCustormerDetails()
        {
            int typedId;
            int customerId = 0;
            bool correct;

            Console.WriteLine($"\r\nWprowadź Id Klienta, aby wyświetlić szczegóły:\r\n");
            do
            {
                correct = Int32.TryParse(Console.ReadLine(), out typedId);
            }
            while (!correct);
            Console.Clear();
            string customerInfo = "";
            correct = false;
            foreach (var el in _customerService.customers.GetAllItems())
            {
                if (typedId == el.Id)
                {
                    customerInfo = $"Karta Klienta Id: {el.Id}\r\n\r\n";
                    customerInfo = $"{ customerInfo}Id klienta: {el.Id}\r\n";
                    customerInfo = $"{ customerInfo}Imię: {el.Name}\r\n";
                    customerInfo = $"{ customerInfo}Nazwisko: {el.Surname}\r\n";
                    customerInfo = $"{ customerInfo}Telefon: {el.PhoneNumber}\r\n";
                    customerId = el.Id;
                    correct = true;
                    break;
                }
            }
            if (!correct)
            {
                customerInfo = "Brak danych do wyświetlenia.";
            }
            Console.WriteLine(customerInfo);
            return customerId;


        }


        public void CustomerEditView(int id)
        {
            int _id = 0;
            foreach (var el in _customerService.customers.GetAllItems())

            {
                if (el.Id == id)
                {
                    _customerService.customers.RemoveItem(el);
                    Console.WriteLine($"Usunięto dane Klienta Id: {id}\r\n");
                    _id = id;
                    break;
                }
            }
            if (_id != id)
            {
                Console.WriteLine($"Nie znaleziono Klienta o Id: {id}\r\n");
            }

        }

        public void CustomerDetailsService(int selectedMenu, int idCustomer)
        {
            Console.Clear();
            switch (selectedMenu)
            {
                case 1:
                    {
                        RemoveCustomer(idCustomer);
                    }
                    break;
                case 2:
                    {
                        RemoveCustomer(idCustomer, false);
                        AddNewCustomerView(false, idCustomer);
                    }
                    break;
            }
        }

        //public Customer GetCustomerById (int id)
        //{
        //    var cusotmer = _customerService.GetItemById(id);
        //    return cusotmer;
        //}
    }
}
