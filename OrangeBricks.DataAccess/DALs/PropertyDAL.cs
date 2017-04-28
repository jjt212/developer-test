using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.DataAccess.DALs
{
	public class PropertyDAL : EntityFrameworkDALBase, IPropertyDAL
	{
		public PropertyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IPropertyDAL Implementation

		public async Task<PropertyDTO> InsertAsync(PropertyDTO dto)
		{
			var property = new Models.Property
			{
				PropertyType = dto.PropertyType,
				StreetName = dto.StreetName,
				Description = dto.Description,
				NumberOfBedrooms = dto.NumberOfBedrooms,
				SellerUserId = dto.SellerUserId,
			};

			_context.Properties.Add(property);
			await _context.SaveChangesAsync();

			dto.PropertyId = property.Id;
			return dto;
		}

		public async Task ListPropertyAsync(int propertyId)
		{
			var property = _context.Properties.Find(propertyId);
			property.IsListedForSale = true;
			await _context.SaveChangesAsync();
		}

		#endregion
	}
}