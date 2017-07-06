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
         //   profiles = new List<Profile>();
        }
<<<<<<< HEAD

        public Addresses(int unitno, string complexName, string streetno, string streetname, int addressTypeId, int suburbId)
=======
*/
        public Addresses(int unitno, string complexName, string streetno, string streetname)
>>>>>>> 501abd27d4ea0ffb9be2c0416a7efc65bc3ba5b2
        {          
            Unitno = unitno;
            ComplexName = complexName;
            Streetno = streetno;
            Streetname = streetname;
        }

        public int AddressesID { get; set; }
           
        public int Unitno { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string ComplexName { get; set; }
        [StringLength(10)]
        public string Streetno { get; set; }

        [StringLength(maximumLength:(255))]
        public string Streetname { get; set; }

        public virtual AddressType addressType { get; set; }
        public virtual Suburb  suburb { get; set; }
        
        public virtual  ICollection<Profile> profiles { get; set; }

    }
}
