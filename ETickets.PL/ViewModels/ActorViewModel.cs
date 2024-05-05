using ETickets.DAL.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace ETickets.PL.ViewModels
{
    public class ActorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [Display(Name = "Picture")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<ActorsMovies> ActorsMovies { get; set; }
     
    }
}
