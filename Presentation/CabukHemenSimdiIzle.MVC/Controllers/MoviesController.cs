using CabukHemenSimdiIzle.Domain.Dtos;
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

        [HttpPost]
        public async Task<IActionResult> AddAsync(MovieAddDto movieAddDto, CancellationToken cancellationToken)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var movies = await _assignmentDbContext
                .Movies
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            return Ok(movies);
        }

    }
}
