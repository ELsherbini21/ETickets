namespace ETickets.DAL.Models
{
    public class Actor : ModelBase
    {
        public string ProfilePictureUrl { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }


        public virtual ICollection<ActorsMovies> ActorsMovies { get; set; }


    }
}
