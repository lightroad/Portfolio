using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Utilities
{
	public class DataEntities
	{
		private static PortfolioEntities _entities = new PortfolioEntities();
		public static PortfolioEntities Entities
		{
			get { return _entities; }
		}


	}
}
