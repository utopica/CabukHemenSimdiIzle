using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence
{
    public static class RepositoryRegistrationService
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IDirectorReadRepository, DirectorReadRepository>();
            services.AddScoped<IDirectorWriteRepository, DirectorWriteRepository>();

            services.AddScoped<IScenaristReadRepository, ScenaristReadRepository>();
            services.AddScoped<IScenaristWriteRepository, ScenaristWriteRepository>();

            services.AddScoped<ICastReadRepository, CastReadRepository>();
            services.AddScoped<ICastWriteRepository, CastWriteRepository>();

            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();



        }
    }
}
