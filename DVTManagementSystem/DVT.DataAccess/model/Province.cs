
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
  public   class Province
    {
        public Province()
        {

        }

        [Key ]
        public int ProvinceID { get; set; }
        [Required]
        [StringLength(50)]
        public string ProvinceName { get; set; }
       
        public virtual  ICollection<City> Cities { get; set; }
    }
}
