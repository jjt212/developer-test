﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.DataAccess.DALs
{
	public class PropertyReadOnlyDAL : EntityFrameworkDALBase, IPropertyReadOnlyDAL
	{
		public PropertyReadOnlyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		public async Task<IEnumerable<PropertyReadOnlyDTO>> GetAllBySearchQueryAsync(string searchQuery)
		{
			var properties = _context.Properties
				.Where(p => p.IsListedForSale);

			if (!string.IsNullOrWhiteSpace(searchQuery))
			{
				properties = properties.Where(x => x.StreetName.Contains(searchQuery)
					|| x.Description.Contains(searchQuery));
			}

			return (await properties.ToListAsync())
				.Select(ToDTO)
				.ToList();
		}

		#region IPropertyDAL Implementation

		public async Task<IEnumerable<PropertyReadOnlyDTO>> GetAllBySellerUserIdAsync(string sellerUserId)
		{
			var properties = await _context.Properties
				.Where(p => p.SellerUserId == sellerUserId)
				.ToListAsync();

			return properties.Select(p => ToDTO(p));
		}

		public async Task<PropertyReadOnlyDTO> GetByIdAsync(int propertyId)
		{
			var property = await _context.Properties
				.Where(p => p.Id == propertyId)
				.Include(p => p.Offers)
				.SingleOrDefaultAsync();

			return ToDTO(property);
		}

		#endregion

		private PropertyReadOnlyDTO ToDTO(Models.Property p)
		{
			return new PropertyReadOnlyDTO
			{
				PropertyId = p.Id,
				StreetName = p.StreetName,
				Description = p.Description,
				NumberOfBedrooms = p.NumberOfBedrooms,
				PropertyType = p.PropertyType,
				IsListedForSale = p.IsListedForSale,
			};
		}
	}
}