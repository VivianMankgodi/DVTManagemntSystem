using DVT.DataAccess.Context;
using DVT.DataAccess.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DVT.DataAccess.DataAccesses
{
    public class DataAccess
    {
        ManagementSystemContext context = new ManagementSystemContext();
        
        public void insertProfile(string firstName, string lastName, string email, string passwordHash, bool isApproved ,int genderid,int departmentID,int userTypeID)
        {
            Profile c = new Profile(firstName, lastName, email, passwordHash, isApproved);
            var gender = context.Gender.Find(genderid);
            c.gender = gender;

            var department = context.Departments.Find(departmentID);
            c.department = department;

            var usertype = context.userTypes.Find(userTypeID);
            c.usertype = usertype;

            context.Profiles.Add(c);
           context.SaveChanges();
        }

        public void InsertAddresses(int UnitNo, string ComplexName, string StreetNo, string StreetName, int AddressTypeId, int SuburbID, int profileid)
        {
           
            Addresses address = new Addresses(UnitNo, ComplexName, StreetNo, StreetName);

            var profil = context.Profiles.Find(profileid);
            List<Profile> p = new List<Profile>();
            p.Add(profil);
            address.profiles = p;

            var addresstype = context.AddressTypes.Find(AddressTypeId);
            address.addressType = addresstype;


            var suburb = context.suburbs.Find(SuburbID);
            address.suburb = suburb;

            context.Addresses.Add(address);
            context.SaveChanges();

        }

        public void UpdateProfileAddress(int profileid, int AddressID)
        {
            var profile = context.Profiles.Where(x => x.ProfileID == profileid).FirstOrDefault();
            var address = context.Addresses.Where(a => a.AddressesID == AddressID).FirstOrDefault();

            profile.addresses = new List<Addresses>();
            profile.addresses.Add(address);
            address.profiles.Add(profile);
            context.SaveChanges();


        }
        public void RemoveProfileAddress(int profileid, int AddressID)
        {
            var profile = context.Profiles.Include(x => x.addresses).Where(x => x.ProfileID == profileid).FirstOrDefault();
            var address = context.Addresses.Where(a => a.AddressesID == AddressID).FirstOrDefault();
       
            profile.addresses.Remove(address);
          
            context.SaveChanges();


        }
        public void RemoveProfile(int profileId)
        {
            var profile = context.Profiles.Find(profileId);
            var profile2 = context.Profiles.Find(profile);

        }


    }
    
  




}
    

