using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class CategoryData : BaseDataAccesscs<Categories>
    {
        public Categories GetCategoryById(int id)
        {
            using (var dbcontext = new WebContextDb())
            {
                return dbcontext.lCategories.FirstOrDefault(c => c.CategoryID == id);
            }
        }
    }
}
