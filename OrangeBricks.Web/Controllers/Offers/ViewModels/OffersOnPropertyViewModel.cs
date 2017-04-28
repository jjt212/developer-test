using OrangeBricks.Library.Models.Offers;
using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
	public class OffersOnPropertyViewModel
	{
		public PropertyReadOnly Property { get; set; }
		public SellerOfferReadOnlyList Offers { get; set; }
	}
}