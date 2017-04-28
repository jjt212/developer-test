using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Csla;
using Microsoft.Practices.ServiceLocation;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;
using OrangeBricks.Library.Models.Offers;

namespace OrangeBricks.Library.Models.Properties
{
	[Serializable]
	[DataContract]
	public class PropertyReadOnly : ReadOnlyBase<PropertyReadOnly>
	{
		#region Properties

		[DataMember]
		public int PropertyId
		{
			get { return ReadProperty(PropertyIdProperty); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		[DataMember]
		public string PropertyType
		{
			get { return ReadProperty(PropertyTypeProperty); }
		}
		public static readonly PropertyInfo<string> PropertyTypeProperty = RegisterProperty<string>(c => c.PropertyType);

		[DataMember]
		public int NumberOfBedrooms
		{
			get { return ReadProperty(NumberOfBedroomsProperty); }
		}
		public static readonly PropertyInfo<int> NumberOfBedroomsProperty = RegisterProperty<int>(c => c.NumberOfBedrooms);

		[DataMember]
		public string StreetName
		{
			get { return ReadProperty(StreetNameProperty); }
		}
		public static readonly PropertyInfo<string> StreetNameProperty = RegisterProperty<string>(c => c.StreetName);
		
		[DataMember]
		public string Description
		{
			get { return ReadProperty(DescriptionProperty); }
		}
		public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);

		[DataMember]
		public bool HasOffers
		{
			get { return ReadProperty(HasOffersProperty); }
		}
		public static readonly PropertyInfo<bool> HasOffersProperty = RegisterProperty<bool>(c => c.HasOffers);
		
		[DataMember]
		public bool IsListedForSale
		{
			get { return ReadProperty(IsListedForSaleProperty); }
		}
		public static readonly PropertyInfo<bool> IsListedForSaleProperty = RegisterProperty<bool>(c => c.IsListedForSale);

		#endregion

		#region Factory Methods

		public static async Task<PropertyReadOnly> GetByIdAsync(int propertyId)
		{
			return await DataPortal.FetchAsync<PropertyReadOnly>(propertyId);
		}

		#endregion

		#region Data Access

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(int propertyId)
		{
			var dal = ServiceLocator.Current.GetInstance<IPropertyReadOnlyDAL>();
			var dto = await dal.GetByIdAsync(propertyId);

			FetchData(dto);
		}

		#endregion

		#region Child Data Access


		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private void Child_Fetch(PropertyReadOnlyDTO dto)
		{
			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(PropertyReadOnlyDTO dto)
		{
			LoadProperty(PropertyIdProperty, dto.PropertyId);
			LoadProperty(PropertyTypeProperty, dto.PropertyType);
			LoadProperty(NumberOfBedroomsProperty, dto.NumberOfBedrooms);
			LoadProperty(StreetNameProperty, dto.StreetName);
			LoadProperty(DescriptionProperty, dto.Description);
			LoadProperty(HasOffersProperty, dto.HasOffers);
			LoadProperty(IsListedForSaleProperty, dto.IsListedForSale);
		}

		#endregion
	}
}