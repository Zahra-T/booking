using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Booking.Models;
using Booking.Services;
using Booking.Resources;
using Booking.Queries;
using System;

namespace Booking.Controllers
{
    [Route("/api/v1/shows")]
    [Produces("application/json")]
    [ApiController]
    public class ShowsController : Controller
    {
        private readonly IShowService _showService;
        private readonly IMapper _mapper;

        public ShowsController(IShowService showService, IMapper mapper)
        {
            _showService = showService;
            _mapper = mapper;
        }

        // Return a list of shows
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<ShowResource>), 200)]
        public async Task<QueryResultResource<ShowResource>> ListAsync([FromQuery] ShowsQueryResource query)
        {
            var showsQuery = _mapper.Map<ShowsQueryResource, ShowsQuery>(query);
            var queryResult = await _showService.ListAsync(showsQuery);

            var resource = _mapper.Map<QueryResult<Show>, QueryResultResource<ShowResource>>(queryResult);
            return resource;
        }

        // Add a show
        [HttpPost]
        [ProducesResponseType(typeof(ShowResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync(SaveShowResource resource)
        {
            var show = _mapper.Map<SaveShowResource, Show>(resource);
            var result = await _showService.SaveAsync(show);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var showResource = _mapper.Map<Show, ShowResource>(result.Resource);
            return Ok(showResource);
        }

        // Update a show
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ShowResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveShowResource resource)
        {
            var show = _mapper.Map<SaveShowResource, Show>(resource);
            var result = await _showService.UpdateAsync(id, show);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var showResource = _mapper.Map<Show, ShowResource>(result.Resource);
            return Ok(showResource);
        }

        // Delete a show
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ShowResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _showService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var showResource = _mapper.Map<Show, ShowResource>(result.Resource);
            return Ok(showResource);
        }
    }
}