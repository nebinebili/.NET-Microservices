using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;
using System.Threading.Tasks;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repository;

        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(
            IPlatformRepo repository,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _repository=repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        [HttpGet("GetAllPlatforms")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            var data=_repository.GetAllPLatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(data));
        }
        [HttpGet("GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            if (id > 0) 
            {
                var data=_repository.GetPlatformById(id);
                return data != null ? Ok(_mapper.Map<PlatformReadDto>(data)) : NotFound();
            }

            return BadRequest("Id is not valid");
        }
        [HttpPost("CreatePlatform")]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();

            var platformReadDto=_mapper.Map<PlatformReadDto>(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously:{ex.Message}");
            }

            //return CreatedAtRoute(nameof(GetPlatformById),new {Id=platformReadDto.Id},platformReadDto);
            return Ok(platformReadDto);
        }
    }
}
