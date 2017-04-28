using System;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;

namespace OrangeBricks.Library.Models.Offers
{
	[Serializable]
	public class MakeOfferCommand : CommandBase<MakeOfferCommand>
	{
		#region Properties

		public int PropertyId
		{
			get { return ReadProperty(PropertyIdProperty); }
			private set { LoadProperty(PropertyIdProperty, value); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		public int Offer
		{
			get { return ReadProperty(OfferProperty); }
			private set { LoadProperty(OfferProperty, value); }
		}
		public static readonly PropertyInfo<int> OfferProperty = RegisterProperty<int>(c => c.Offer);

		#endregion

		#region Execution

		public static async Task<MakeOfferCommand> ExecuteAsync(int propertyId, int offer)
		{
			var cmd =
				new MakeOfferCommand
				{
					PropertyId = propertyId,
					Offer = offer,
				};

			return await DataPortal.ExecuteAsync(cmd);
		}

		#endregion

		#region Data Access

		protected new async Task DataPortal_Execute()
		{
			var dal = ServiceFactory.Instance.GetService<IOfferDAL>();
			await dal.MakeOfferAsync(this.PropertyId, this.Offer);
		}

		#endregion
	}
}