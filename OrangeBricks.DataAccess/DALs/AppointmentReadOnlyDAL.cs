using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Appointments;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.DataAccess.DALs
{
	public class AppointmentReadOnlyDAL : EntityFrameworkDALBase, IAppointmentReadOnlyDAL
	{
		public AppointmentReadOnlyDAL(IOrangeBricksContext context)
			: base(context)
		{
		}

		#region IAppointmentReadOnlyDAL Implementation

		public async Task<IEnumerable<AppointmentReadOnlyDTO>> GetAllCreatedByUserIdAsync(string userId)
		{
			var properties = await _context.Properties
				.Include(p => p.Appointments)
				.Where(p => p.Appointments.Any(a => a.RequestingUserId == userId))
				.ToListAsync();

			var appointments = new List<AppointmentReadOnlyDTO>();
			foreach (var property in properties)
			{
				foreach (var appointment in property.Appointments.Where(a => a.RequestingUserId == userId))
				{
					appointments.Add(ToDTO(appointment, property));

				}
			}

			return appointments;
		}

		public async Task<IEnumerable<AppointmentReadOnlyDTO>> GetAllCreatedForUserIdAsync(string userId)
		{
			var properties = await _context.Properties
				.Include(p => p.Appointments)
				.Where(p => p.SellerUserId == userId)
				.Where(p => p.Appointments.Count > 0)
				.ToListAsync();

			var appointments = new List<AppointmentReadOnlyDTO>();
			foreach (var property in properties)
			{
				foreach (var appointment in property.Appointments)
				{
					appointments.Add(ToDTO(appointment, property));
				}
			}

			return appointments;
		}

		#endregion

		private AppointmentReadOnlyDTO ToDTO(Models.Appointment appointment, Models.Property property)
		{
			return
				new AppointmentReadOnlyDTO
				{
					AppointmentId = appointment.Id,
					Name = appointment.Name,
					PhoneNumber = appointment.PhoneNumber,
					EmailAddress = appointment.EmailAddress,
					Comments = appointment.Comments,
					RequestedFor = appointment.RequestedFor,
					CreatedAt = appointment.CreatedAt,
					Property =
						new PropertyReadOnlyDTO
						{
							PropertyId = property.Id,
							PropertyType = property.PropertyType,
							StreetName = property.StreetName,
							Description = property.Description,
							HasOffers = true,
							IsListedForSale = property.IsListedForSale,
							NumberOfBedrooms = property.NumberOfBedrooms,
						},
				};
		}
	}
}