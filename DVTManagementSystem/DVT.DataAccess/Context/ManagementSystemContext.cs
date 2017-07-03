using DVT.DataAccess.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.Context
{
    class ManagementSystemContext: DbContext
    {
        public ManagementSystemContext() : base("DVTManagementSystem")
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserType> userTypes { get; set; }
        public DbSet<Logs> logs { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Suburb> suburbs { get; set; }
        public DbSet<City>Cities  { get; set; }
        public DbSet<Province> provinces { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }


    }
}
