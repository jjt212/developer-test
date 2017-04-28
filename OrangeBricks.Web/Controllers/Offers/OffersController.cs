using System.Threading.Tasks;
using System.Web.Mvc;
using OrangeBricks.DataAccess;
using OrangeBricks.Library.Models.Offers;
using OrangeBricks.Library.Models.Properties;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.DTOs;

namespace OrangeBricks.Web.Controllers.Offers
{
	[OrangeBricksAuthorize(Roles = "Seller")]
	public class OffersController : Controller
	{
		private readonly IOrangeBricksContext _context;

		public OffersController(IOrangeBricksContext context)
		{
			_context = context;
		}

		public async Task<ActionResult> OnProperty(int id)
		{
			var property = await PropertyReadOnly.GetByIdAsync(id);
			var offers = await OfferReadOnlyList.GetAllByPropertyIdAsync(id);

			var model =
				new OffersOnPropertyViewModel
				{
					Property = property,
					Offers = offers,
				};

			return View(model);
		}

		[HttpPost]
		public async Task<ActionResult> Accept(AcceptOfferDTO dto)
		{
			var acceptOfferCmd = await AcceptOfferCommand.ExecuteAsync(dto.PropertyId, dto.OfferId);

			return RedirectToAction(nameof(OffersController.OnProperty), new { id = dto.PropertyId });
		}

		[HttpPost]
		public async Task<ActionResult> Reject(RejectOfferDTO dto)
		{
			var rejectOfferCmd = await RejectOfferCommand.ExecuteAsync(dto.PropertyId, dto.OfferId);

			return RedirectToAction(nameof(OffersController.OnProperty), new { id = dto.PropertyId });
		}
	}
}