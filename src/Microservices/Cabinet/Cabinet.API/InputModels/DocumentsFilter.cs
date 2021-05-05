using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class DocumentsFilter
	{
		public int? OrganizationReceiverID { get; set; }

		public int? OrganizationOwnerID { get; set; }

		public int[] DocTypeID { get; set; }

		[BindNever]
		public bool IsValid 
		{
			get => OrganizationReceiverID is { } || OrganizationOwnerID is { };
		}
	}
}
