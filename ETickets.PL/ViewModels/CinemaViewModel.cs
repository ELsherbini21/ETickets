using ETickets.DAL.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ETickets.PL.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ValidateNever]
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
