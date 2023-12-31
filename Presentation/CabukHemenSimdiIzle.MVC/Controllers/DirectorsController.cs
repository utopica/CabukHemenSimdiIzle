﻿using Microsoft.AspNetCore.Mvc;
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
            return View(new PeopleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(PeopleAddDto peopleAddDto,CancellationToken cancellationToken)
        {
            
            if (peopleAddDto is null || string.IsNullOrEmpty(peopleAddDto.FirstName) || string.IsNullOrEmpty(peopleAddDto.LastName))
            {
                ModelState.AddModelError(string.Empty, "Please enter director information.");
                return View(new PeopleViewModel());
            }

            var id = Guid.NewGuid();

            var director = new Director()
            {
                Id = id,
                FirstName = peopleAddDto.FirstName,
                LastName = peopleAddDto.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = "testUser",
                IsDeleted = false,
            };


            await _appDbContext.Directors.AddAsync(director, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            var peopleViewModel = new PeopleViewModel
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName,
                CreatedOn = director.CreatedOn,
                CreatedByUserId = director.CreatedByUserId,
                IsDeleted = director.IsDeleted,

            };


            return View(peopleViewModel); 
            
          
        }
    }
}
