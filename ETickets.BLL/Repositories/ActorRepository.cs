using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.BLL.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }



    }
}
