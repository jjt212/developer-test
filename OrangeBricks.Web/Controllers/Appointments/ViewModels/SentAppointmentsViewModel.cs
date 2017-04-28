using OrangeBricks.Library.Models.Appointments;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
	public class SentAppointmentsViewModel
	{
		public bool HasSentAppointments { get; set; }
		public AppointmentReadOnlyList Appointments { get; set; }
	}
}