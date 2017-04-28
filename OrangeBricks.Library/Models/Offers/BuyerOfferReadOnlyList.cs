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
	public class BuyerOfferReadOnlyList : ReadOnlyListBase<BuyerOfferReadOnlyList, BuyerOfferReadOnly>
	{
		#region Factory Methods

		public static async Task<BuyerOfferReadOnlyList> GetAllByUserIdAsync(string userId)
		{
			return await DataPortal.FetchAsync<BuyerOfferReadOnlyList>(userId);
		}

		#endregion

		#region Data Access

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(string userId)
		{
			var dal = ServiceFactory.Instance.GetService<IBuyerOfferReadOnlyDAL>();
			var dto = await dal.GetAllByUserIdAsync(userId);

			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(IEnumerable<BuyerOfferReadOnlyDTO> dtos)
		{
			if (dtos == null)
				return;

			this.IsReadOnly = false;

			foreach (var dto in dtos)
			{
				Add(DataPortal.FetchChild<BuyerOfferReadOnly>(dto));
			}

			this.IsReadOnly = true;
		}

		#endregion
	}
}