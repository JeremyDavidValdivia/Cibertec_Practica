using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class EmployeeData : BaseDataAccesscs<Employees>
    {
        public Employees GetEmployeeById(int id)
        {
            using (var dbcontext = new WebContextDb())
            {
                return dbcontext.lEmployees.FirstOrDefault(c => c.EmployeeID == id);
            }
        }
    }
}
