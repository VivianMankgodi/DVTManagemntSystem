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
        ManagementSystemContext context = new ManagementSystemContext();
        
        public void insertProfile(string firstName, string lastName, string email, string passwordHash, bool isApproved, int departmentId, int genderId, int UserTypeid)
        {
            Profile c = new Profile(firstName, lastName, email, passwordHash, isApproved, departmentId, genderId, UserTypeid);

            context.Profiles.Add(c);
            context.SaveChanges();
        }

   


    }
    public class ProfileMapping
    {
    
  
}



}
    

