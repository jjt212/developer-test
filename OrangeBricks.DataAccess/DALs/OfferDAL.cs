using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.DataAccess.Models;
using OrangeBricks.Framework.Enumerations;
using OrangeBricks.IDataAccess.DALs;

namespace OrangeBricks.DataAccess.DALs
{
	public class OfferDAL : EntityFrameworkDALBase, IOfferDAL
	{
		public OfferDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IOfferDAL Implementation

		public async Task AcceptOfferAsync(int propertyId, int offerId)
		{
			var offer = _context.Offers.Find(offerId);

			offer.UpdatedAt = DateTime.Now;
			offer.Status = OfferStatus.Accepted;

			await _context.SaveChangesAsync();
		}

		public async Task MakeOfferAsync(int propertyId, int offerAmount)
		{
			var property = _context.Properties.Find(propertyId);

			var offer = new Offer
			{
				Amount = offerAmount,
				Status = OfferStatus.Pending,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			};

			if (property.Offers == null)
			{
				property.Offers = new List<Offer>();
			}

			property.Offers.Add(offer);

			await _context.SaveChangesAsync();
		}

		public async Task RejectOfferAsync(int propertyId, int offerId)
		{
			var offer = _context.Offers.Find(offerId);

			offer.UpdatedAt = DateTime.Now;
			offer.Status = OfferStatus.Rejected;

			await _context.SaveChangesAsync();
		}

		#endregion
	}
}