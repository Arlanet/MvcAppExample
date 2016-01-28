using System.Web.UI.WebControls;
using MvcApp.uCommerce;
using UCommerce.Presentation.UI;

namespace MvcAppExample.WebForms
{
    public class WebFormsHtmlTab : WebFormsMvcTabTask
    {
        public WebFormsHtmlTab()
        {
            Name = "WebForms Html Tab";
            Url = "/Apps/MvcAppExample/WebForms/WebFormsTab.html";
            EnablePostBack = false;
            BasePathVariable = "basePath";
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
