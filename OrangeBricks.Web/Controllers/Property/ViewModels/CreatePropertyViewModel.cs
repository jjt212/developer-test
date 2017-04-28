using System.Collections.Generic;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
	public class CreatePropertyViewModel
	{
		public Library.Models.Properties.Property Property { get; set; }

		public IEnumerable<SelectListItem> PossiblePropertyTypes { get; set; }
	}
}