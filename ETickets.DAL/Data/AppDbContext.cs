using ETickets.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region DbSets Properties 
        public DbSet<Actor> Actors { get; set; }

        public DbSet<ActorsMovies> ActorsMovies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }
        #endregion

        #region  On Model Creating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Actor>().Property(actor => actor.Id)
                .UseIdentityColumn(10, 10);

            modelBuilder.Entity<ActorsMovies>().Property(am => am.Id)
               .UseIdentityColumn(10, 10);

            modelBuilder.Entity<Cinema>().Property(cinema => cinema.Id)
                .UseIdentityColumn(10, 10);

            modelBuilder.Entity<Movie>().Property(movie => movie.Id)
               .UseIdentityColumn(10, 10);

            modelBuilder.Entity<Producer>().Property(producer => producer.Id)
               .UseIdentityColumn(10, 10);
        }
        #endregion
    }
}
