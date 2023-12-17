using CabukHemenSimdiIzle.Domain.Dtos;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CabukHemenSimdiIzle.MVC.Controllers
{
    public class ScenaristsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ScenaristsController(AppDbContext appDbContext)
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

            var scenarist = new Scenarist()
            {
                Id = id,
                FirstName = peopleAddDto.FirstName,
                LastName = peopleAddDto.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser",
                IsDeleted = false,
            };


            await _appDbContext.Scenarists.AddAsync(scenarist, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            var peopleViewModel = new PeopleViewModel
            {
                Id = scenarist.Id,
                FirstName = scenarist.FirstName,
                LastName = scenarist.LastName,


            };


            return View(peopleViewModel);


        }

    }
}
