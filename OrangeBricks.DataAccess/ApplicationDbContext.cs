using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrangeBricks.DataAccess.Models;

namespace OrangeBricks.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOrangeBricksContext
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public IDbSet<Property> Properties { get; set; }
		public IDbSet<Offer> Offers { get; set; }

		public new void SaveChanges()
		{
			base.SaveChanges();
		}
	}
}