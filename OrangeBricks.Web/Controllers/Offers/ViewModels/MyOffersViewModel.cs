using OrangeBricks.Library.Models.Offers;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
	public class MyOffersViewModel
	{
		public bool HasOffers { get; set; }
		public BuyerOfferReadOnlyList Offers { get; set; }
	}
}