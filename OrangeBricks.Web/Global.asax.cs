using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using OrangeBricks.DataAccess;
using OrangeBricks.DataAccess.DALs;
using OrangeBricks.DataAccess.Models;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
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
			container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
			container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IUserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IAuthenticationManager>(new InjectionFactory(context => HttpContext.Current.GetOwinContext().Authentication));
			container.RegisterType<ApplicationSignInManager>(new InjectionFactory(context => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()));
			container.RegisterType<ApplicationUserManager>(new InjectionFactory(context => HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>()));

			container.RegisterType<IOfferDAL, OfferDAL>(new HierarchicalLifetimeManager());
			container.RegisterType<ISellerOfferReadOnlyDAL, SellerOfferReadOnlyDAL>(new HierarchicalLifetimeManager());
			container.RegisterType<IBuyerOfferReadOnlyDAL, BuyerOfferReadOnlyDAL>(new HierarchicalLifetimeManager());
			container.RegisterType<IPropertyDAL, PropertyDAL>(new HierarchicalLifetimeManager());
			container.RegisterType<IPropertyReadOnlyDAL, PropertyReadOnlyDAL>(new HierarchicalLifetimeManager());

			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
			ServiceFactory.SetDefault(new ServiceFactory(container));

			DependencyResolver.SetResolver(new UnityResolver(container));
		}
	}
}