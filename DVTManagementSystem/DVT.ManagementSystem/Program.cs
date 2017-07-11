using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVT.DataAccess;
namespace DVT.ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string firstName = "", lastName ="", email ="", passwordHash ="";
            bool isApproved = false;
            int genderid = 0, departmentID = 0, userTypeID = 0;
            int UnitNo =0, AddressTypeId =0,  SuburbID =0,  profileid =0;
            string ComplexName="", StreetNo="", StreetName="", pass=""; 
            DataAccess.DataAccesses.DataAccess da = new DataAccess.DataAccesses.DataAccess();
            string answer;
            char LAnswer;
            Console.Write("Are you Administrator? y/n: ");
            LAnswer =Convert.ToChar(Console.ReadLine());


            da.insertProfile(firstName, lastName, email, passwordHash, isApproved, genderid, departmentID, userTypeID);
               if (LAnswer == 'n')
                {
                    Console.Write("Adding a Profile or adding Address or Login? ");
                    answer = Console.ReadLine();
                    if (answer == "profile")
                    {
                        da.insertProfile(firstName, lastName, email, passwordHash, isApproved, genderid, departmentID, userTypeID);

                    }
                    if (answer == "Address")
                    {
                        da.InsertAddresses(UnitNo, ComplexName, StreetNo, StreetName, AddressTypeId, SuburbID, profileid);
                    }
                    if (answer == "login")
                    {

                        da.UpdatePassword(email, pass);
                    }
                }
                else
                {
                    da.SelectingUnapprovedProfile();
                }

 



            Console.ReadKey();
       }
    }
}
