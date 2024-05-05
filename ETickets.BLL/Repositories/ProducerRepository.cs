using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;

namespace ETickets.BLL.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }
    }
}
