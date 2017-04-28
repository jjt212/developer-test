using System.Data.Entity;
using System.Threading.Tasks;
using OrangeBricks.DataAccess.Models;

namespace OrangeBricks.DataAccess
{
	public interface IOrangeBricksContext
	{
		IDbSet<Property> Properties { get; set; }
		IDbSet<Offer> Offers { get; set; }

		void SaveChanges();
		Task SaveChangesAsync();
	}
}