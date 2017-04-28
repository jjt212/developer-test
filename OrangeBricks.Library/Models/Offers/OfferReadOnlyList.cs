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
	public class OfferReadOnlyList : ReadOnlyListBase<OfferReadOnlyList, OfferReadOnly>
	{
		#region Factory Methods

		public static async Task<OfferReadOnlyList> GetAllByPropertyIdAsync(int propertyId)
		{
			return await DataPortal.FetchAsync<OfferReadOnlyList>(propertyId);
		}

		#endregion

		#region Data Access


		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(int propertyId)
		{
			var dal = ServiceFactory.Instance.GetService<IOfferReadOnlyDAL>();
			var dto = await dal.GetAllByPropertyIdAsync(propertyId);

			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(IEnumerable<OfferReadOnlyDTO> dtos)
		{
			if (dtos == null)
				return;

			this.IsReadOnly = false;

			foreach (var dto in dtos)
			{
				Add(DataPortal.FetchChild<OfferReadOnly>(dto));
			}

			this.IsReadOnly = true;
		}

		#endregion
	}
}