using CabukHemenSimdiIzle.Domain.Dtos;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CabukHemenSimdiIzle.MVC.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DirectorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DirectorAddDto directorAddDto)
        {
            
            if(directorAddDto is null || string.IsNullOrEmpty(directorAddDto.FirstName) || string.IsNullOrEmpty(directorAddDto.LastName))
            {
                return BadRequest("Please enter director informations.");
            }


            var id = Guid.NewGuid();

            var directorMovies = directorAddDto.MovieIds?.Select(movieId => new DirectorMovie
            {
                DirectorId = id,
                MovieId = movieId,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser"
            }).ToList();

            var director = new Director()
            {
                Id = id,
                FirstName = directorAddDto.FirstName,
                LastName = directorAddDto.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser",
                IsDeleted = false,
                DirectorMovies = directorMovies
            };

            await _appDbContext.Directors.AddAsync(director);

            await _appDbContext.SaveChangesAsync();

            var directorViewModel = new DirectorViewModel
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName,
                CreatedOn = director.CreatedOn,
                CreatedByUserId = director.CreatedByUserId,
                MovieIds = directorMovies?.Select(dm => dm.MovieId).ToList() ?? new List<Guid>()
            };

            return View(directorViewModel);
        }
    }
}
