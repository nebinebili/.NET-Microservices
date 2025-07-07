using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo commandRepo,IMapper mapper)
        {
            _commandRepo=commandRepo;
            _mapper=mapper;
        }

        [HttpGet("GetPlatforms")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPLatforms()
        {
            Console.WriteLine("-----> Getting Platforms from CommandServices");

            var platformItems=_commandRepo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems)); 
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("----> Inbound POST ## Command Service");

            return Ok("Inbound test of from Platforms Controlerr");
        }
    }
}
