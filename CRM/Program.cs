using CRM.App;
using CRM.App.Abstract;
using CRM.App.Common;
using CRM.App.Concrete;
using CRM.App.Managers;
using CRM.Domain.Entity;
using System;

namespace CRM
{
    class Program
    { 
        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager();
            CustomerManager customerManager = new CustomerManager();
            Console.WriteLine($"Witaj w systemie CRM!\r\n");
            HandleMainManu();

            void HandleMainManu()
            {
                int chosenMenu = menuManager.CreateContextMenu("main");
                //int chosenMenu = menuManager.ForceCorrectChoice();
                Console.Clear();
                switch (chosenMenu)
                {
                    case 1:
                        {
                            customerManager.AddNewCustomerView();
                        }
                        break;
                    case 2:
                        {
                           chosenMenu =  menuManager.CreateContextMenu("customerFind", true);
                            if (customerManager.CustomerFindView(chosenMenu))
                            {
                                customerManager.ShowCustomersFoundList();
                                int idCustomer = customerManager.ShowCustormerDetails();
                                chosenMenu = menuManager.CreateContextMenu("customerDetails");
                                customerManager.CustomerDetailsService(chosenMenu, idCustomer);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Nie znaleziono danych.");
                            }
                        }
                        break;
                    case 3:
                        {
                            customerManager.ShowAllCustomersList();
                        }
                        break;
                    case 4:
                        {
                            customerManager.RemoveCustomer(customerManager.ChoiseCustomerView());
                        }
                        break;
                    case 5:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                
                HandleMainManu();
            }
        }
    }
}

