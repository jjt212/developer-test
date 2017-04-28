using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.DataAccess.DALs;
using OrangeBricks.IDataAccess.DTOs.Properties;
using Ploeh.AutoFixture;

namespace OrangeBricks.DataAccess.Tests.DALs
{
	[TestFixture]
	public class PropertyDALTests
	{
		private Fixture _fixture = new Fixture();
		private IOrangeBricksContext _context;
		private IDbSet<Models.Property> _properties;

		[SetUp]
		public void SetUp()
		{
			_context = Substitute.For<IOrangeBricksContext>();
			_properties = Substitute.For<IDbSet<Models.Property>>();
			_context.Properties.Returns(_properties);
		}

		#region InsertAsync Tests

		[Test]
		public async Task InsertAsync_ShouldAddProperty()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Any<Models.Property>());
		}

		[Test]
		public async Task InsertAsync_ShouldAddPropertyWithCorrectPropertyType()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.PropertyType == dto.PropertyType));
		}

		[Test]
		public async Task InsertAsync_ShouldAddPropertyWithCorrectStreetName()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.StreetName == dto.StreetName));
		}

		[Test]
		public async Task InsertAsync_ShouldAddPropertyWithCorrectDescription()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.Description == dto.Description));
		}

		[Test]
		public async Task InsertAsync_ShouldAddPropertyWithCorrectNumberOfBedrooms()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.NumberOfBedrooms == dto.NumberOfBedrooms));
		}

		[Test]
		public async Task InsertAsync_ShouldAddPropertyWithCorrectSeller()
		{
			// Arrange
			var dto = _fixture.Create<PropertyDTO>();
			var sut = new PropertyDAL(_context);

			// Act
			await sut.InsertAsync(dto);

			// Assert
			_context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.SellerUserId == dto.SellerUserId));
		}

		#endregion

		#region ListPropertyAsync Tests

		[Test]
		public async Task ListPropertyAsync_ShouldUpdatePropertyToBeListedForSale()
		{
			// Arrange
			var propertyId = _fixture.Create<int>();

			var property = new Models.Property
			{
				Description = "Test Property",
				IsListedForSale = false
			};

			_properties.Find(propertyId).Returns(property);

			var sut = new PropertyDAL(_context);

			// Act
			await sut.ListPropertyAsync(propertyId);

			// Assert
			_context.Properties.Received(1).Find(propertyId);
			await _context.Received(1).SaveChangesAsync();
			Assert.True(property.IsListedForSale);
		}

		#endregion
	}
}