using System;

namespace OrangeBricks.IDataAccess.DTOs.Offers
{
	public class SellerOfferReadOnlyDTO
	{
		public int Id;
		public int Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsPending { get; set; }
		public string Status { get; set; }
	}
}