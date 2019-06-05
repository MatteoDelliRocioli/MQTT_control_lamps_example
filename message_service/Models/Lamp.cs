using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace message_service.Models
{
    public class Lamp
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
