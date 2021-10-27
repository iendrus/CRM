using CRM.App.Common;
using CRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.App.Concrete
{

    public class MenuService : BaseService<Menu>
    {

        public BaseService<Menu> menuService = new BaseService<Menu>();
        public BaseService<Menu> contextMenuService = new BaseService<Menu>();

        public MenuService()
        {
            Initialize();
        }
                
        public void Initialize()
        {
            menuService.AddItem(new Menu(1, "Dodaj nowego Klienta", "main"));
            menuService.AddItem(new Menu(2, "Znajdź Klienta", "main"));
            menuService.AddItem(new Menu(3, "Wyświetl listę Klientów", "main"));
            menuService.AddItem(new Menu(4, "Usun Klienta", "main"));
            menuService.AddItem(new Menu(5, "Wyświetl kartę Klienta", "main"));
            menuService.AddItem(new Menu(6, "Zakończ program", "main"));
            menuService.AddItem(new Menu(1, "Wyszukaj wg Id Klienta", "customerFind"));
            menuService.AddItem(new Menu(2, "Wyszukaj wg nazwiska", "customerFind"));
            menuService.AddItem(new Menu(3, "Wyszukaj wg Numeru telefonu", "customerFind"));
            menuService.AddItem(new Menu(1, "Usuń Klienta", "customerDetails"));
            menuService.AddItem(new Menu(2, "Edytuj dane Klienta", "customerDetails"));
            menuService.AddItem(new Menu(9, "Powrót do menu głównego", "common"));
        }
    }
}
