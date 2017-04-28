using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Appointments;

namespace OrangeBricks.Library.Models.Appointments
{
	[Serializable]
	public class AppointmentReadOnlyList : ReadOnlyListBase<AppointmentReadOnlyList, AppointmentReadOnly>
	{
		#region Factory Methods

		public static async Task<AppointmentReadOnlyList> GetAllCreatedByUserIdAsync(string userId)
		{
			return await DataPortal.FetchAsync<AppointmentReadOnlyList>(new GetAllCreatedByUserIdCriteria(userId));
		}

		public static async Task<AppointmentReadOnlyList> GetAllCreatedForUserIdAsync(string userId)
		{
			return await DataPortal.FetchAsync<AppointmentReadOnlyList>(new GetAllCreatedForUserIdCriteria(userId));
		}

		#endregion

		#region Data Access

		#region Criteria

		[Serializable]
		private class GetAllCreatedByUserIdCriteria
		{
			public string UserId { get; set; }

			public GetAllCreatedByUserIdCriteria(string userId)
			{
				this.UserId = userId;
			}
		}

		[Serializable]
		private class GetAllCreatedForUserIdCriteria
		{
			public string UserId { get; set; }

			public GetAllCreatedForUserIdCriteria(string userId)
			{
				this.UserId = userId;
			}
		}

		#endregion

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(GetAllCreatedByUserIdCriteria criteria)
		{
			var dal = ServiceFactory.Instance.GetService<IAppointmentReadOnlyDAL>();
			var dto = await dal.GetAllCreatedByUserIdAsync(criteria.UserId);

			FetchData(dto);
		}

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(GetAllCreatedForUserIdCriteria criteria)
		{
			var dal = ServiceFactory.Instance.GetService<IAppointmentReadOnlyDAL>();
			var dto = await dal.GetAllCreatedForUserIdAsync(criteria.UserId);

			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(IEnumerable<AppointmentReadOnlyDTO> dtos)
		{
			if (dtos == null)
				return;

			this.IsReadOnly = false;

			foreach (var dto in dtos)
			{
				Add(DataPortal.FetchChild<AppointmentReadOnly>(dto));
			}

			this.IsReadOnly = true;
		}

		#endregion
	}
}