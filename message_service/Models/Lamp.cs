namespace message_service.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Lamp
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
