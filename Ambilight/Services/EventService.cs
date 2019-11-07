using Ambilight.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ambilight.Data;
using Microsoft.EntityFrameworkCore;

namespace Ambilight.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EventService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<List<Event>> GetEventsAsync()
        {
            return await _applicationDbContext.Events.ToListAsync();
        }

        public async Task<Event>  GetEventByIdAsync(Guid eventId)
        {
            return await _applicationDbContext.Events.SingleOrDefaultAsync(x => x.Id == eventId);
        }

        public async Task<bool> CreateEventAsync(Event event_)
        {
            await _applicationDbContext.Events.AddAsync(event_);
            var created = await _applicationDbContext.SaveChangesAsync();

            return created > 0;

        }

        public async Task<bool> UpdateEventAsync(Event eventToUpdate)
        {


             _applicationDbContext.Events.Update(eventToUpdate);
            var updated = await _applicationDbContext.SaveChangesAsync();
            return updated>0;
        }


        public async Task<bool> DeleteEventAsync(Guid eventId)
        {
            var event_ = await GetEventByIdAsync(eventId);

            if (event_ == null)
                return false;

            _applicationDbContext.Events.Remove(event_);
            var deleted = await _applicationDbContext.SaveChangesAsync();
            return deleted>0;

           
        }
    }
}
