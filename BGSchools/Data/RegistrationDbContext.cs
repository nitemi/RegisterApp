using BGSchools.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BGSchools.Data
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext() : base("StudentReg")//connection string
        {

        }
        public DbSet<Student> Student { get; set; }

        public DbSet<Status> statuses { get; set; }

        //override pluralisation of name
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<BGSchools.Models.StudentRegistration> StudentRegistrations { get; set; }
    }
}