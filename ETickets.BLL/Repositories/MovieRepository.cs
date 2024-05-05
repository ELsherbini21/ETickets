using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;

namespace ETickets.BLL.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }
    }
}
