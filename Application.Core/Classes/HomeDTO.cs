using System.ComponentModel.DataAnnotations;

namespace Application.Core
{
    public class HomeDTO
    {
        public int HomeID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required, StringLength(300)]
        public string Address { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public int NumberOfFloors { get; set; }
    }
}
