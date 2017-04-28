using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IPropertyDAL
	{
		Task<PropertyDTO> InsertAsync(PropertyDTO dto);
		Task ListPropertyAsync(int propertyId);
	}
}