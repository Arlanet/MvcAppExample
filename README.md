#Introduction
MvcApp is an external dependency when installed, allows you to extend uCommerce using Mvc rather than WebForms. This can be in the form of Apps, but also things like adding tabs to existing uCommerce views. 

This example shows how that works in most cases. 

Please keep in mind our company has no access to Sitecore, so it's not tested on that platform. In theory it should however work just fine given all the dependencies below are there. Pull requests fixing this issue would be welcome!

#Usage
In order to use MvcApp, the only real required step would be registering a Mvc Route. 

You do this by extending `MvcApp.uCommerce.RegisterMvcRouteTask` like `RegisterMvcRouteTask` in this example project, and registering that to uCommerce:

    <partial-component id="Initialize">
      <parameters>
        <tasks>
          <array>
            <item insert="last">${MvcAppExample.RegisterMvcRoute}</item>
          </array>
        </tasks>
      </parameters>
    </partial-component>

    <component id="MvcAppExample.RegisterMvcRoute"
      service="UCommerce.Pipelines.IPipelineTask`1[[UCommerce.Pipelines.Initialization.InitializeArgs, UCommerce.Pipelines]], UCommerce"
      type="MvcAppExample.uCommerce.RegisterMvcRouteTask, MvcAppExample">
    </component>

From then on, you have multiple ways of utilizing Mvc in your App, please browse through the code of this project to get an idea, but it basically comes down to this:

- Mvc on a blank page
- Mvc in tabbed structure in line with uCommerce
 - Note that this is also possible on a blank page by manually calling the right Javascript methods.
- Mvc in a WebForms tab, which is required to extend existing uCommerce views.
- Using Ajax to get access to controllers.

#Notes
- Be sure to adjust the `deploypath` in the App.config before rebuilding.
- The post-build event currently only works for Umbraco. 
- The following libraries are required, we use an internal NuGet server for these. However, most can also be retrieved from an Umbraco + uCommerce installation, simply drop them in the Lib-folder and you should be ready to go:
 - ClientDependency.Core.dll
 - ClientDependency.Core.Mvc.dll
 - MvcApp.dll (Install MvcApp from the uCommerce App Store for this one)
 - System.Web.Mvc.dll
 - System.Web.WebPages.dll
 - UCommerce.dll
 - UCommerce.Infrastructure.dll
 - UCommerce.Pipelines.dll
 - UCommerce.Presentation.dll

#Recommendations
Even though we provide quite a few ways to build apps and extensions with MvcApp, we recommend to do as much as possible client-side (using something like Angular.js). This prevents unnecessary page refreshes giving a smooth experience to the user, while still leveraging the power of Controllers through Ajax calls. A great starting point for this is the `ExampleController`-method, which is a blank page which has all uCommerce dependencies injected (including Angular.js).

If you want to extend existing views of uCommerce with an extra tab, you will have to use the WebForms wrapper provided by MvcApp. Also in this case, try choosing client-side over server-side by using Ajax calls (also see `WebFormsHtmlTab`)

#TODO
A few things in MvcApp are probably over-engineered, we'll re-evaluate our methods as time passes. There is really only one TODO to our knowledge, and that's allowing Apps based on MvcApp to be extended like you can with uCommerce views by means of the PageBuilder.

#License
MvcApp itself is closed-source for the time being, but can be freely used in any type of app (both free and commercial). This example project is released under MIT, do as you please.