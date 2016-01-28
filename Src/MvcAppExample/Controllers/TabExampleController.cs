using System.Collections.Generic;
using System.Web.Mvc;
using MvcApp.Controllers;
using MvcApp.Presentation;
using MvcAppExample.Models;

namespace MvcAppExample.Controllers
{
    public class TabExampleController : ProtectedController
    {
        public ActionResult Index()
        {
            return View("Index", new MvcSectionGroup
            {
                Name = "Tab Example Page",
                ReadOnly = true,
                Sections = new List<MvcSection>
                {
                    new MvcSection
                    {
                        Id = "Tab1",
                        Name = "Tab 1",
                        Controller = "TabExample",
                        Action = "Tab1"
                    },
                    new MvcSection
                    {
                        Id = "Tab2",
                        Name = "Tab 2",
                        Controller = "TabExample",
                        Action = "Tab2"
                    }
                }
            });
        }

        public ActionResult Tab1()
        {
            return View("Tab1");
        }

        [HttpPost]
        [ActionName("Tab1")]
        public ActionResult PostTab1(TabExampleModel model)
        {
            if (!model.CheckMe)
            {
                ModelState.AddModelError("CheckMe", "You forgot to check \"Check me\"");
            }

            return View("Tab1");
        }

        public ActionResult Tab2()
        {
            return View("Tab2");
        }

        [HttpPost]
        [ActionName("Tab2")]
        public ActionResult PostTab2(TabExampleModel model)
        {
            if (!model.CheckMe)
            {
                ModelState.AddModelError("CheckMe", "You forgot to check \"Check me\"");
            }

            return View("Tab2");
        }
    }
}
