using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class Original
	{
		/// <summary>
		/// Original identifier
		/// also used as unique file name
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Original file name
		/// </summary>
		public string FileName { get; set; }

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

		/// <summary>
		/// File storage identifier 
		/// bucket name, server path, etc.
		/// </summary>
		public string StorageSource { get; set; }

		public string StoragePath { get; set; }

		/// <summary>
		/// Upload date
		/// </summary>
		public DateTime UploadDate { get; set; } = DateTime.Now;

		public Guid DocumentID { get; set; }

		public Document Document { get; set; }
	}
}
