namespace OrangeBricks.Web.DTOs
{
	public class CreatePropertyDTO
	{
		public class PropertyDTO
		{
			public string PropertyType { get; set; }
			public string StreetName { get; set; }
			public string Description { get; set; }
			public int NumberOfBedrooms { get; set; }
		}

		public PropertyDTO Property { get; set; }
	}
}