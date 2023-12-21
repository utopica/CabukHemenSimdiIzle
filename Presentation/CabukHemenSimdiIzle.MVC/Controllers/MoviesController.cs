using CabukHemenSimdiIzle.Domain.Dtos;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CabukHemenSimdiIzle.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieAddDto movieAddDto, CancellationToken cancellationToken)
        {

            if (movieAddDto is null)
            {
                ModelState.AddModelError(string.Empty, "Please enter movie information.");
                return View(new PeopleViewModel());
            }

            List<DirectorMovie> directorMovies = new List<DirectorMovie>();

            List<ScenaristMovie> scenaristMovies = new List<ScenaristMovie>();

            List<CastMovie> castMovies = new List<CastMovie>();

            var id = Guid.NewGuid();

            if (movieAddDto.DirectorIds is not null && movieAddDto.DirectorIds.Any())
            {
                foreach (var directorId in movieAddDto.DirectorIds)
                {
                    var directorMovie = new DirectorMovie()
                    {
                        DirectorId = directorId,
                        MovieId = id,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = "testUser"
                    };

                    directorMovies.Add(directorMovie);
                }
            }

            if (movieAddDto.ScenaristIds is not null && movieAddDto.ScenaristIds.Any())
            {
                foreach (var scenaristId in movieAddDto.ScenaristIds)
                {
                    var scenaristMovie = new ScenaristMovie()
                    {
                        ScenaristId = scenaristId,
                        MovieId = id,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = "testUser"
                    };

                    scenaristMovies.Add(scenaristMovie);
                }
            }

            if (movieAddDto.CastIds is not null && movieAddDto.CastIds.Any())
            {
                foreach (var castId in movieAddDto.CastIds)
                {
                    var castMovie = new CastMovie()
                    {
                        CastId = castId,
                        MovieId = id,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = "testUser"
                    };

                    castMovies.Add(castMovie);
                }
            }

            var movie = new Movie()
            {
                Id = id,
                Title = movieAddDto.Title,
                Description = movieAddDto.Description,
                PictureUrl = movieAddDto.PictureUrl, 
                ReleaseDate = movieAddDto.ReleaseDate,
                Language = movieAddDto.Language,
                Genre = movieAddDto.Genre,
                ImdbRating = movieAddDto.ImdbRating,
                AgeRestriction = movieAddDto.AgeRestriction,
                Duration = movieAddDto.Duration,
                DirectorMovies = directorMovies,
                ScenaristMovies = scenaristMovies,
                CastMovies = castMovies,
                CreatedByUserId = "testUser",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,

            };
          

            await _appDbContext.Movies.AddAsync(movie, cancellationToken);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            var movieViewModel = new MovieViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                PictureUrl = movie.PictureUrl,
                ReleaseDate = movie.ReleaseDate,
                Language = movie.Language,
                Genre = movie.Genre,
                ImdbRating = movie.ImdbRating,
                AgeRestriction = movie.AgeRestriction,
                Duration = movie.Duration,
                DirectorIds = movieAddDto.DirectorIds,
                ScenaristIds = movieAddDto.ScenaristIds,
                CastIds = movieAddDto.CastIds,


            };


            return View(movieViewModel);


        }

    }
}
