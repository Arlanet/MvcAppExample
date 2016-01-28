using MvcApp.Controllers;

namespace MvcAppExample.Controllers
{
    public class ExampleApiController : ProtectedApiController
    {
        public object HelloMvc(string input)
        {
            return string.Format("Hello {0}!", input);
        }
    }
}
