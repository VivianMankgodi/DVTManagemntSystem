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
           // context.Database.Delete();
           // context.Database.CreateIfNotExists();
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
            Province p1 = new Province { ProvinceName = "Gauteng" };
            Province p2 = new Province { ProvinceName = "Limpopo" };
           context.provinces.AddOrUpdate(
               p1,p2
                );

            City c1 = new City { CityName = "Johannesburg",  province = p1 };
            City c2 = new City { CityName = "Tshwane",  province = p1 };

            context.Cities.AddOrUpdate(c1,c2);

            PostalCode pc1 = new PostalCode { PostalCodeNumber = "2192" };
            PostalCode pc2 = new PostalCode { PostalCodeNumber = "2190" };
            PostalCode pc3 = new PostalCode { PostalCodeNumber = "2091" };

            context.PostalCodes.AddOrUpdate(pc1,pc2,pc3 );

            Suburb s1 = new Suburb { SuburbName = "ABBOTSFORD",postalCode= pc1,city= c1};
            Suburb s2 = new Suburb { SuburbName = "AEROTON",postalCode=pc2, city= c1 };
            Suburb s3 = new Suburb { SuburbName = "ALAN MANOR", postalCode = pc3, city= c1};
            context.suburbs.AddOrUpdate(s1,s2,s3 );

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
                );

           context.AddressTypes.AddOrUpdate(

                adty => adty.AddressTypeID, 
                 new AddressType { AddressTypeName = "Physical Address" },
                 new AddressType { AddressTypeName = "Postal Address" }
            );
           
        }
    }
}
