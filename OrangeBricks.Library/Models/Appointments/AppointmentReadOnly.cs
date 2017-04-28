using System;
using System.Runtime.Serialization;
using Csla;
using OrangeBricks.IDataAccess.DTOs.Appointments;
using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Library.Models.Appointments
{
	[Serializable]
	[DataContract]
	public class AppointmentReadOnly : ReadOnlyBase<AppointmentReadOnly>
	{
		#region Properties

		[DataMember]
		public int AppointmentId
		{
			get { return ReadProperty(AppointmentIdProperty); }
		}
		public static readonly PropertyInfo<int> AppointmentIdProperty = RegisterProperty<int>(c => c.AppointmentId);

		[DataMember]
		public string Name
		{
			get { return ReadProperty(NameProperty); }
		}
		public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);

		[DataMember]
		public string PhoneNumber
		{
			get { return ReadProperty(PhoneNumberProperty); }
		}
		public static readonly PropertyInfo<string> PhoneNumberProperty = RegisterProperty<string>(c => c.PhoneNumber);

		[DataMember]
		public string EmailAddress
		{
			get { return ReadProperty(EmailAddressProperty); }
		}
		public static readonly PropertyInfo<string> EmailAddressProperty = RegisterProperty<string>(c => c.EmailAddress);

		[DataMember]
		public string Comments
		{
			get { return ReadProperty(CommentsProperty); }
		}
		public static readonly PropertyInfo<string> CommentsProperty = RegisterProperty<string>(c => c.Comments);

		[DataMember]
		public DateTime RequestedFor
		{
			get { return ReadProperty(RequestedForProperty); }
		}
		public static readonly PropertyInfo<DateTime> RequestedForProperty = RegisterProperty<DateTime>(c => c.RequestedFor);

		[DataMember]
		public DateTime CreatedAt
		{
			get { return ReadProperty(CreatedAtProperty); }
		}
		public static readonly PropertyInfo<DateTime> CreatedAtProperty = RegisterProperty<DateTime>(c => c.CreatedAt);

		#endregion

		#region Child Properties

		[DataMember]
		public PropertyReadOnly Property
		{
			get { return GetProperty(PropertyProperty); }
			set { LoadProperty(PropertyProperty, value); }
		}
		public static readonly PropertyInfo<PropertyReadOnly> PropertyProperty = RegisterProperty<PropertyReadOnly>(c => c.Property);

		#endregion

		#region Child Data Access

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private void Child_Fetch(AppointmentReadOnlyDTO dto)
		{
			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(AppointmentReadOnlyDTO dto)
		{
			LoadProperty(AppointmentIdProperty, dto.AppointmentId);
			LoadProperty(NameProperty, dto.Name);
			LoadProperty(PhoneNumberProperty, dto.PhoneNumber);
			LoadProperty(EmailAddressProperty, dto.EmailAddress);
			LoadProperty(CommentsProperty, dto.Comments);
			LoadProperty(RequestedForProperty, dto.RequestedFor);
			LoadProperty(CreatedAtProperty, dto.CreatedAt);

			this.Property = DataPortal.FetchChild<PropertyReadOnly>(dto.Property);
		}

		#endregion
	}
}