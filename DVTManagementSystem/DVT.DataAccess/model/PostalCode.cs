using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVT.DataAccess.model
{
   public  class PostalCode
    {
        public PostalCode()
        {

        }

        public int PostalCodeID { get; set; }
        [Required]
        [StringLength(4)]
        public string PostalCodeNumber { get; set; }
        public virtual  ICollection<Suburb> Suburb { get; set; }

    }
}
