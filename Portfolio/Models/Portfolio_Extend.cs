using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Portfolio
	{
		/// <summary>
		/// MS-SQL에 \r\n로 저장했지만 로드 시 \\r\\n로 로드되어 개행되지 않아 <br/> \r\n로 변환을 위한 Partial Class
		/// </summary>
		public string PortfolioDescription => PortfolioDesc.Replace("\\r\\n", "\r\n");
	}
}
