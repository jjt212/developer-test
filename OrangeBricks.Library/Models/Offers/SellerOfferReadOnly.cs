using System;
using System.Runtime.Serialization;
using Csla;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.Library.Models.Offers
{
	[Serializable]
	[DataContract]
	public class SellerOfferReadOnly : ReadOnlyBase<SellerOfferReadOnly>
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
		public bool IsPending
		{
			get { return ReadProperty(IsPendingProperty); }
		}
		public static readonly PropertyInfo<bool> IsPendingProperty = RegisterProperty<bool>(c => c.IsPending);

		[DataMember]
		public string Status
		{
			get { return ReadProperty(StatusProperty); }
		}
		public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);

		#endregion

		#region Child Data Access

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private void Child_Fetch(SellerOfferReadOnlyDTO dto)
		{
			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(SellerOfferReadOnlyDTO dto)
		{
			LoadProperty(IdProperty, dto.Id);
			LoadProperty(AmountProperty, dto.Amount);
			LoadProperty(CreatedAtProperty, dto.CreatedAt);
			LoadProperty(IsPendingProperty, dto.IsPending);
			LoadProperty(StatusProperty, dto.Status);
		}

		#endregion
	}
}