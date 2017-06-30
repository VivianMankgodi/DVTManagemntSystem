using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
   public class Profile
    {
        public int ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; }


        public ICollection<Logs> logs { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isApproved { get; set; }

        public virtual ICollection<Department> department { get; set; }
        public virtual ICollection<Gender> gender { get; set; }
        public virtual UserType usertype { get; set; }

    }
}
