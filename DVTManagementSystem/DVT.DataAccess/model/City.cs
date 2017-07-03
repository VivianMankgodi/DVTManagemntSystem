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

        //[ForeignKey("ProvinceID")]
        //public Nullable<int> ProvinceID { get; set; }

        public virtual Province province { get; set; }

        public virtual ICollection<Suburb > suburbs { get; set; }
    }
}
