using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.Library.Models.Offers;

namespace OrangeBricks.Library.Tests.Models.Offers
{
	[TestFixture]
	public class AcceptOfferCommandTests
	{
		[Test]
		public async Task ExecuteAsync_CallsDalCorrectly()
		{
			int propertyId = 1;
			int offerId = 2;

			var container = new UnityContainer();
			var offerDal = Substitute.For<IOfferDAL>();
			offerDal.AcceptOfferAsync(propertyId, offerId).Returns(Task.FromResult(false));
			container.RegisterInstance<IOfferDAL>(offerDal);

			ServiceFactory.Instance = new ServiceFactory(container);

			var sut = await AcceptOfferCommand.ExecuteAsync(propertyId, offerId);

			await offerDal.Received().AcceptOfferAsync(propertyId, offerId);
		}
	}
}