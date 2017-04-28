using System;

namespace OrangeBricks.IDataAccess.DTOs.Appointments
{
	public class AppointmentDTO
	{
		public int AppointmentId { get; set; }

		public int PropertyId { get; set; }

		public string RequestingUserId { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string EmailAddress { get; set; }

		public string Comments { get; set; }

		public DateTime RequestedFor { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}