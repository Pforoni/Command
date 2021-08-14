using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commander.API.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlatformName { get; set; }

    }
}