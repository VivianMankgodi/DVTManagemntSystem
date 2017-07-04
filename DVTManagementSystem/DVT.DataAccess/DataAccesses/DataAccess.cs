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

        public void InsertAddresses(int UnitNo, string ComplexName, string StreetNo, string StreetName, int AddressTypeId, int SuburbID, int profileid)
        {
            var profile = context.Profiles.Find(1);
            Addresses address = new Addresses(UnitNo, ComplexName, StreetNo, StreetName, AddressTypeId, SuburbID);
            address.profiles.Add(profile);
            context.Addresses.Add(address);
            context.SaveChanges();


        }


    }
    public class ProfileMapping
    {
    
  
}



}
    

