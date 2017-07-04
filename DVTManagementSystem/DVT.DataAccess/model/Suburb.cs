using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVT.DataAccess.model
{
  public   class Suburb
    {
        public Suburb()
        {

        }

        
        public int SuburbID { get; set; }
        [Required ]
        [StringLength(maximumLength:255)]
        public string SuburbName { get; set; }

        public Nullable<int> PostalCodeID { get; set; }

        public Nullable<int> CityID { get; set; }

        
        public virtual PostalCode postalCode { get; set; }
        public virtual City city { get; set; }


    }
}
