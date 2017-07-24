using DVT.DataAccess.Context;
using DVT.DataAccess.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
            var obj = context.Profiles
                .Include(suburb=>suburb.Addresses.Select(sub=>sub.Suburb))
                .Include(city=> city.Addresses.Select(ct=>ct.Suburb.City))
                .Include(prov => prov.Addresses.Select(pr=>pr.Suburb.City.Province))
                .Include(addr=>addr.Addresses)
                .Where(_ => _.isApproved == false).ToList();
            
            //obj = context.Profiles.In(=> new { .Addresses.First().StreetName});
            // var profile = obj.FirstOrDefault();
            //Console.WriteLine(profile);

        }

        //public void UpdatePassword(string email, string passwordhash)
        //{
        //    var password = context.Profiles.Where(p => p.PasswordHash == passwordhash && p.Email == email && p.isApproved == true).FirstOrDefault();
        //    Console.WriteLine("Username: {0} ", password.FirstName);

        //    Profile pro = new Profile(passwordhash);
        //    Console.Write("enter new password: ");
        //    passwordhash = Console.ReadLine();
        //    password.PasswordHash = passwordhash;

        //    context.SaveChanges();
        //    Console.WriteLine("You successfully changed your password ");

        //    var UserDetails = (from pr in context.Profiles
        //                       join utype in context.userTypes on pr.UserType.UserTypeID equals utype.UserTypeID
        //                       join dep in context.Departments on pr.Department.DepartmentID equals dep.DepartmentID
        //                       join gen in context.Gender on pr.Gender.GenderID equals gen.GenderID
        //                       from ad in context.Addresses
        //                       join adtype in context.AddressTypes on ad.AddressType.AddressTypeID equals adtype.AddressTypeID
        //                       join sub in context.suburbs on ad.Suburb.SuburbID equals sub.SuburbID
        //                       join pos in context.PostalCodes on sub.PostalCodeID equals pos.PostalCodeID
        //                       join c in context.Cities on sub.CityID equals c.CityID
        //                       join prov in context.provinces on c.Province.ProvinceID equals prov.ProvinceID
        //                       where pr.Email == email
        //                       select new
        //                       {
        //                           pr.FirstName,
        //                           pr.Email,
        //                           pr.isApproved,
        //                           utype.UserTypeName,
        //                           dep.DepartmentName,
        //                           gen.GenderName,
        //                           adtype.AddressTypeName,
        //                           ad.UnitNo,
        //                           ad.StreetNo,
        //                           ad.StreetName,
        //                           ad.ComplexName,
        //                           sub.SuburbName,
        //                           pos.PostalCodeNumber,
        //                           c.CityName,
        //                           prov.ProvinceName
        //                       }).Distinct();
        //    foreach (var prof in UserDetails)
        //    {
        //        Console.WriteLine("FirstName: {0}, Email: {1}, isApproved: {2}, Usertype name: {3}, Department name: {4}, Gender type; {5} , AddressTypeName: {6}, Unitno: {7}, Streetno: {8}, Streetname: {9}, ComplexName: {10},SuburbName; {11}, PostalCodeNumber: {12}, CityName: {13},   ProvinceName: {14}\n", prof.FirstName, prof.Email, prof.isApproved, prof.UserTypeName, prof.DepartmentName, prof.GenderName, prof.AddressTypeName, prof.UnitNo, prof.StreetNo, prof.StreetName, prof.ComplexName, prof.SuburbName, prof.PostalCodeNumber, prof.CityName, prof.ProvinceName);
        //        //     Console.WriteLine("Username: {0}, oldpassword: {1} ", password.FirstName, password.PasswordHash);

        //    }




      //  }

    }
}




    

