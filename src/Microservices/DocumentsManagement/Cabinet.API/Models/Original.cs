using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class Original
	{
		public Guid ID { get; set; }

		/// <summary>
		/// File hash
		/// </summary>
		public string Hash { get; set; }

		/// <summary>
		/// Size in bytes
		/// </summary>
		public int Size { get; set; }

		/// <summary>
		/// File extension
		/// </summary>
		public string Extension { get; set; }

		/// <summary>
		/// Flag is main documents' file
		/// </summary>
		public bool IsMain { get; set; }

		public DateTime UploadDate { get; set; }

		public Guid DocumentID { get; set; }

		public Document Document { get; set; }
	}
}
