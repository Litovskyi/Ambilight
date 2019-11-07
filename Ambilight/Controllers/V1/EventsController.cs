using Ambilight.Contracts.V1;
using Ambilight.Contracts.V1.Requests;
using Ambilight.Contracts.V1.Responses;
using Ambilight.Domain;
using Ambilight.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambilight.Controllers
{
    public class EventsController: Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }


        [HttpGet(ApiRoutes.Events.GetAll)]
        public  async Task<IActionResult> GetAll()
        {
            return Ok(await _eventService.GetEventsAsync());
        }

        [HttpPut(ApiRoutes.Events.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid eventId, [FromBody]UpdateEventRequest request)
        {
            var event_ = new Event
            {
                Id = eventId,
                Name = request.Name
            };

            var updated = await _eventService.UpdateEventAsync(event_);

            if(updated)
            return Ok(event_);

            return NotFound();
        }
        [HttpDelete(ApiRoutes.Events.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid eventId)
        {
           

            var deleted = await _eventService.DeleteEventAsync(eventId);

            if (deleted)
                return NoContent();

            return NotFound();

            
        }

        [HttpGet(ApiRoutes.Events.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid eventId)
        {
            var event_ = await _eventService.GetEventByIdAsync(eventId);

            if (event_ == null)
                return NotFound();

            return Ok(event_);
        }

        


        [HttpPost(ApiRoutes.Events.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRequest eventRequest)
        {
            var event_ = new Event { Name = eventRequest.Name };


            if (event_.Id !=Guid.Empty)
                event_.Id = Guid.NewGuid();

            await _eventService.CreateEventAsync(event_);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{eventId}", event_.Id.ToString());
            var response = new EventResponse { Id = event_.Id };
            return Created(locationUri, response);
        }
    }
}
