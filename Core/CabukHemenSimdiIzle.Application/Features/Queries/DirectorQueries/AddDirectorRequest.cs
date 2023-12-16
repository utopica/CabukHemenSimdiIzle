using CabukHemenSimdiIzle.Application.Features.Queries.ScenaristQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.DirectorQueries
{
    public class AddDirectorRequest : IRequest<AddDirectorResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
