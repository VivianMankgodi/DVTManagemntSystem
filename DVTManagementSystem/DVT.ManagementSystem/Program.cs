using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVT.DataAccess;
using Microsoft.Win32;
using static System.Convert;

namespace DVT.ManagementSystem
{
  internal class Program
  {
        public static void Main(string[] args)
        {
            var da = new DataAccess.DataAccesses.DataAccess(); 
             Console.Write("Are you an Administrator? y/n: ");
            var initanswer = Console.ReadLine();
           
            if (initanswer == "n")
            {
                Console.Write("Addingf a \n " + "1: Profile \n 2: Address \n 3: Updating Details? ");
                var answer = Console.ReadLine();
                string email;
                if (answer == "1")
                {
                    //  int gendertype;
                    Console.Write("Enter your Firstname: ");
                    var firstName = Console.ReadLine();

                    Console.Write("Enter your Lastname: ");
                    var lastName = Console.ReadLine();
                    if (lastName == null) throw new ArgumentNullException(nameof(lastName));

                    Console.Write("Enter your Email: ");
                    email = Console.ReadLine();

                    Console.Write("Enter a password: ");
                    var passwordHash = Console.ReadLine();
                    SHA256 hash = new SHA256Cng();
                    byte[] hashvalue = hash.ComputeHash(Encoding.UTF8.GetBytes(passwordHash));
                    passwordHash = Encoding.Default.GetString(hashvalue);
                    Console.WriteLine(passwordHash);

                    Console.WriteLine("Gender: \n 1. Male\n 2. Female");
                    Console.Write("Enter gender number: ");
                    var genderid = ToInt32(Console.ReadLine());

                    Console.WriteLine("Department:\n1.GMIC \n 2. GMOB\n 3. GQUA");
                    Console.Write("Enter department number you belong to: ");
                    var departmentID = ToInt32(Console.ReadLine());
                    Console.WriteLine("User type:\n 1. Admin\n 2. Employee");


                    da.InsertProfile(firstName, lastName, email, passwordHash, false, genderid, departmentID, 1);
                    Console.WriteLine("Profile Added");
                }
                if (answer == "2")
                {
                    Console.Write("enter a UnitNo: ");
                    var UnitNo = ToInt32(Console.ReadLine());
                    Console.Write("Enter comple name: ");
                    var ComplexName = Console.ReadLine();
                    Console.Write("Enter Street number: ");
                    var StreetNo = Console.ReadLine();
                    Console.Write("Enter StreeName: ");
                    var StreetName = Console.ReadLine();
                    Console.WriteLine("Address type:\n 1. Physicla Address\n  2. Postal Address");
                    Console.Write("Enter Address type: ");
                    var AddressTypeId = ToInt32(Console.ReadLine());
                    Console.Write("Enter Suburb: ");
                    var SuburbID = ToInt32(Console.ReadLine());
                    Console.Write("Enter Profile Name: ");
                    var profilename = (Console.ReadLine());

                    da.InsertAddresses(UnitNo, ComplexName, StreetNo, StreetName, AddressTypeId, SuburbID, profilename);
                }
                if (answer == "3")
                {
                    Console.Write("Enter your email: ");
                    email = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    var pass = Console.ReadLine();

                    da.UpdatePassword(email, pass);
                    Console.WriteLine("You successfully changed your password ");
                }
            }
            else if (initanswer == "y")
            {
                Console.WriteLine("1: View unapproved Users \n 2: Remove a Profile");

                var adminans = Console.ReadLine();
                if (adminans == "1")
                {
                    da.SelectingUnapprovedProfile();
                    Console.ReadLine();
                }
                else if (adminans == "2")
                {
                    Console.WriteLine("Enter Profile ID to delete");
                    int proID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the address ID to Delete ");
                    int addID = Convert.ToInt32(Console.ReadLine());

                    da.RemoveProfileAddress(proID,addID);
                    
                    Console.WriteLine(@"Profile Removed");
                    Console.ReadLine();
                }
            }
        }

       
    }
}
