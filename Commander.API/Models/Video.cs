using System.ComponentModel.DataAnnotations;
using Commander.API.Data;

namespace Commander.API.Models
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