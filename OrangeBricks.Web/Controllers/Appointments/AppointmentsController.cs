using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Library.Models.Appointments;
using OrangeBricks.Library.Models.Properties;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using OrangeBricks.Web.Controllers.Property;
using OrangeBricks.Web.DTOs;

namespace OrangeBricks.Web.Controllers.Appointments
{
	public class AppointmentsController : Controller
	{
		[OrangeBricksAuthorize(Roles = "Buyer")]
		public async Task<ActionResult> Sent()
		{
			var appts = await AppointmentReadOnlyList.GetAllCreatedByUserIdAsync(User.Identity.GetUserId());

			var viewModel =
				new SentAppointmentsViewModel
				{
					HasSentAppointments = appts.Count > 0,
					Appointments = appts,
				};

			return View(viewModel);
		}

		[OrangeBricksAuthorize(Roles = "Seller")]
		public async Task<ActionResult> Received()
		{
			var appts = await AppointmentReadOnlyList.GetAllCreatedForUserIdAsync(User.Identity.GetUserId());

			var viewModel =
				new ReceivedAppointmentsViewModel
				{
					HasSentAppointments = appts.Count > 0,
					Appointments = appts,
				};

			return View(viewModel);
		}

		[OrangeBricksAuthorize(Roles = "Buyer")]
		public async Task<ActionResult> Create(int propertyId)
		{
			var appt = Appointment.Create();
			appt.EmailAddress = User.Identity.GetUserName();
			var property = await PropertyReadOnly.GetByIdAsync(propertyId);

			var viewModel =
				new CreateAppointmentViewModel
				{
					Appointment = appt,
					Property = property,
				};

			return View(viewModel);
		}

		[OrangeBricksAuthorize(Roles = "Buyer")]
		[HttpPost]
		public async Task<ActionResult> Create(int propertyId, CreateAppointmentDTO model)
		{
			var dto = model.Appointment;
			var appt = Appointment.Create();
			appt.PropertyId = propertyId;
			appt.Name = dto.Name;
			appt.PhoneNumber = dto.PhoneNumber;
			appt.EmailAddress = dto.EmailAddress;
			appt.Comments = dto.Comments;
			appt.RequestedFor = dto.RequestedFor;
			appt.RequestingUserId = User.Identity.GetUserId();

			appt = await appt.SaveAsync();
			
			return RedirectToAction(nameof(PropertyController.Index), "Property");
		}
	}
}