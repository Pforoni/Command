using System.ComponentModel.DataAnnotations;
using Commander.Data;

namespace Commander.Models
{
    [BsonCollection("video")]
    public class Video : Document
    {
        [Required]       
        public string VideoName { get; set; }

        [Required]
        public string URL { get; set; }
        
        [Required]
        public string Assunto { get; set; }
    }
}