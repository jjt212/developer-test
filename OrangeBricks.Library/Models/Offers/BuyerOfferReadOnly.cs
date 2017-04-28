using System;
using System.Runtime.Serialization;
using Csla;
using OrangeBricks.IDataAccess.DTOs.Offers;
using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Library.Models.Offers
{
	[Serializable]
	[DataContract]
	public class BuyerOfferReadOnly : ReadOnlyBase<BuyerOfferReadOnly>
	{
		#region Properties

		[DataMember]
		public int Id
		{
			get { return ReadProperty(IdProperty); }
		}
		public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);

		[DataMember]
		public int Amount
		{
			get { return ReadProperty(AmountProperty); }
		}
		public static readonly PropertyInfo<int> AmountProperty = RegisterProperty<int>(c => c.Amount);

		[DataMember]
		public DateTime CreatedAt
		{
			get { return ReadProperty(CreatedAtProperty); }
		}
		public static readonly PropertyInfo<DateTime> CreatedAtProperty = RegisterProperty<DateTime>(c => c.CreatedAt);

		[DataMember]
		public DateTime UpdatedAt
		{
			get { return ReadProperty(UpdatedAtProperty); }
		}
		public static readonly PropertyInfo<DateTime> UpdatedAtProperty = RegisterProperty<DateTime>(c => c.UpdatedAt);

		[DataMember]
		public bool IsAccepted
		{
			get { return ReadProperty(IsAcceptedProperty); }
		}
		public static readonly PropertyInfo<bool> IsAcceptedProperty = RegisterProperty<bool>(c => c.IsAccepted);

		[DataMember]
		public bool IsPending
		{
			get { return ReadProperty(IsPendingProperty); }
		}
		public static readonly PropertyInfo<bool> IsPendingProperty = RegisterProperty<bool>(c => c.IsPending);

		[DataMember]
		public bool IsRejected
		{
			get { return ReadProperty(IsRejectedProperty); }
		}
		public static readonly PropertyInfo<bool> IsRejectedProperty = RegisterProperty<bool>(c => c.IsRejected);

		[DataMember]
		public string Status
		{
			get { return ReadProperty(StatusProperty); }
		}
		public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);

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
		private void Child_Fetch(BuyerOfferReadOnlyDTO dto)
		{
			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(BuyerOfferReadOnlyDTO dto)
		{
			LoadProperty(IdProperty, dto.Id);
			LoadProperty(AmountProperty, dto.Amount);
			LoadProperty(CreatedAtProperty, dto.CreatedAt);
			LoadProperty(UpdatedAtProperty, dto.UpdatedAt);
			LoadProperty(IsAcceptedProperty, dto.IsAccepted);
			LoadProperty(IsPendingProperty, dto.IsPending);
			LoadProperty(IsRejectedProperty, dto.IsRejected);
			LoadProperty(StatusProperty, dto.Status);

			this.Property = DataPortal.FetchChild<PropertyReadOnly>(dto.Property);
		}

		#endregion
	}
}