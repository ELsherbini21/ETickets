using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Models
{
    public class Cinema : ModelBase
    {
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
