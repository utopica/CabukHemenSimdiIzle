using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Contexts
{
    public class IdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<Cast>();
            modelBuilder.Ignore<Scenarist>();
            modelBuilder.Ignore<Director>();
            modelBuilder.Ignore<Comment>();
            modelBuilder.Ignore<Movie>();
            modelBuilder.Ignore<CastMovie>();
            modelBuilder.Ignore<DirectorMovie>();
            modelBuilder.Ignore<ScenaristMovie>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
