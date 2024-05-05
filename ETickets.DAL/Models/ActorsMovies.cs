using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Models
{
    public class ActorsMovies : ModelBase
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }


        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }


    }
}
