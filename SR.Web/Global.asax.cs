using Ninject;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel();
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(DipendensyIngections.Initialize(kernel)));
        }
    }
}