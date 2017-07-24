using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
 public    class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public virtual ICollection <Profile> Profile { get; set; }
    }
}
