using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Appointments;

namespace OrangeBricks.DataAccess.DALs
{
	public class AppointmentDAL : EntityFrameworkDALBase, IAppointmentDAL
	{
		public AppointmentDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IAppointmentDAL Implementation

		public async Task<AppointmentDTO> InsertAsync(AppointmentDTO dto)
		{
			var property = _context.Properties.Find(dto.PropertyId);

			var appointment = new Models.Appointment
			{
				PropertyId = dto.PropertyId,
				RequestingUserId = dto.RequestingUserId,
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				EmailAddress = dto.EmailAddress,
				Comments = dto.Comments,
				RequestedFor = dto.RequestedFor,
				CreatedAt = dto.CreatedAt,
			};

			if (property.Appointments == null)
			{
				property.Appointments = new List<Models.Appointment>();
			}

			property.Appointments.Add(appointment);
			await _context.SaveChangesAsync();

			dto.AppointmentId = appointment.Id;
			return dto;
		}

		#endregion
	}
}