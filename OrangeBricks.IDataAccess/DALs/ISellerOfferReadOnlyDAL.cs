using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface ISellerOfferReadOnlyDAL
	{
		Task<IEnumerable<SellerOfferReadOnlyDTO>> GetAllByPropertyIdAsync(int propertyId);
		Task<IEnumerable<SellerOfferReadOnlyDTO>> GetAllByUserIdAsync(string userId);
	}
}
