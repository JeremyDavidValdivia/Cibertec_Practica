using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebDeveloper.Model;
using System.Data.Entity.Validation;

namespace WebDeveloper.DataAccess
{
    public class WebDeveloperInitializer : DropCreateDatabaseAlways<WebContextDb>
    {
        protected override void Seed(WebContextDb context)
        {
            var categories = new List<Categories>
            {
                new Categories { CategoryName = "Categoria 1", Description = "Description 1"},
                new Categories { CategoryName = "Categoria 2", Description = "Description 2"},
                new Categories { CategoryName = "Categoria 3", Description = "Description 3"},
                new Categories { CategoryName = "Categoria 4", Description = "Description 4"},
                new Categories { CategoryName = "Categoria 5", Description = "Description 5"}
            };
            categories.ForEach(c => context.lCategories.Add(c));

            var products = new List<Products>
            {
                new Products { ProductName = "Arroz Costeño", QuantityPerUnit = "10.00", Discontinued = false, CategoryID = 1 },
                new Products { ProductName = "Azucar Blanca", QuantityPerUnit = "12.00", Discontinued = false, CategoryID = 2  },
                new Products { ProductName = "Papa Amarilla", QuantityPerUnit = "13.00", Discontinued = false, CategoryID = 3  },
                new Products { ProductName = "Azucar Rubia", QuantityPerUnit = "5.00", Discontinued = false, CategoryID = 4  },
                new Products { ProductName = "Camote", QuantityPerUnit = "3.50", Discontinued = false, CategoryID = 1  }
            };
            products.ForEach(c => context.lProducts.Add(c));

            var customers = new List<Customers>
            {
                new Customers { CompanyName = "JC Servicios", ContactName = "Jorge Blanch"},
                new Customers { CompanyName = "Molitalia", ContactName = "Luis Enrique"},
                new Customers { CompanyName = "Praxair Perú", ContactName = "Alberto Cortez"},
                new Customers { CompanyName = "Cofaco", ContactName = "Alejandro Dumas"},
                new Customers { CompanyName = "Los Materiales S.A.C", ContactName = "Rafael Miroquesada"}
            };
            customers.ForEach(c => context.lCustomers.Add(c));

            var employees = new List<Employees>
            {
                new Employees { LastName = "David", FirstName = "Jeremy", Title = "Manager"},
                new Employees { LastName = "Blanch", FirstName = "Jorge", Title = "Manager"},
                new Employees { LastName = "Moran", FirstName = "Emmanuelle", Title = "Manager"},
                new Employees { LastName = "Donayre", FirstName = "Denisse", Title = "Manager"},
                new Employees { LastName = "Calderon", FirstName = "José", Title = "Manager"}
            };
            employees.ForEach(c => context.lEmployees.Add(c));

            var orders = new List<Orders>
            {
                new Orders { CustomerID = 1, EmployeeID = 1, OrderDate = DateTime.Parse("2016-07-03") },
                new Orders { CustomerID = 1, EmployeeID = 2, OrderDate = DateTime.Parse("2016-07-03") },
                new Orders { CustomerID = 1, EmployeeID = 1, OrderDate = DateTime.Parse("2016-07-03") },
                new Orders { CustomerID = 2, EmployeeID = 2, OrderDate = DateTime.Parse("2016-07-03") },
                new Orders { CustomerID = 2, EmployeeID = 1, OrderDate = DateTime.Parse("2016-07-03") }
            };
            orders.ForEach(c => context.lOrders.Add(c));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string strErr = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    strErr += "Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:" + "\r\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        strErr += "- Property: " + ve.PropertyName + ", Error: " + ve.ErrorMessage + "\r\n";
                    }
                }
                throw;
            }
        }
    }
}
