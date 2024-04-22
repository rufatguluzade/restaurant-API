using DocumentFormat.OpenXml.Office2013.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Locations : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        [Phone]
        public int Phone { get; set; }


        public int OpeningHoursId { get; set; }
        public OpeningHours OpeningHours { get; set; }

    }
}
