using CabukHemenSimdiIzle.Application.Features.Queries.DirectorQueries;
using CabukHemenSimdiIzle.Application.Features.Queries.ScenaristQueries;
using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.MovieQueries
{
    public class AddMovieHandler : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        private readonly IMovieWriteRepository _movieWriteRepository;
        public Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                PictureUrl = request.PictureUrl,
                ReleaseDate = request.ReleaseDate,
                Language = request.Language,
                Genre = request.Genre,
                ImdbRating = request.ImdbRating,
                AgeRestriction = request.AgeRestriction,
                Duration = request.Duration,
            };

            _movieWriteRepository.AddAsync(movie);
            _movieWriteRepository.SaveAsync();

            return Task.FromResult(new AddMovieResponse());

        }
    }
}
