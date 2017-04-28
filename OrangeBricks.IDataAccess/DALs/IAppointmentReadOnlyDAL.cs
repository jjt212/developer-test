using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Appointments;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IAppointmentReadOnlyDAL
	{
		Task<IEnumerable<AppointmentReadOnlyDTO>> GetAllCreatedByUserIdAsync(string userId);
		Task<IEnumerable<AppointmentReadOnlyDTO>> GetAllCreatedForUserIdAsync(string userId);
	}
}