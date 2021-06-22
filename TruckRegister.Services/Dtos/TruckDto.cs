using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TruckRegister.Entities.Enums;

namespace TruckRegister.Services.Dtos
{
    public class TruckDto
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumModel ModelDescription { get;  set; }
           
        [Required]
        public int YearOfModel { get;  set; }
    }
}
