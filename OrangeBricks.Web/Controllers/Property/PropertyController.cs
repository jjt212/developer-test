using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.DataAccess;
using OrangeBricks.Library.Models.Offers;
using OrangeBricks.Library.Models.Properties;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.DTOs;

namespace OrangeBricks.Web.Controllers.Property
{
	public class PropertyController : Controller
	{
		private readonly IOrangeBricksContext _context;

		public PropertyController(IOrangeBricksContext context)
		{
			_context = context;
		}

		[Authorize]
		public async Task<ActionResult> Index(SearchPropertiesDTO dto)
		{
			var properties = await PropertyReadOnlyList.GetAllBySearchQueryAsync(dto.Search);

			var viewModel =
				new PropertiesViewModel
				{
					Properties = properties,
					Search = dto.Search,
				};

			return View(viewModel);
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		public ActionResult Create()
		{
			var model =
				new CreatePropertyViewModel
				{
					Property = Library.Models.Properties.Property.Create(User.Identity.GetUserId()),
					PossiblePropertyTypes = new SelectList(new string[] { "House", "Flat", "Bungalow" }),
				};

			return View(model);
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		[HttpPost]
		public async Task<ActionResult> Create(CreatePropertyDTO dto)
		{
			var prop = Library.Models.Properties.Property.Create(User.Identity.GetUserId());
			prop.PropertyType = dto.Property.PropertyType;
			prop.StreetName = dto.Property.StreetName;
			prop.Description = dto.Property.Description;
			prop.NumberOfBedrooms = dto.Property.NumberOfBedrooms;

			prop = await prop.SaveAsync();

			return RedirectToAction(nameof(PropertyController.MyProperties));
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		public async Task<ActionResult> MyProperties()
		{
			var properties = await PropertyReadOnlyList.GetAllBySellerIdAsync(User.Identity.GetUserId());

			var viewModel =
				new MyPropertiesViewModel
				{
					Properties = properties,
				};

			return View(viewModel);
		}

		[HttpPost]
		[OrangeBricksAuthorize(Roles = "Seller")]
		public ActionResult ListForSale(ListPropertyDTO dto)
		{
			var cmd = ListPropertyCommand.ExecuteAsync(dto.PropertyId);

			return RedirectToAction(nameof(PropertyController.MyProperties));
		}

		[OrangeBricksAuthorize(Roles = "Buyer")]
		public async Task<ActionResult> MakeOffer(int id)
		{
			var property = await PropertyReadOnly.GetByIdAsync(id);

			var viewModel =
				new MakeOfferViewModel
				{
					Property = property,
					Offer = 100000, // TODO: property.SuggestedAskingPrice
				};

			return View(viewModel);
		}

		[HttpPost]
		[OrangeBricksAuthorize(Roles = "Buyer")]
		public async Task<ActionResult> MakeOffer(MakeOfferDTO dto)
		{
			var cmd = await MakeOfferCommand.ExecuteAsync(dto.PropertyId, dto.Offer, User.Identity.GetUserId());

			return RedirectToAction(nameof(PropertyController.Index));
		}
	}
}