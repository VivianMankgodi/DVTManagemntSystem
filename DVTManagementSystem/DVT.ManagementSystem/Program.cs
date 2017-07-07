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
            string ComplexName="", StreetNo="", StreetName=""; 
            DataAccess.DataAccesses.DataAccess da = new DataAccess.DataAccesses.DataAccess();
            string answer;

            Console.Write("Adding a Profile or adding Address?");
            answer = Console.ReadLine();

            if (answer == "profile")
            {
                da.insertProfile(firstName, lastName, email, passwordHash, isApproved, genderid, departmentID, userTypeID);

            }
            if (answer == "Address")
            {
                da.InsertAddresses(UnitNo, ComplexName,StreetNo,StreetName, AddressTypeId,SuburbID, profileid);
            }

            //    da.insertProfile("lee", "lee", "kfg@hgd", "hghg", true, 1,1,2);

            //    da.InsertAddresses(120, "hello", "012", "kk", 3, 1, 8);

            da.SelectingUnapprovedProfile();



            Console.ReadKey();
       }
    }
}
