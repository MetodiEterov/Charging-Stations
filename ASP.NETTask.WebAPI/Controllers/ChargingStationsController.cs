using System.Threading.Tasks;

using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace ASP.NETTask.WebAPI.Controllers
{
    [Route("ChargingStations")]
    [ApiController]
    public class ChargingStationsController : ControllerBase
    {
        private readonly ILocationRepository<BaseClass> _locationRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IMapper _mapper;

        public ChargingStationsController(
            ILocationRepository<BaseClass> locationRepository
            , IMapper mapper
            , IMessageBroker messageBroker)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
            _messageBroker = messageBroker;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locations = await _locationRepository.GetAllLocation();
            if (locations == null) return NotFound();

            _messageBroker.SendMessageToQueu("All locations were loaded!");

            return Ok(locations);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound("Not such id number!");

            var location = await _locationRepository.GetLocationById(id);
            if (location == null) return NotFound("The location couldn't be found.");

            _messageBroker.SendMessageToQueu("The location by Id was loaded!");

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationRequestModelDto entity)
        {
            if (!ModelState.IsValid || entity == null) return BadRequest();

            var location = await _locationRepository.AddNewLocation(_mapper.Map<LocationRequestModel>(entity));
            _messageBroker.SendMessageToQueu("The new locations has been created!");

            return Ok(location);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ChargePointRequestModelDto entity)
        {
            if (!ModelState.IsValid || entity == null) return BadRequest();

            var location = await _locationRepository.PutLocation(_mapper.Map<ChargePointRequestModel>(entity));
            _messageBroker.SendMessageToQueu("The new locations has been upated!");

            return Ok(location);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] PatchLocationRequestModelDto entity)
        {
            if (!ModelState.IsValid || entity == null) return BadRequest();

            var location = await _locationRepository.PatchLocation(_mapper.Map<PatchLocationRequestModel>(entity));
            _messageBroker.SendMessageToQueu("The new locations has been updated!");

            return Ok(location);
        }
    }
}