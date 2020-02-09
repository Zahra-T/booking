using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Booking.Models;
using Booking.Services;
using Booking.Resources;

namespace Booking.Controllers
{

    [Route("api-v1/salons")]
    [Produces("application/json")]
    [ApiController]
    public class SalonControler : ControllerBase 
    {
        private readonly ISalonService _salonService;
        private readonly IMapper _mapper;
        public SalonControler(ISalonService salonService, IMapper mapper){
            _salonService = salonService;
            _mapper = mapper;
        }

        // GET api-vi/salons
        // Return a list of salons.
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SalonResource>), 200)]
        public async Task<IEnumerable<SalonResource>> ListAsync(){
            var salons = await _salonService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Salon>, IEnumerable<SalonResource>>(salons);

            return resources;
        }
     
        // Add a salon
        [HttpPost]
        [ProducesResponseType(typeof(SalonResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync(SaveSalonResource resource)
        {
            var salon = _mapper.Map<SaveSalonResource, Salon>(resource);
            var result = await _salonService.SaveAsync(salon);

            if(!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var salonResource = _mapper.Map<Salon, SalonResource>(result.Resource);
            return Ok(salonResource);
        }

        // Update a salon
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SalonResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, SaveSalonResource resource)
        {
            var salon = _mapper.Map<SaveSalonResource, Salon>(resource);
            var result = await _salonService.UpdateAsync(id, salon);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var salonResource = _mapper.Map<Salon, SalonResource>(result.Resource);
            return Ok(salonResource);
        }

        //Delete a salon
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SalonResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _salonService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var salonResource = _mapper.Map<Salon, SalonResource>(result.Resource);
            return Ok(salonResource);
        }
        
    }   

}
