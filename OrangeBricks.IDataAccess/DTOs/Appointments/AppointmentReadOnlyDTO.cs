using System;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.IDataAccess.DTOs.Appointments
{
	public class AppointmentReadOnlyDTO
	{
		public int AppointmentId { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public string Comments { get; set; }
		public DateTime RequestedFor { get; set; }
		public DateTime CreatedAt { get; set; }

		public PropertyReadOnlyDTO Property { get; set; }
	}
}