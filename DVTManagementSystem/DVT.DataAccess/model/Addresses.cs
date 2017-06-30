using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVT.DataAccess.model
{
   public  class Addresses
    {
        public Addresses()
        {
        }
        [Key ]
        public int AddressID { get; set; }
        
        public Nullable<int> AddressTypeID { get; set; }
        public Nullable<int> SuburbID { get; set; }        
        public int Unitno { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string ComplexName { get; set; }
        [StringLength(10)]
        public string Streetno { get; set; }

        [StringLength(maximumLength:(255))]
        public string Streetname { get; set; }

        public AddressType addressType { get; set; }
        public Suburb  suburb { get; set; }
    }
}
