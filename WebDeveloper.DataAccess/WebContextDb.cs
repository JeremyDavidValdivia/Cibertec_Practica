using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebDeveloper.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebDeveloper.DataAccess
{
    public class WebContextDb : DbContext
    {
        public WebContextDb() : base("name=WebDeveloperConnectionString")
        {
            Database.SetInitializer(new WebDeveloperInitializer());
        }

        public DbSet<Products>  lProducts { get; set; }

        public DbSet<Customers> lCustomers { get; set; }

        public DbSet<Categories> lCategories { get; set; }

        public DbSet<Employees> lEmployees { get; set; }

        public DbSet<Orders> lOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Elimina Datos convencionales de EntityFramework */
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
