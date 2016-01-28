using System.Web.UI.WebControls;
using MvcApp.uCommerce;
using UCommerce.Presentation.UI;

namespace MvcAppExample.WebForms
{
    public class WebFormsMvcTab : WebFormsMvcTabTask
    {
        public WebFormsMvcTab()
        {
            Name = "WebForms Mvc Tab";
            Url = "/MvcApps/MvcAppExample/WebFormsExample";
        }

        protected override void SetupMenu(SectionMenu menu)
        {
            menu.AddMenuButton(new ImageButton
            {
                ImageUrl = ResolveUrl("/images/ui/save.gif"),
                CssClass = "menuButton menuButtonSave editorIcon"
            });
        }

        protected override bool Supports(string viewName)
        {
            if (viewName.Equals("webformspage_aspx"))
            {
                return true;
            }

            return false;
        }
    }
}
