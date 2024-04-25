using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Menu :BaseEntity
    {
        public string Name { get; set; }

        public ICollection<SubMenu> SubMenus { get; set; }
    }
}
