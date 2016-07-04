using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class OrderData : BaseDataAccesscs<Orders>
    {
        public Orders GetOrderById(int id)
        {
            using (var dbcontext = new WebContextDb())
            {
                return dbcontext.lOrders.FirstOrDefault(c => c.OrderID == id);
            }
        }
    }
}
