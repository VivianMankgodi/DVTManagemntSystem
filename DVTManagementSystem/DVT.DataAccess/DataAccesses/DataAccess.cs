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

        public void insertProfile(string firstName, string lastName, string email, string passwordHash, bool isApproved, int genderid, int departmentID, int userTypeID)
        {
            int gendertype;
            Console.Write("Enter your Firstname: ");
            firstName = Console.ReadLine();
            Console.Write("Enter your Lastname: ");
            lastName = Console.ReadLine();
            Console.Write("Enter your Email: ");
            email = Console.ReadLine();

            Console.Write("Enter a password: ");
            passwordHash = Console.ReadLine();
            SHA256 hash = new SHA256Cng();
            
            byte[] hashvalue = hash.ComputeHash(Encoding.UTF8.GetBytes(passwordHash));
            passwordHash =System.Text.Encoding.Default.GetString(hashvalue);
            Console.WriteLine(passwordHash);            
            isApproved = false;
            Console.WriteLine("Gender: \n 1. Male\n 2. Female");
            Console.Write("Enter gender number: ");
            genderid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Department:\n1.GMIC \n 2. GMOB\n 3. GQUA");
            Console.Write("Enter department number you belong to: ");
            departmentID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("User type:\n 1. Admin\n 2. Employee");
            Console.Write("Enter user type: ");
            userTypeID = Convert.ToInt32(Console.ReadLine());
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
            Console.Write("enter a UnitNo: ");
            UnitNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter comple name: ");
            ComplexName = Console.ReadLine();
            Console.Write("Enter Street number: ");
            StreetNo = Console.ReadLine();
            Console.Write("Enter StreeName: ");
            StreetName = Console.ReadLine();
            Console.WriteLine("Address type:\n 1. Physicla Address\n  2. Postal Address");
            Console.Write("Enter Address type: ");
            AddressTypeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Suburb: ");
            SuburbID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your unique Number: ");
            profileid = Convert.ToInt32(Console.ReadLine());


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

        public void SelectingUnapprovedProfile()
        {
            var Unaproved = (from pr in context.Profiles
                             join utype in context.userTypes on pr.UserTypeID equals utype.UserTypeID
                             join dep in context.Departments on pr.DepartmentID equals dep.DepartmentID
                             join gen in context.Gender on pr.GenderID equals gen.GenderID
                             from ad in context.Addresses
                             join adtype in context.AddressTypes on ad.AddressTypeID equals adtype.AddressTypeID
                             join sub in context.suburbs on ad.SuburbID equals sub.SuburbID
                             join pos in context.PostalCodes on sub.PostalCodeID equals pos.PostalCodeID
                             join c in context.Cities on sub.CityID equals c.CityID
                             join prov in context.provinces on c.ProvinceID equals prov.ProvinceID
                             where pr.isApproved == false
                             select new
                             {
                                 pr.FirstName,
                                 pr.Email,
                                 pr.isApproved,
                                 utype.UserTypeName,
                                 dep.DepartmentName,
                                 gen.GenderName,
                                 adtype.AddressTypeName,
                                 ad.Unitno,
                                 ad.Streetno,
                                 ad.Streetname,
                                 ad.ComplexName,
                                 sub.SuburbName,
                                 pos.PostalCodeNumber,
                                 c.CityName,
                                 prov.ProvinceName
                             }).Distinct();
            foreach (var prof in Unaproved)
            {
                Console.WriteLine("FirstName: {0}, Email: {1}, isApproved: {2}, Usertype name: {3}, Department name: {4}, Gender type; {5} , AddressTypeName: {6}, Unitno: {7}, Streetno: {8}, Streetname: {9}, ComplexName: {10},SuburbName; {11}, PostalCodeNumber: {12}, CityName: {13},   ProvinceName: {14}\n", prof.FirstName, prof.Email, prof.isApproved, prof.UserTypeName, prof.DepartmentName, prof.GenderName, prof.AddressTypeName, prof.Unitno, prof.Streetno, prof.Streetname, prof.ComplexName, prof.SuburbName, prof.PostalCodeNumber, prof.CityName, prof.ProvinceName);
            }
        }


        public void UpdatePassword(string email, string passwordhash)
        {


            Console.Write("Enter your email: ");
            email = Console.ReadLine();
            Console.Write("Enter your password: ");
            passwordhash = Console.ReadLine();
            var password = context.Profiles.Where(p => p.PasswordHash == passwordhash && p.Email == email && p.isApproved == true).FirstOrDefault();
            Console.WriteLine("Username: {0} ", password.FirstName);

            Profile pro = new Profile(passwordhash);
            Console.Write("enter new password: ");
            passwordhash = Console.ReadLine();
            password.PasswordHash = passwordhash;

            context.SaveChanges();
            Console.WriteLine("You successfully changed your password ");

            var UserDetails = (from pr in context.Profiles
                                     join utype in context.userTypes on pr.UserTypeID equals utype.UserTypeID
                                     join dep in context.Departments on pr.DepartmentID equals dep.DepartmentID
                                     join gen in context.Gender on pr.GenderID equals gen.GenderID
                               from ad in context.Addresses
                                     join adtype in context.AddressTypes on ad.AddressTypeID equals adtype.AddressTypeID
                                     join sub in context.suburbs on ad.SuburbID equals sub.SuburbID
                                     join pos in context.PostalCodes on sub.PostalCodeID equals pos.PostalCodeID
                                     join c in context.Cities on sub.CityID equals c.CityID
                                     join prov in context.provinces on c.ProvinceID equals prov.ProvinceID
where pr.Email == email 
                               select new
                               {
                                   pr.FirstName,
                                   pr.Email,
                                   pr.isApproved,
                                   utype.UserTypeName,
                                   dep.DepartmentName,
                                   gen.GenderName,
                                   adtype.AddressTypeName,
                                   ad.Unitno,
                                   ad.Streetno,
                                   ad.Streetname,
                                   ad.ComplexName,
                                   sub.SuburbName,
                                   pos.PostalCodeNumber,
                                   c.CityName,
                                   prov.ProvinceName
                               }).Distinct();
            foreach (var prof in UserDetails)
            {
                Console.WriteLine("FirstName: {0}, Email: {1}, isApproved: {2}, Usertype name: {3}, Department name: {4}, Gender type; {5} , AddressTypeName: {6}, Unitno: {7}, Streetno: {8}, Streetname: {9}, ComplexName: {10},SuburbName; {11}, PostalCodeNumber: {12}, CityName: {13},   ProvinceName: {14}\n", prof.FirstName, prof.Email, prof.isApproved, prof.UserTypeName, prof.DepartmentName, prof.GenderName, prof.AddressTypeName, prof.Unitno, prof.Streetno, prof.Streetname, prof.ComplexName, prof.SuburbName, prof.PostalCodeNumber, prof.CityName, prof.ProvinceName);
                //     Console.WriteLine("Username: {0}, oldpassword: {1} ", password.FirstName, password.PasswordHash);

            }




        }

    }
}




    

