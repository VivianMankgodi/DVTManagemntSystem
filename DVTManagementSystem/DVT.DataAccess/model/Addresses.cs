using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVT.DataAccess.model
{
   public class Addresses
    {
        public Addresses(int unitno, string complexName, string streetno, string streetname)
        {
            UnitNo = unitno;
            ComplexName = complexName;
            StreetNo = streetno;
            StreetName = streetname;
        }

        public Addresses()
        {
            
        }

        public int AddressesID { get; set; }
        public int UnitNo { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string ComplexName { get; set; }
        [StringLength(10)]
        public string StreetNo { get; set; }
        [StringLength(maximumLength:(255))]
        public string StreetName { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual Suburb  Suburb { get; set; }
        public ICollection<Profile> Profiles { get; set; }

    }
}
