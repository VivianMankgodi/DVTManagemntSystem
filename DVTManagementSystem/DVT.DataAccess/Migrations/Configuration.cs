namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using model;

    using System.Security.Cryptography;
    using System.Collections.Generic;

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


            var province = new List<Province>
            {
                new Province {ProvinceName = "Gauteng"},
                new Province {ProvinceName = "Limpopo"},
                new Province {ProvinceName = "Freestate"},
                new Province {ProvinceName = "North west"},
                new Province {ProvinceName = "Cape town"}

            };
            province.ForEach(pro => context.provinces.AddOrUpdate(pr => new
            {
                pr.ProvinceName
            }, pro));

            var postalcode = new List<PostalCode>
            {
                new PostalCode {PostalCodeNumber = "2192"},
                new PostalCode {PostalCodeNumber = "2190"},
                new PostalCode {PostalCodeNumber = "2091"},
                new PostalCode {PostalCodeNumber = "0008"}
            };
            postalcode.ForEach(p => context.PostalCodes.AddOrUpdate(pc => pc.PostalCodeNumber, p));


            var city = new List<City>
            {
                new City {CityName = "Johannesburg", Province = province[1]},
                new City {CityName = "Tshwane", Province = province[1]}
            };
            city.ForEach(c => context.Cities.AddOrUpdate(ci => new {ci.CityName, ci.Province}, c));


            var suburb = new List<Suburb>
            {
                new Suburb {SuburbName = "ABBOTSFORD", PostalCode = postalcode[1], City = city[1]},
               new Suburb {SuburbName = "AEROTON", PostalCode = postalcode[2], City = city[1]},
               new Suburb {SuburbName = "ALAN-MANOR", PostalCode = postalcode[2], City = city[1]},
               new Suburb {SuburbName = "Midrand", PostalCode= postalcode[40], City= city[1] }
               
            };
            suburb.ForEach(su => context.suburbs.AddOrUpdate(s => new { s.SuburbName, s.PostalCode, s.City }, su));


            var department = new List<Department>
            {
                new Department {DepartmentName = "GMIC", DepartmentDescription = "Gauteng Microsoft"},
                new Department {DepartmentName = "GMOB", DepartmentDescription = "Gauteng Mobility"},
                new Department {DepartmentName = "GQUA", DepartmentDescription = "Gauteng Quality Assurance"}
            };
            department.ForEach(de => context.Departments.AddOrUpdate(d => new { d.DepartmentName, d.DepartmentDescription
        } ,de));
            

            var gender = new List<Gender >
            {
                new model.Gender { GenderName = "Male"},
                new model.Gender { GenderName = "Female" }
            };
            gender.ForEach(ge=> context.Gender.AddOrUpdate(g=> g.GenderName , ge ));
            context.SaveChanges();
  

        }
    }
    
}
