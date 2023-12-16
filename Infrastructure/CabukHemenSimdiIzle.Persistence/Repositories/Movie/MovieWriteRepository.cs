﻿using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Repositories
{
    public class MovieWriteRepository : WriteRepository<Movie>, IMovieWriteRepository
    {
        public MovieWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}