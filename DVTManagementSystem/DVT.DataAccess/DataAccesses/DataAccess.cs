using DVT.DataAccess.Context;
using DVT.DataAccess.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;

namespace DVT.DataAccess.DataAccesses
{
    public class DataAccess
    {
        ManagementSystemContext context = new ManagementSystemContext();

        public void InsertProfile(string firstName, string lastName, string email, string passwordHash, bool isApproved, int genderid, int departmentID, int userTypeID)
        {
           
            Profile c = new Profile(firstName, lastName, email, passwordHash, isApproved);
            var gender = context.Gender.Find(genderid);
            c.Gender = gender;

            var department = context.Departments.Find(departmentID);
            c.Department = department;

            var usertype = context.userTypes.Find(userTypeID);
            c.UserType = usertype;

            context.Profiles.Add(c);
            context.SaveChanges();


            Profile profile = new Profile();
           // var UniqueNo = (from p in context.Profiles where p.ProfileID == p.ProfileID  select p.ProfileID).Distinct();
          // Console.WriteLine(UniqueNo );
        }

        public string uniqueNumber(int id)
        {
         Profile profile = new Profile(id);
            var UniqueNo = (from p in context.Profiles where p.ProfileID == id select p.ProfileID).Distinct( );
            foreach (var unique in UniqueNo )
            {
                Console.WriteLine("your unique number is: " + unique);
            }
            return "";
        }
       
        public void InsertAddresses(int UnitNo, string ComplexName, string StreetNo, string StreetName, int AddressTypeId, int SuburbID, int profilename)
        {
          
           var address = new Addresses(UnitNo, ComplexName, StreetNo, StreetName);

            var profil = context.Profiles.Find(profilename);
            if (profil == null)
            {

                Console.WriteLine("Profile Does Not Exist");
                return;
            }
            var p = new List<Profile>();
            p.Add(profil);
            address.Profiles = p;

            var addresstype = context.AddressTypes.Find(AddressTypeId);
            address.AddressType = addresstype;


            var suburb = context.suburbs.Find(SuburbID);
            address.Suburb = suburb;

            context.Addresses.Add(address);
            context.SaveChanges();

        }

        public void UpdateProfileAddress(int profileid, int AddressID)
        {
            var profile = context.Profiles.Where(x => x.ProfileID == profileid).FirstOrDefault();
            var address = context.Addresses.Where(a => a.AddressesID == AddressID).FirstOrDefault();

            profile.Addresses = new List<Addresses>();
            profile.Addresses.Add(address);
            address.Profiles.Add(profile);
            context.SaveChanges();

        }

        public void RemoveProfileAddress(int profileid, int AddressID)
        {
            var profile = context.Profiles.Include(x => x.Addresses).Where(x => x.ProfileID == profileid).FirstOrDefault();
            var address = context.Addresses.Where(a => a.AddressesID == AddressID).FirstOrDefault();

            
            profile.Addresses.Remove(address);

            context.SaveChanges();

        }

        public void RemoveProfile(int profileId)
        {
            context.Profiles.Remove(context.Profiles.Find(profileId));
         

        }

        public void SelectingUnapprovedProfile()
        {

            var unapproved = context.Profiles.Where(pr => pr.isApproved == false).Select(pro => new
            {
                pro.FirstName,
                pro.LastName,
                pro.Gender.GenderName,
                pro.Department.DepartmentName,
                pro.isApproved,
                streetNum = pro.Addresses.FirstOrDefault(add => add.AddressType.AddressTypeID == 1) != null ? pro.Addresses.FirstOrDefault().UnitNo : 0,
                StreetName = pro.Addresses.FirstOrDefault(add=> add.AddressType.AddressTypeID== 1)!= null? pro.Addresses.FirstOrDefault().StreetName :"",
                pro.Addresses.FirstOrDefault().ComplexName,pro.Addresses.FirstOrDefault().StreetNo, pro.Addresses.FirstOrDefault().Suburb.SuburbName, pro.Addresses.FirstOrDefault().Suburb.City.CityName,pro.Addresses.FirstOrDefault().Suburb.City.Province.ProvinceName
            }).Distinct();

            string replace = "";

            foreach (var UnapprovedUser in unapproved )
            {
                
                Console.WriteLine(UnapprovedUser.ToString().Replace("{","\n").Replace("}","\n")) ;
            }
 
        }

        public void UpdatePassword(string email, string passwordhash)
        {
            var password = context.Profiles.Where(p => p.PasswordHash == passwordhash && p.Email == email && p.isApproved == true).FirstOrDefault();
            Console.WriteLine("Username: {0} ", password.FirstName);

            Profile pro = new Profile(passwordhash);
            Console.Write("enter new password: ");
            passwordhash = Console.ReadLine();
           password.PasswordHash = passwordhash;
       

            context.SaveChanges();
        //    Console.WriteLine("You successfully changed your password ");
        



           
          




        }

    }
}




    

