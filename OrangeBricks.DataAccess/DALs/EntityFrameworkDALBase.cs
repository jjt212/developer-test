using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.DataAccess.DALs
{
	public class EntityFrameworkDALBase
	{
		protected IOrangeBricksContext _context;

		public EntityFrameworkDALBase(IOrangeBricksContext context)
		{
			this._context = context;
		}
	}
}