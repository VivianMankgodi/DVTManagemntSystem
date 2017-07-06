﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVT.DataAccess.model
{
   public  class Addresses
    {
       /* public Addresses()
        {
        }
*/
        public Addresses(int unitno, string complexName, string streetno, string streetname)
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
        
        public ICollection<Profile> profiles { get; set; }

    }
}