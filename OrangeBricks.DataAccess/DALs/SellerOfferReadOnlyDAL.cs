using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrangeBricks.Framework.Enumerations;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.DataAccess.DALs
{
	public class SellerOfferReadOnlyDAL : EntityFrameworkDALBase, ISellerOfferReadOnlyDAL
	{
		public SellerOfferReadOnlyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region ISellerOfferReadOnlyDAL Implementation

		public async Task<IEnumerable<SellerOfferReadOnlyDTO>> GetAllByPropertyIdAsync(int propertyId)
		{
			var prop = await _context.Properties
				.Where(p => p.Id == propertyId)
				.Include(p => p.Offers)
				.SingleOrDefaultAsync();

			return prop.Offers.Select(ToDTO);
		}

		public async Task<IEnumerable<SellerOfferReadOnlyDTO>> GetAllByUserIdAsync(string userId)
		{
			var offers = await _context.Offers
				.Where(o => o.BuyerUserId == userId)
				.ToListAsync();

			return offers.Select(ToDTO);
		}

		#endregion

		private SellerOfferReadOnlyDTO ToDTO(Models.Offer o)
		{
			return
				new SellerOfferReadOnlyDTO
				{
					Id = o.Id,
					Amount = o.Amount,
					CreatedAt = o.CreatedAt,
					IsPending = o.Status == OfferStatus.Pending,
					Status = o.Status.ToString()
				};
		}
	}
}