﻿using System;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;

namespace OrangeBricks.Library.Models.Offers
{
	[Serializable]
	public class AcceptOfferCommand : CommandBase<AcceptOfferCommand>
	{
		#region Properties

		public int PropertyId
		{
			get { return ReadProperty(PropertyIdProperty); }
			private set { LoadProperty(PropertyIdProperty, value); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		public int OfferId
		{
			get { return ReadProperty(OfferIdProperty); }
			private set { LoadProperty(OfferIdProperty, value); }
		}
		public static readonly PropertyInfo<int> OfferIdProperty = RegisterProperty<int>(c => c.OfferId);

		#endregion

		#region Execution

		public static async Task<AcceptOfferCommand> ExecuteAsync(int propertyId, int offerId)
		{
			var cmd =
				new AcceptOfferCommand
				{
					PropertyId = propertyId,
					OfferId = offerId,
				};

			return await DataPortal.ExecuteAsync(cmd);
		}

		#endregion

		#region Data Access

		protected new async Task DataPortal_Execute()
		{
			var dal = ServiceFactory.Instance.GetService<IOfferDAL>();

			await dal.AcceptOfferAsync(this.PropertyId, this.OfferId);
		}

		#endregion
	}
}