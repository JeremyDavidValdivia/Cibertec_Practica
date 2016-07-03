using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class WebDeveloperInitializer : DropCreateDatabaseAlways<WebContextDb>
    {
        protected override void Seed(WebContextDb context)
        {
            var products = new List<Products>
            {
                new Products { ProductName = "Arroz Costeño", QuantityPerUnit = "10.00", Discontinued = false },
                new Products { ProductName = "Azucar Blanca", QuantityPerUnit = "12.00", Discontinued = false  },
                new Products { ProductName = "Papa Amarilla", QuantityPerUnit = "13.00", Discontinued = false  },
                new Products { ProductName = "Azucar Rubia", QuantityPerUnit = "5.00", Discontinued = false  },
                new Products { ProductName = "Camote", QuantityPerUnit = "3.50", Discontinued = false  }
            };
            products.ForEach(c => context.lProducts.Add(c));
            context.SaveChanges();
        }
    }
}
