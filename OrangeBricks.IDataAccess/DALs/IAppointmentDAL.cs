using System.Threading.Tasks;
using OrangeBricks.IDataAccess.DTOs.Appointments;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IAppointmentDAL
	{
		Task<AppointmentDTO> InsertAsync(AppointmentDTO dto);
	}
}