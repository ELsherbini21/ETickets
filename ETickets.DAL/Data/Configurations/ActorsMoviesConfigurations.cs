using ETickets.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace ETickets.DAL.Data.Configurations
{
    public class ActorsMoviesConfigurations : IEntityTypeConfiguration<ActorsMovies>
    {
        public void Configure(EntityTypeBuilder<ActorsMovies> builder)
        {
            builder.ToTable("ActorsMovies");

            builder.HasKey(
                entity => new { entity.ActorId, entity.MovieId }
            );
           
            // [Movie && ActorsMovies] RelationShips
            builder.HasOne(entity => entity.Movie)
                .WithMany(movie => movie.ActorsMovies)
                .HasForeignKey(movie => movie.MovieId);

            // [Actor && ActorsMovies] RelationShips
            builder.HasOne(entity => entity.Actor)
                .WithMany(actor => actor.ActorsMovies)
                 .HasForeignKey(actor => actor.ActorId);


        }
    }
}
