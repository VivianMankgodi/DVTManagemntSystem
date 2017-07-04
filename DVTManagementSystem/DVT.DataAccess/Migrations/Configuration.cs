namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using model;

    using System.Security.Cryptography;


    internal sealed class Configuration : DbMigrationsConfiguration<DVT.DataAccess.Context.ManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVT.DataAccess.Context.ManagementSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
       /*     context.provinces.AddOrUpdate(
               pro => pro.ProvinceID  ,
                new Province { ProvinceName = "Gauteng"},
                new Province { ProvinceName = "Limpopo"}
                );
       
           context.Cities.AddOrUpdate(
                ci => ci.CityID ,
                new City { CityName = "Johannesburg", ProvinceID = 1 },
                new City { CityName = "Tshwane", ProvinceID = 1 }
                );

            context.PostalCodes.AddOrUpdate(
                pos => pos.PostalCodeID ,
                new PostalCode {PostalCodeNumber = "2192" },
                new PostalCode { PostalCodeNumber = "2190" },
                new PostalCode { PostalCodeNumber = "2091"}
                );
              

            context.suburbs.AddOrUpdate(
                sub => sub.SuburbID ,
                new Suburb { SuburbName = "ABBOTSFORD", PostalCodeID  = 1, CityID = 1, SuburbID = 1 },
                new Suburb { SuburbName = "AEROTON", PostalCodeID = 2, CityID = 1, SuburbID = 1 },
                new Suburb { SuburbName = "ALAN MANOR", PostalCodeID = 3, CityID = 1, SuburbID = 1 }
                );



            context.Departments.AddOrUpdate(
                p => p.DepartmentID,
                new Department { DepartmentName = "GMIC", DepartmentDescription = "Gauteng Microsoft" },
                new model.Department { DepartmentName = "GMOB", DepartmentDescription = "Gauteng Mobility" },
                new model.Department { DepartmentName = "GQUA", DepartmentDescription = "Gauteng Quality Assurance" }
                );
            context.Gender.AddOrUpdate(
                p=>p.GenderID,
                new model.Gender { GenderName = "Male"},
                new model.Gender { GenderName = "Female" }
                );

            context.userTypes.AddOrUpdate(
                p=>p.UserTypeID,
                new model.UserType { UserTypeName = "Admin"},
                 new model.UserType { UserTypeName = "Employee" }
                );*/

         /*   context.AddressTypes.AddOrUpdate(

                adty => adty.AddressTypeID, 
                 new AddressType { AddressTypeName = "Physical Address" },
                 new AddressType { AddressTypeName = "Postal Address" }
            );*/
           
        }
    }
}
