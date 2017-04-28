using OrangeBricks.Library.Models.Appointments;
using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
	public class CreateAppointmentViewModel
	{
		public PropertyReadOnly Property { get; set; }
		public Appointment Appointment { get; set; }
	}
}