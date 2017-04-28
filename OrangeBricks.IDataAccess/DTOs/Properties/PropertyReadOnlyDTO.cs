namespace OrangeBricks.IDataAccess.DTOs.Properties
{
	public class PropertyReadOnlyDTO
	{
		public int PropertyId { get; set; }
		public string PropertyType { get; set; }
		public int NumberOfBedrooms { get; set; }
		public string StreetName { get; set; }
		public string Description { get; set; }
		public bool HasOffers { get; set; }
		public bool IsListedForSale { get; set; }
	}
}