using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;

namespace ETickets.BLL.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }
    }
}
