using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTOs
{
    public class PlatformReadDto
    {
 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Cost { get; set; }
    }
}
