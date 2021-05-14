using Shared.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.IntegrationEvents
{
	public interface IRoutingEventService
	{
		Task PublishEventAsync(IntegrationEvent @event);

		Task SaveEventAndContextChangesAsync(IntegrationEvent @event);
	}
}
