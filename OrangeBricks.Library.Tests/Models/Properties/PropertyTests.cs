using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.IDataAccess;
using OrangeBricks.IDataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;
using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Library.Tests.Models.Properties
{
	[TestFixture]
	public class PropertyTests
	{
		[Test]
		public async Task Create_CallsDalCorrectly()
		{
			PropertyDTO dtoArg = null;

			var container = new UnityContainer();
			var propertyDal = Substitute.For<IPropertyDAL>();
			propertyDal.InsertAsync(Arg.Do<PropertyDTO>(dto => dtoArg = dto))
				.ReturnsForAnyArgs((ci) => Task.FromResult(dtoArg));
			container.RegisterInstance<IPropertyDAL>(propertyDal);

			ServiceFactory.Instance = new ServiceFactory(container);

			var sut = Property.Create("sellerUserId");
			sut.PropertyType = "Flat";
			sut.StreetName = "123 Main Street";
			sut.Description = "A very nice flat.";
			sut.NumberOfBedrooms = 2;

			sut = await sut.SaveAsync();

			Assert.That(sut.PropertyId, Is.EqualTo(dtoArg.PropertyId));
			Assert.That(sut.SellerUserId, Is.EqualTo(dtoArg.SellerUserId));
			Assert.That(sut.PropertyType, Is.EqualTo(dtoArg.PropertyType));
			Assert.That(sut.StreetName, Is.EqualTo(dtoArg.StreetName));
			Assert.That(sut.Description, Is.EqualTo(dtoArg.Description));
			Assert.That(sut.NumberOfBedrooms, Is.EqualTo(dtoArg.NumberOfBedrooms));
		}
	}
}