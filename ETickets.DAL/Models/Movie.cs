using ETickets.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Models
{
    public class Movie : ModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }


        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }


        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }


        public virtual ICollection<ActorsMovies> ActorsMovies { get; set; }
            = new List<ActorsMovies>();



    }
}
