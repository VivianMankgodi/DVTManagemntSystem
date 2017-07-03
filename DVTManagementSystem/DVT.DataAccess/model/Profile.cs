using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DVT.DataAccess.model;

namespace DVT.DataAccess
{
  public   class Profile
    {
        public int ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isApproved { get; set; }
        public virtual Department department { get; set; }
        public virtual Gender gender { get; set; }
        public virtual UserType usertype { get; set; }
        public ICollection<Logs> logs { get; set; }

    }
}
