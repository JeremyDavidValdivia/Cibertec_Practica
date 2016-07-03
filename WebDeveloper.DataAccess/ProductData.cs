using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class ProductData : BaseDataAccesscs<Products>
    {
        public Products GetProductById(int id)
        {
            using (var dbcontext = new WebContextDb())
            {
                return dbcontext.lProducts.FirstOrDefault(c => c.ProductID == id);
            }
        }
    }
}
