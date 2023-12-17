using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CabukHemenSimdiIzle.MVC.Models;
using CabukHemenSimdiIzle.Domain.Dtos;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Persistence.Contexts;

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
        public IActionResult Add()
        {
            return View(new DirectorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(DirectorAddDto directorAddDto, CancellationToken cancellationToken)
        {
            if (directorAddDto is null || string.IsNullOrEmpty(directorAddDto.FirstName) || string.IsNullOrEmpty(directorAddDto.LastName))
            {
                ModelState.AddModelError(string.Empty, "Please enter director information.");
                return View(new DirectorViewModel()); // Return the form with errors
            }

            var id = Guid.NewGuid();

            var director = new Director()
            {
                Id = id,
                FirstName = directorAddDto.FirstName,
                LastName = directorAddDto.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser",
                IsDeleted = false,
            };

            await _appDbContext.Directors.AddAsync(director, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            var directorViewModel = new DirectorViewModel
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName,
                CreatedOn = director.CreatedOn,
                CreatedByUserId = director.CreatedByUserId,
                IsDeleted = director.IsDeleted,
            };

            return View("Add", directorViewModel); // Return to the form with successful model
        }
    }
}
