using System;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.IDataAccess.DTOs.Offers
{
	public class BuyerOfferReadOnlyDTO
	{
		public int Id { get; set; }
		public int Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool IsPending { get; set; }
		public bool IsAccepted { get; set; }
		public bool IsRejected { get; set; }
		public string Status { get; set; }

		public PropertyReadOnlyDTO Property { get; set; }
	}
}