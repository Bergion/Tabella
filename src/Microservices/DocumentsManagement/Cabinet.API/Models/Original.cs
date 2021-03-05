using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class Original
	{
		public int ID { get; set; }

		/// <summary>
		/// File hash
		/// </summary>
		public string Hash { get; set; }

		public DateTime UploadDate { get; set; }

		public Guid DocumentID { get; set; }

		public Document Document { get; set; }
	}
}
