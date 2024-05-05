using ETickets.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace ETickets.PL.ViewModels
{
    public class ProducerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Picture")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Bio { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
