using Business.DTOs.SubMenu.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.DTOs.Product.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Composition { get; set; }
        public int SubMenuId { get; set; }

        
        public SubMenuResponseDto SubMenu { get; set; }
    }
}
