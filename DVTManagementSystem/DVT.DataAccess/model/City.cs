using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
 public    class City
    {
        public City()
        {

        }
        public int CityID { get; set; }

        [Required]
        [StringLength(maximumLength:255)]
        public string CityName { get; set; }

        public int ProvinceID { get; set; }

        public virtual Province Province { get; set; }

        public virtual ICollection<Suburb > Suburb { get; set; }
    }
}
