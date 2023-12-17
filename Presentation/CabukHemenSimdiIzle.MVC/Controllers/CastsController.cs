using CabukHemenSimdiIzle.Domain.Dtos;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;

namespace CabukHemenSimdiIzle.MVC.Controllers
{
    public class CastsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CastsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new PeopleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(PeopleAddDto peopleAddDto, CancellationToken cancellationToken)
        {
            if (peopleAddDto is null || string.IsNullOrEmpty(peopleAddDto.FirstName) || string.IsNullOrEmpty(peopleAddDto.LastName))
            {
                ModelState.AddModelError(string.Empty, "Please enter director information.");
                return View(new PeopleViewModel());
            }

            var id = Guid.NewGuid();

            var cast = new Cast()
            {
                Id = id,
                FirstName = peopleAddDto.FirstName,
                LastName = peopleAddDto.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser",
                IsDeleted = false,
            };

            await _appDbContext.Casts.AddAsync(cast, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            var peopleViewModel = new PeopleViewModel
            {
                Id = cast.Id,
                FirstName = cast.FirstName,
                LastName = cast.LastName,
                CreatedOn = cast.CreatedOn,
                CreatedByUserId = cast.CreatedByUserId,
                IsDeleted = cast.IsDeleted,

            };

            return View(peopleViewModel);
        }
    }
}
