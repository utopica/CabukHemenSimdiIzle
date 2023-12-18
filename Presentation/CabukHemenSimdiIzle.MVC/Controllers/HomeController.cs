using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Domain.Enums;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;

namespace CabukHemenSimdiIzle.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var movies = _appDbContext.Movies
                .Select(movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    PictureUrl = movie.PictureUrl,
                    ReleaseDate = movie.ReleaseDate,
                    // Add other properties as needed
                })
                .ToList();
            return View(movies);
        }

        [HttpGet]
        [Route("Home/Detail/{id}")]
        public IActionResult Detail(string id)
        {
            var movie = _appDbContext.Movies
                .Where(movie => movie.Id == Guid.Parse(id))
                .Select(movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    PictureUrl = movie.PictureUrl,
                    ReleaseDate = movie.ReleaseDate,
                    Language = movie.Language,
                    Genre = movie.Genre,
                    ImdbRating = movie.ImdbRating,
                    AgeRestriction = movie.AgeRestriction,
                    Duration = movie.Duration,
                    DirectorIds = movie.DirectorMovies.Select(directorMovie => directorMovie.DirectorId).ToList(),
                    ScenaristIds = movie.ScenaristMovies.Select(scenaristMovie => scenaristMovie.ScenaristId).ToList(),
                    CastIds = movie.CastMovies.Select(castMovie => castMovie.CastId).ToList(),
                   
                })
                .FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        [HttpGet]
        [Route("Home/MovieGenre/{genre}")]
        public IActionResult MovieGenre(Genre? genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            List<MovieViewModel> movies = _appDbContext.Movies.Where(x => x.Genre == genre).Select(movie => new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                PictureUrl = movie.PictureUrl,
                ReleaseDate = movie.ReleaseDate,
                // Add other properties as needed
            }).ToList();
            /*if(movies.Count == 0 || movies == null)
            {
                //Or we dont have this movies view page
                return NotFound();
            }*/
            return View(movies);
        }

        [HttpGet]
        [Route("Home/LatestMovie")]
        public IActionResult LatestMovies()
        {
           
            List<MovieViewModel> movies = _appDbContext.Movies.OrderBy(x=> x.ReleaseDate).Select(movie => new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                PictureUrl = movie.PictureUrl,
                ReleaseDate = movie.ReleaseDate,
                // Add other properties as needed
            }).ToList();
            /*if(movies.Count == 0 || movies == null)
            {
                //Or we dont have this movies view page
                return NotFound();
            }*/
            
            return View(movies);
        }

       
    }
}

