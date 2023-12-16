using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.ScenaristQueries
{
    public class AddScenaristHandler : IRequestHandler<AddScenaristRequest, AddScenaristResponse>
    {
        private readonly IScenaristWriteRepository _scenaristWriteRepository;

        public AddScenaristHandler(IScenaristWriteRepository scenaristWriteRepository)
        {
            this._scenaristWriteRepository = scenaristWriteRepository;
        }

        public Task<AddScenaristResponse> Handle(AddScenaristRequest request, CancellationToken cancellationToken)
        {
            var scenarist = new Scenarist()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _scenaristWriteRepository.AddAsync(scenarist);
            _scenaristWriteRepository.SaveAsync();

            return Task.FromResult(new AddScenaristResponse());
        }
    }
}
