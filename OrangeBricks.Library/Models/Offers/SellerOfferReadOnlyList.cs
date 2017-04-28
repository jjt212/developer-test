using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Offers;

namespace OrangeBricks.Library.Models.Offers
{
	[Serializable]
	[DataContract]
	public class SellerOfferReadOnlyList : ReadOnlyListBase<SellerOfferReadOnlyList, SellerOfferReadOnly>
	{
		#region Factory Methods

		public static async Task<SellerOfferReadOnlyList> GetAllByPropertyIdAsync(int propertyId)
		{
			return await DataPortal.FetchAsync<SellerOfferReadOnlyList>(propertyId);
		}

		public static async Task<SellerOfferReadOnlyList> GetAllByUserId(string userId)
		{
			return await DataPortal.FetchAsync<SellerOfferReadOnlyList>(userId);
		}

		#endregion

		#region Data Access
		
		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(int propertyId)
		{
			var dal = ServiceFactory.Instance.GetService<ISellerOfferReadOnlyDAL>();
			var dto = await dal.GetAllByPropertyIdAsync(propertyId);

			FetchData(dto);
		}
		
		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(string userId)
		{
			var dal = ServiceFactory.Instance.GetService<ISellerOfferReadOnlyDAL>();
			var dto = await dal.GetAllByUserIdAsync(userId);

			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(IEnumerable<SellerOfferReadOnlyDTO> dtos)
		{
			if (dtos == null)
				return;

			this.IsReadOnly = false;

			foreach (var dto in dtos)
			{
				Add(DataPortal.FetchChild<SellerOfferReadOnly>(dto));
			}

			this.IsReadOnly = true;
		}

		#endregion
	}
}