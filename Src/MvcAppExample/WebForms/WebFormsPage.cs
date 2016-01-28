using System.Web.UI;
using UCommerce.EntitiesV2;
using UCommerce.Infrastructure;
using UCommerce.Presentation.Web.Pages;

namespace MvcAppExample.WebForms
{
    public class WebFormsPage : ProtectedPage, ITabView, INamedReadOnly
    {
        public string Name
        {
            get { return "WebForms Page"; }
        }

        public Control InitializeTabView()
        {
            return ObjectFactory.Instance.Resolve<ITabViewBuilder>().BuildTabView(this);
        }
    }
}
