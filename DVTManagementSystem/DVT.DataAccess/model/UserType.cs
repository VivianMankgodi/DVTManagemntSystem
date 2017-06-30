using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
    class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }

        public virtual Profile profile { get; set; }
    }
}
