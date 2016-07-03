using System.Web.Mvc;

namespace WebDeveloper.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {            
            return View();
        } 
    }
}