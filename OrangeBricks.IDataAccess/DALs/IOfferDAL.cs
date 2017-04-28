using System.Threading.Tasks;

namespace OrangeBricks.IDataAccess.DALs
{
	public interface IOfferDAL
	{
		Task AcceptOfferAsync(int propertyId, int offerId);
		Task MakeOfferAsync(int propertyId, int offerAmount);
		Task RejectOfferAsync(int propertyId, int offerId);
	}
}