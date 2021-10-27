using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Group { get; set; }

        public Menu(int id, string name, string group)
        {
            Id = id;
            Name = name;
            Group = group;
        }

    }
    

}
