using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IBuyerOfferReadOnlyDAL
	{
		Task<IEnumerable<BuyerOfferReadOnlyDTO>> GetAllByUserIdAsync(string userId);
	}
}