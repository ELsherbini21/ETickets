using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;

namespace ETickets.BLL.Repositories
{
    public class ActorsMoviesRepository
        : GenericRepository<ActorsMovies>, IActorsMoviesRepository
    {
        public ActorsMoviesRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }
    }
}
