using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Appointments;

namespace OrangeBricks.Library.Models.Appointments
{
	[Serializable]
	[DataContract]
	public class Appointment : BusinessBase<Appointment>
	{
		#region Properties

		[DataMember]
		public int AppointmentId
		{
			get { return GetProperty(AppointmentIdProperty); }
			set { SetProperty(AppointmentIdProperty, value); }
		}
		public static readonly PropertyInfo<int> AppointmentIdProperty = RegisterProperty<int>(c => c.AppointmentId);

		[DataMember]
		public int PropertyId
		{
			get { return GetProperty(PropertyIdProperty); }
			set { SetProperty(PropertyIdProperty, value); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		[DataMember]
		public string Name
		{
			get { return GetProperty(NameProperty); }
			set { SetProperty(NameProperty, value); }
		}
		public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);

		[DataMember]
		public string PhoneNumber
		{
			get { return GetProperty(PhoneNumberProperty); }
			set { SetProperty(PhoneNumberProperty, value); }
		}
		public static readonly PropertyInfo<string> PhoneNumberProperty = RegisterProperty<string>(c => c.PhoneNumber);

		[DataMember]
		public string EmailAddress
		{
			get { return GetProperty(EmailAddressProperty); }
			set { SetProperty(EmailAddressProperty, value); }
		}
		public static readonly PropertyInfo<string> EmailAddressProperty = RegisterProperty<string>(c => c.EmailAddress);

		[DataMember]
		public string Comments
		{
			get { return GetProperty(CommentsProperty); }
			set { SetProperty(CommentsProperty, value); }
		}
		public static readonly PropertyInfo<string> CommentsProperty = RegisterProperty<string>(c => c.Comments);

		[DataMember]
		public string RequestingUserId
		{
			get { return GetProperty(RequestingUserIdProperty); }
			set { SetProperty(RequestingUserIdProperty, value); }
		}
		public static readonly PropertyInfo<string> RequestingUserIdProperty = RegisterProperty<string>(c => c.RequestingUserId);

		[DataMember]
		public DateTime RequestedFor
		{
			get { return GetProperty(RequestedForProperty); }
			set { SetProperty(RequestedForProperty, value); }
		}
		public static readonly PropertyInfo<DateTime> RequestedForProperty = RegisterProperty<DateTime>(c => c.RequestedFor);

		[DataMember]
		public DateTime CreatedAt
		{
			get { return ReadProperty(CreatedAtProperty); }
		}
		public static readonly PropertyInfo<DateTime> CreatedAtProperty = RegisterProperty<DateTime>(c => c.CreatedAt);

		#endregion

		#region Factory Methods

		public static Appointment Create()
		{
			return DataPortal.Create<Appointment>();
		}

		#endregion

		#region Data Access

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
		Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		protected override void DataPortal_Create()
		{
			base.DataPortal_Create();

			LoadProperty(CreatedAtProperty, DateTime.Now);
			LoadProperty(RequestedForProperty, DateTime.Now.AddDays(1).Date.AddHours(12)); // Default to tomorrow at noon
		}

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		protected new async Task DataPortal_Insert()
		{
			var dal = ServiceFactory.Instance.GetService<IAppointmentDAL>();
			var dto = ToDTO();

			dto = await dal.InsertAsync(dto);

			this.AppointmentId = dto.AppointmentId;

			MarkIdle();
		}

		#endregion

		#region Methods

		private AppointmentDTO ToDTO()
		{
			var dto = new AppointmentDTO();
			dto.AppointmentId = this.AppointmentId;
			dto.PropertyId = this.PropertyId;
			dto.RequestingUserId = this.RequestingUserId;
			dto.Name = this.Name;
			dto.PhoneNumber = this.PhoneNumber;
			dto.EmailAddress = this.EmailAddress;
			dto.Comments = this.Comments;
			dto.RequestedFor = this.RequestedFor;
			dto.CreatedAt = this.CreatedAt;

			return dto;
		}

		#endregion
	}
}