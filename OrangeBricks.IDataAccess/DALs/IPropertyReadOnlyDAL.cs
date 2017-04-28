using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IPropertyReadOnlyDAL
	{
		Task<IEnumerable<PropertyReadOnlyDTO>> GetAllBySellerUserIdAsync(string sellerUserId);
		Task<IEnumerable<PropertyReadOnlyDTO>> GetAllBySearchQueryAsync(string searchQuery);
		Task<PropertyReadOnlyDTO> GetByIdAsync(int propertyId);
	}
}