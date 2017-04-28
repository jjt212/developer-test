using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.DataAccess;
using OrangeBricks.Library.Models.Offers;
using OrangeBricks.Library.Models.Properties;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.DTOs;

namespace OrangeBricks.Web.Controllers.Offers
{
	public class OffersController : Controller
	{
		private readonly IOrangeBricksContext _context;

		public OffersController(IOrangeBricksContext context)
		{
			_context = context;
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		public async Task<ActionResult> OnProperty(int id)
		{
			var property = await PropertyReadOnly.GetByIdAsync(id);
			var offers = await SellerOfferReadOnlyList.GetAllByPropertyIdAsync(id);

			var model =
				new OffersOnPropertyViewModel
				{
					Property = property,
					Offers = offers,
				};

			return View(model);
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		[HttpPost]
		public async Task<ActionResult> Accept(AcceptOfferDTO dto)
		{
			var acceptOfferCmd = await AcceptOfferCommand.ExecuteAsync(dto.PropertyId, dto.OfferId);

			return RedirectToAction(nameof(OffersController.OnProperty), new { id = dto.PropertyId });
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		[HttpPost]
		public async Task<ActionResult> Reject(RejectOfferDTO dto)
		{
			var rejectOfferCmd = await RejectOfferCommand.ExecuteAsync(dto.PropertyId, dto.OfferId);

			return RedirectToAction(nameof(OffersController.OnProperty), new { id = dto.PropertyId });
		}

		[OrangeBricksAuthorize(Roles = "Buyer")]
		public async Task<ActionResult> MyOffers()
		{
			var offers = await BuyerOfferReadOnlyList.GetAllByUserIdAsync(User.Identity.GetUserId());

			var viewModel =
				new MyOffersViewModel
				{
					HasOffers = offers.Count > 0,
					Offers = offers,
				};

			return View(viewModel);
		}
	}
}