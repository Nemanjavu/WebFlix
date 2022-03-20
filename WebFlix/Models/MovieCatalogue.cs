using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebFlix.Models
{
    public class MovieCatalogue
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        
        public enum Genres { 
            action ,
            adventure , 
            animation,
            comedy ,
            crime ,
            drama ,
            fantasy ,
            family ,
            horror ,
            scifi ,
            thriller 
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genres Genre { get; set; }
        

        public enum Certifications { 
            universal, 
            _12, 
            _15, 
            _18}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Certifications Certification { get; set;}
        
        public string ReleaseDate { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public int Rating { get; set; }
    }
}
