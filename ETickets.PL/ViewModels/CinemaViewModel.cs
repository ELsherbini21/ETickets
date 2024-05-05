using ETickets.DAL.Models;

namespace ETickets.PL.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
