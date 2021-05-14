using Shared.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.IntegrationEvents
{
	public class RoutingEventService : IRoutingEventService, IDisposable
	{
		public Task PublishEventAsync(IntegrationEvent @event)
		{
			throw new NotImplementedException();
		}

		public Task SaveEventAndContextChangesAsync(IntegrationEvent @event)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
