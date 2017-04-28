using System;

namespace OrangeBricks.Web.DTOs
{
	public class CreateAppointmentDTO
	{
		public class AppointmentDTO
		{
			public string Name { get; set; }
			public string PhoneNumber { get; set; }
			public string EmailAddress { get; set; }
			public string Comments { get; set; }
			public DateTime RequestedFor { get; set; }
		}

		public AppointmentDTO Appointment { get; set; }
	}
}