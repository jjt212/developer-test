using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;

namespace OrangeBricks.Library.Models.Properties
{
	[Serializable]
	[DataContract]
	public class Property : BusinessBase<Property>
	{
		#region Properties

		[DataMember]
		public int PropertyId
		{
			get { return GetProperty(PropertyIdProperty); }
			private set { SetProperty(PropertyIdProperty, value); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		[DataMember]
		public string SellerUserId
		{
			get { return GetProperty(SellerUserIdProperty); }
			private set { SetProperty(SellerUserIdProperty, value); }
		}
		public static readonly PropertyInfo<string> SellerUserIdProperty = RegisterProperty<string>(c => c.SellerUserId);

		[Display(Name = "Property type")]
		[DataMember]
		public string PropertyType
		{
			get { return GetProperty(PropertyTypeProperty); }
			set { SetProperty(PropertyTypeProperty, value); }
		}
		public static readonly PropertyInfo<string> PropertyTypeProperty = RegisterProperty<string>(c => c.PropertyType);

		[Required]
		[Display(Name = "Street name")]

		[DataMember]
		public string StreetName
		{
			get { return GetProperty(StreetNameProperty); }
			set { SetProperty(StreetNameProperty, value); }
		}
		public static readonly PropertyInfo<string> StreetNameProperty = RegisterProperty<string>(c => c.StreetName);

		[Required]
		[DataMember]
		public string Description
		{
			get { return GetProperty(DescriptionProperty); }
			set { SetProperty(DescriptionProperty, value); }
		}
		public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);

		[Required]
		[Display(Name = "Number of bedrooms")]
		[DataMember]
		public int NumberOfBedrooms
		{
			get { return GetProperty(NumberOfBedroomsProperty); }
			set { SetProperty(NumberOfBedroomsProperty, value); }
		}
		public static readonly PropertyInfo<int> NumberOfBedroomsProperty = RegisterProperty<int>(c => c.NumberOfBedrooms);

		#endregion

		#region Factory Methods

		public static Property Create(string sellerUserId)
		{
			return DataPortal.Create<Property>(sellerUserId);
		}

		#endregion

		#region Data Access
		
		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		protected void DataPortal_Create(string sellerUserId)
		{
			base.DataPortal_Create();

			this.SellerUserId = sellerUserId;
		}

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		protected new async Task DataPortal_Insert()
		{
			var dal = ServiceFactory.Instance.GetService<IPropertyDAL>();
			var dto = ToDTO();

			dto = await dal.InsertAsync(dto);

			this.PropertyId = dto.PropertyId;

			MarkIdle();
		}

		#endregion

		#region Methods

		private void FetchData(PropertyDTO dto)
		{
			this.PropertyId = dto.PropertyId;
			this.SellerUserId = dto.SellerUserId;
			this.PropertyType = dto.PropertyType;
			this.StreetName = dto.StreetName;
			this.Description = dto.Description;
			this.NumberOfBedrooms = dto.NumberOfBedrooms;
		}

		private PropertyDTO ToDTO()
		{
			var dto = new PropertyDTO();
			dto.PropertyId = this.PropertyId;
			dto.SellerUserId = this.SellerUserId;
			dto.PropertyType = this.PropertyType;
			dto.StreetName = this.StreetName;
			dto.Description = this.Description;
			dto.NumberOfBedrooms = this.NumberOfBedrooms;

			return dto;
		}

		#endregion
	}
}