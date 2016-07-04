using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class CustomerData : BaseDataAccesscs<Customers>
    {
        public Customers GetCustomerById(int id)
        {
            using (var dbcontext = new WebContextDb())
            {
                return dbcontext.lCustomers.FirstOrDefault(c => c.CustomerID == id);
            }
        }
    }
}
