using Ambilight.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambilight.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();

        Task<bool> CreateEventAsync(Event event_);

        Task<Event> GetEventByIdAsync(Guid eventId);

        Task<bool> UpdateEventAsync(Event eventToUpdate);

        Task<bool> DeleteEventAsync(Guid eventId);

    }
}
