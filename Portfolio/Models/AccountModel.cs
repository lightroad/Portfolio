using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class AccountModel
	{
		public string UserID { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
		public Nullable<byte> AuthorityID { get; set; }
		public Nullable<byte> EncryptionTypeID { get; set; }
		public Nullable<byte> UsePeriod { get; set; }
		public Nullable<System.DateTime> CreateDate { get; set; }
		public Nullable<System.DateTime> UpdateDate { get; set; }

		public virtual Authority Authority { get; set; }
		public virtual EncryptionType EncryptionType { get; set; }
	}
}
