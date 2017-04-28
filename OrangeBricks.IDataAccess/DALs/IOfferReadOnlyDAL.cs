using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IOfferReadOnlyDAL
	{
		Task<IEnumerable<OfferReadOnlyDTO>> GetAllByPropertyIdAsync(int propertyId);
	}
}
