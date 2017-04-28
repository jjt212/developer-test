using System;
using System.Collections.Generic;
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
	public class PropertyReadOnlyList : ReadOnlyListBase<PropertyReadOnlyList, PropertyReadOnly>
	{
		#region Factory Methods

		public static async Task<PropertyReadOnlyList> GetAllBySellerIdAsync(string sellerUserId)
		{
			return await DataPortal.FetchAsync<PropertyReadOnlyList>(new GetAllBySellerIdCriteria(sellerUserId));
		}

		public static async Task<PropertyReadOnlyList> GetAllBySearchQueryAsync(string searchQuery)
		{
			return await DataPortal.FetchAsync<PropertyReadOnlyList>(new GetAllBySearchQueryCriteria(searchQuery));
		}

		#endregion

		#region Data Access

		#region Criteria

		[Serializable]
		private class GetAllBySellerIdCriteria
		{
			public string SellerUserId { get; set; }

			public GetAllBySellerIdCriteria(string sellerUserId)
			{
				this.SellerUserId = sellerUserId;
			}
		}

		[Serializable]
		private class GetAllBySearchQueryCriteria
		{
			public string SearchQuery { get; set; }

			public GetAllBySearchQueryCriteria(string searchQuery)
			{
				this.SearchQuery = searchQuery;
			}
		}
		
		#endregion

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(GetAllBySellerIdCriteria criteria)
		{
			var dal = ServiceFactory.Instance.GetService<IPropertyReadOnlyDAL>();
			var dto = await dal.GetAllBySellerUserIdAsync(criteria.SellerUserId);

			FetchData(dto);
		}

		[RunLocal]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
			Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
		private async Task DataPortal_Fetch(GetAllBySearchQueryCriteria criteria)
		{
			var dal = ServiceFactory.Instance.GetService<IPropertyReadOnlyDAL>();
			var dto = await dal.GetAllBySearchQueryAsync(criteria.SearchQuery);

			FetchData(dto);
		}

		#endregion

		#region Methods

		private void FetchData(IEnumerable<PropertyReadOnlyDTO> dtos)
		{
			this.IsReadOnly = false;

			foreach (var dto in dtos)
			{
				Add(DataPortal.FetchChild<PropertyReadOnly>(dto));
			}

			this.IsReadOnly = true;
		}

		#endregion
	}
}