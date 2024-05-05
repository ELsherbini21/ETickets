using ETickets.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Data.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            // [Cinema && Movies] RelationShips
            builder.HasOne(movie => movie.Cinema)
                .WithMany(cinema => cinema.Movies)
                .HasForeignKey(cinema => cinema.CinemaId);

            // [Producer && Movies] RelationShips
            builder.HasOne(movie => movie.Producer)
              .WithMany(producer => producer.Movies)
              .HasForeignKey(producer => producer.ProducerId);
        }
    }

}


