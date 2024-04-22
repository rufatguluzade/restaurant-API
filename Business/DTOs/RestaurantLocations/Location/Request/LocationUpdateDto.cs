using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.RestaurantLocations.Location.Request
{
    public class LocationUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public int OpeningHoursId { get; set; }
    }
}
