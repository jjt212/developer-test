using System;
using System.Threading.Tasks;
using Csla;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;

namespace OrangeBricks.Library.Models.Properties
{
	[Serializable]
	public class ListPropertyCommand : CommandBase<ListPropertyCommand>
	{
		#region Properties

		public int PropertyId
		{
			get { return ReadProperty(PropertyIdProperty); }
			private set { LoadProperty(PropertyIdProperty, value); }
		}
		public static readonly PropertyInfo<int> PropertyIdProperty = RegisterProperty<int>(c => c.PropertyId);

		#endregion

		#region Execution

		public static async Task<ListPropertyCommand> ExecuteAsync(int propertyId)
		{
			var cmd =
				new ListPropertyCommand
				{
					PropertyId = propertyId,
				};

			return await DataPortal.ExecuteAsync(cmd);
		}

		#endregion

		#region Data Access

		protected new async Task DataPortal_Execute()
		{
			var dal = ServiceFactory.Instance.GetService<IPropertyDAL>();
			await dal.ListPropertyAsync(this.PropertyId);
		}

		#endregion
	}
}