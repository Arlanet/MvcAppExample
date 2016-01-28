using System.Web.Mvc;
using MvcApp.Controllers;

namespace MvcAppExample.Controllers
{
    public class ExampleController : ProtectedController
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
