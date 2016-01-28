namespace MvcAppExample.uCommerce
{
    public class RegisterMvcRouteTask : MvcApp.uCommerce.RegisterMvcRouteTask
    {
        public RegisterMvcRouteTask() 
            : base("MvcAppExample", new []{ "MvcAppExample.Controllers" })
        {
            //Do nothing
        }
    }
}
