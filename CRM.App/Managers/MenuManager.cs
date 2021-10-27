using CRM.App.Abstract;
using CRM.App.Common;
using CRM.App.Concrete;
using CRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.App.Managers
{
    public class MenuManager
    {

        public MenuService _menuService = new MenuService();

        public int CreateContextMenu(string group, bool clearView = false)
        {
            _menuService.contextMenuService.GetAllItems().Clear();
            foreach (var el in _menuService.menuService.GetAllItems())
            {
                if (el.Group == group || (el.Group == "common" && group != "main"))
                {
                    _menuService.contextMenuService.AddItem(el);
                }
            }
            ShowContextMenu(clearView);
            return ForceCorrectChoice();
        }

        private void ShowContextMenu(bool clearView = false)
        {
            if (clearView)
            {
                Console.Clear();
            }
            Console.WriteLine($"\r\nWybierz odpowiednią akcję i naciśnij Enter:\r\n");
            foreach (var el in _menuService.contextMenuService.GetAllItems())
            {
                {
                    Console.WriteLine(el.Id + " - " + el.Name);
                }
            }
        }


        private int CheckChosen()
        // sprawdza, czy wybrane przez uzytkownika menu istnieje
        // jesli tak, zwraca wybrany element. W przeciwnym razie, zwraca 0.
        {
            int idMenu = 0;
            int elId = 0;
           string  ChoosenIdMenu = Console.ReadLine();
            if (int.TryParse(ChoosenIdMenu, out idMenu))
            {
                foreach (var el in _menuService.contextMenuService.GetAllItems())
                {
                    if (el.Id == idMenu)
                    {
                        elId = el.Id;
                        break;
                    }
                }
            }
            return elId;
        }

        public int ForceCorrectChoice ()
        {
            int ChoosenIdMenu = CheckChosen();
            while (ChoosenIdMenu == 0)
            {
                Console.WriteLine("Wybrano niewłaściwą opcję. Spróbuj ponownie!");
                ChoosenIdMenu = CheckChosen();
            }
            return ChoosenIdMenu;
        }
    }
}
