using CabukHemenSimdiIzle.Application.Features.Queries.DirectorQueries;
using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.CastQueries
{
    public class AddCastHandler : IRequestHandler<AddCastRequest, AddCastResponse>
    {
        private readonly ICastWriteRepository _castWriteRepository;

        public AddCastHandler(ICastWriteRepository castWriteRepository)
        {
            _castWriteRepository = castWriteRepository;
        }

        public Task<AddCastResponse> Handle(AddCastRequest request, CancellationToken cancellationToken)
        {
            var cast = new Cast()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _castWriteRepository.AddAsync(cast);
            _castWriteRepository.SaveAsync();

            return Task.FromResult(new AddCastResponse());
        }
    }
}
