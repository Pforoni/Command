using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string VideoName { get; set; }

        [Required]
        public string URL { get; set; }
        
        [Required]
        public string Assunto { get; set; }
    }
}