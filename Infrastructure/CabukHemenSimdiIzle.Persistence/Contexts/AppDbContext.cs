using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Scenarist> Scenarists { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();

            base.OnModelCreating(modelBuilder);
        }
    }
}