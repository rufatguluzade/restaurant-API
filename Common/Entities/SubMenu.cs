using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class SubMenu :BaseEntity
    {
        public string Name { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
