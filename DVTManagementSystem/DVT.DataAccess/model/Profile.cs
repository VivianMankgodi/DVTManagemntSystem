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
            this.gender = gender;
            //GenderID = genderId;
            //UserTypeID = UserTypeid;
            //DepartmentID = departmentId;
        }

        public Profile()
        {

        }

        public Profile()
        {
           // addresses = new List<Addresses>();
        }
        public int ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isApproved { get; set; }
        //public Nullable< int> DepartmentID { get; set; }
        //public Nullable<int> GenderID { get; set; }
        //public Nullable<int> UserTypeID { get; set; }
        public virtual Department department { get; set; }
        public virtual Gender gender { get; set; }
        public virtual UserType usertype { get; set; }
        public virtual  ICollection<Logs> logs { get; set; }
        public virtual ICollection<Addresses> addresses { get; set; }

    }
}
