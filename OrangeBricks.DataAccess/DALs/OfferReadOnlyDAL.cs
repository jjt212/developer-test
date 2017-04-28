using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrangeBricks.Framework.Enumerations;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.DataAccess.DALs
{
	public class OfferReadOnlyDAL : EntityFrameworkDALBase, IOfferReadOnlyDAL
	{
		public OfferReadOnlyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IOfferReadOnlyDAL Implementation

		public async Task<IEnumerable<OfferReadOnlyDTO>> GetAllByPropertyIdAsync(int propertyId)
		{
			var prop = await _context.Properties
				.Where(p => p.Id == propertyId)
				.Include(p => p.Offers)
				.SingleOrDefaultAsync();

			return prop.Offers.Select(x =>
				new OfferReadOnlyDTO
				{
					Id = x.Id,
					Amount = x.Amount,
					CreatedAt = x.CreatedAt,
					IsPending = x.Status == OfferStatus.Pending,
					Status = x.Status.ToString()
				});
		}

		#endregion
	}
}