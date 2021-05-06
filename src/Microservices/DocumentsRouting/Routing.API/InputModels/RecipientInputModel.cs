using Routing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.InputModels
{
	public class RecipientInputModel
	{
		public string OkpoOrInn { get; set; }

		public string Email { get; set; }

		public bool IsValid
		{
			get => !string.IsNullOrWhiteSpace(OkpoOrInn);
		}
	}
}
