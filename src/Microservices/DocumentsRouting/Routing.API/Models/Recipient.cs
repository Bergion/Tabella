using Routing.API.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.Models
{
	public enum Status
	{
		Pending,
		Completed,
		Rejected
	}

	public class Recipient
	{
		public int ID { get; set; }

		public int RouteID { get; set; }

		public string OkpoOrInn { get; set; }

		public Status Status { get; set; }

		public DateTime Created { get; set; } = DateTime.Now;

		[System.Text.Json.Serialization.JsonIgnore]
		public Route Route { get; set; }

		public static explicit operator Recipient(RecipientInputModel model)
		{
			return new Recipient()
			{
				OkpoOrInn = model.OkpoOrInn,
			};
		}
	}
}
