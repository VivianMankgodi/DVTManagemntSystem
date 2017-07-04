using DVT.DataAccess.Context;
using DVT.DataAccess.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVT.DataAccess.DataAccesses
{
    public class DataAccess
    {
        public void insertProfile(string firstName, string lastName, string email, string passwordHash, bool isApproved)
        {

            Profile c = new Profile(firstName,lastName,email,passwordHash,isApproved);
            ManagementSystemContext context = new ManagementSystemContext();
            context.Profiles.Add(c);
            context.SaveChanges();
        }
    }
}
