using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrangeBricks.Framework.Enumerations;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Offers;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.DataAccess.DALs
{
	public class BuyerOfferReadOnlyDAL : EntityFrameworkDALBase, IBuyerOfferReadOnlyDAL
	{
		public BuyerOfferReadOnlyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IBuyerOfferReadOnlyDAL Implementation

		public async Task<IEnumerable<BuyerOfferReadOnlyDTO>> GetAllByUserIdAsync(string userId)
		{
			var properties = await _context.Properties
				.Include(p => p.Offers)
				.Where(p => p.Offers.Any(o => o.BuyerUserId == userId))
				.ToListAsync();

			var offers = new List<BuyerOfferReadOnlyDTO>();
			foreach (var property in properties)
			{
				foreach (var offer in property.Offers.Where(o => o.BuyerUserId == userId))
				{
					offers.Add(
						new BuyerOfferReadOnlyDTO
						{
							Id = offer.Id,
							Amount = offer.Amount,
							Status = offer.Status.ToString(),
							IsAccepted = offer.Status == OfferStatus.Accepted,
							IsPending = offer.Status == OfferStatus.Pending,
							IsRejected = offer.Status == OfferStatus.Rejected,
							CreatedAt = offer.CreatedAt,
							UpdatedAt = offer.UpdatedAt,
							Property =
								new PropertyReadOnlyDTO
								{
									PropertyId = property.Id,
									PropertyType = property.PropertyType,
									StreetName = property.StreetName,
									Description = property.Description,
									HasOffers = true,
									IsListedForSale = property.IsListedForSale,
									NumberOfBedrooms = property.NumberOfBedrooms,
								},
						});
				}
			}

			return offers;
		}

		#endregion
	}
}