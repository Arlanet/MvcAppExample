using System.Web.Mvc;
using MvcApp.Controllers;
using MvcAppExample.Models;

namespace MvcAppExample.Controllers
{
    public class WebFormsExampleController : ProtectedController
    {
        public ActionResult Index()
        {
            return View("Index", new TabExampleModel
            {
                CheckMe = false
            });
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult PostIndex(TabExampleModel model)
        {
            if (!model.CheckMe)
            {
                ModelState.AddModelError("CheckMe", "You forgot to check \"Check me\"");
            }

            return View("Index", model);
        }
    }
}
