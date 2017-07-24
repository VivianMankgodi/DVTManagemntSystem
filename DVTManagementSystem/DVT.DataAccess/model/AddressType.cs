using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVT.DataAccess.model
{
 public    class AddressType
    {
        public AddressType()
        {

        }
        
        public int AddressTypeID { get; set; }
        [Required ]
        [StringLength(20)]
        public string AddressTypeName { get; set; }
        public virtual  ICollection<Addresses > Address { get; set; }

        
    }
}
