using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Composition { get; set; }

        public int SubMenuId { get; set; }
        public SubMenu SubMenu { get; set; }
    }
}
