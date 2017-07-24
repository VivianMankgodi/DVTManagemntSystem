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
        public Profile( string firstName, string lastName, string email, string passwordHash, bool isApproved)
        {
          
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            this.isApproved = isApproved;
            
        }

        public Profile(int profileId)
        {
            ProfileID = profileId;
        }
        public Profile(string passsword)
        {

        }
        public Profile()
        {

        }

        public int ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isApproved { get; set; }
        public virtual Department Department { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual UserType UserType { get; set; }
        public ICollection<Logs> Logs { get; set; }
        public ICollection<Addresses> Addresses { get; set; }

    }
}
