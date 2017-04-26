using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using OrangeBricks.DataAccess;
using OrangeBricks.DataAccess.Models;
using OrangeBricks.Web.Infrastructure;

namespace OrangeBricks.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new UnityContainer();
			container.RegisterType<IOrangeBricksContext, ApplicationDbContext>();
			container.RegisterType<DbContext, ApplicationDbContext>();
			container.RegisterType<IUserStore<ApplicationUser>>();
			container.RegisterType<IAuthenticationManager>(new InjectionFactory(context => HttpContext.Current.GetOwinContext().Authentication));

			DependencyResolver.SetResolver(new UnityResolver(container));
		}
	}
}