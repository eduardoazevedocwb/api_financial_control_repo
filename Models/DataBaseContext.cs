using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using api_financial_control_entitiesLibrary;

namespace api_financial_control.Models
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cost_center> Cost_Centers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Financial_structure> Financial_Structures { get; set; }
        public DbSet<Financial_structure_access> Financial_Structure_Accesses { get; set; }
        public DbSet<Financial_value> Financial_Values { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Secret_question> Secret_Questions { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<View_access> View_Accesses { get; set; }
    }
}