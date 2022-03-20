using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebFlix.Models;
using static WebFlix.Models.MovieCatalogue;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        static List<MovieCatalogue> _movieCatalogues = new List<MovieCatalogue>()
        {
            new MovieCatalogue(){MovieId = 1, Title ="Rampage", Genre = Genres.crime, Certification = Certifications.universal, Rating = 5, ReleaseDate = "1999"},
            new MovieCatalogue(){MovieId = 2, Title ="Hancock", Genre = Genres.action, Certification = Certifications._15, Rating = 9, ReleaseDate = "1993"},
            new MovieCatalogue(){MovieId = 3, Title ="Scary Movie", Genre = Genres.animation, Certification = Certifications._12, Rating = 3, ReleaseDate = "2009"},
            new MovieCatalogue(){MovieId = 4, Title ="Joker", Genre = Genres.family, Certification = Certifications._15, Rating = 5, ReleaseDate = "2019"},


        };


        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieCatalogue> Get()
        {
            var movieCatalogues = _movieCatalogues.OrderByDescending(p => p.ReleaseDate);
            foreach(var movieCatalogue in movieCatalogues)
            {
                yield return movieCatalogue;
            }
            //return movieCatalogues;
        }

        // GET api/<MovieController>/5
        [HttpGet("ByIdnNumber/{_id}")]
        public IEnumerable<MovieCatalogue> Get(int _id)
        {
            return _movieCatalogues.Where(p => p.MovieId.Equals(_id));
        }

        // GET: api/<MovieController>
        [HttpGet("ByKeyword/{_id}")]
        public IEnumerable<MovieCatalogue> GetByReleaseDate(string _keyword)
        {
            return (IEnumerable<MovieCatalogue>)_movieCatalogues.Where(p => p.Title == _keyword);
            
            
            
            //return (IEnumerable<MovieCatalogue>)keyWord;
            //return _movieCatalogues.FirstOrDefault(p => p.ReleaseDate.Equals(_keyword));
            
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
