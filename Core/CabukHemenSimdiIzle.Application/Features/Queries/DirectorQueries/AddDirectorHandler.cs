using CabukHemenSimdiIzle.Application.Features.Queries.ScenaristQueries;
using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.DirectorQueries
{
    public class AddDirectorHandler : IRequestHandler<AddDirectorRequest, AddDirectorResponse>
    {
        private readonly IDirectorWriteRepository _directorWriteRepository;

        public AddDirectorHandler(IDirectorWriteRepository directorWriteRepository)
        {
            _directorWriteRepository = directorWriteRepository;
        }

        public Task<AddDirectorResponse> Handle(AddDirectorRequest request, CancellationToken cancellationToken)
        {
            var director = new Director()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _directorWriteRepository.AddAsync(director);
            _directorWriteRepository.SaveAsync();

            return Task.FromResult(new AddDirectorResponse());
        }
    }
}
