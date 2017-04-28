using OrangeBricks.Library.Models.Properties;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
	public class PropertiesViewModel
	{
		public PropertyReadOnlyList Properties { get; set; }
		public string Search { get; set; }
	}
}