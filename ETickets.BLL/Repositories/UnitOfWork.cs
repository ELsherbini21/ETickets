using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETickets.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            AppDbContext _dbContext,
            IActorRepository _actorRepository,
            //IActorsMoviesRepository _actorsMoviesRepository,
            ICinemaRepository _cinemaRepository,
            IMovieRepository _movieRepository,
            IProducerRepository _producerRepository
            )
        {
            dbContext = _dbContext;

            ActorRepository = _actorRepository;

            //ActorsMoviesRepository = _actorsMoviesRepository;

            CinemaRepository = _cinemaRepository;

            MovieRepository = _movieRepository;

            ProducerRepository = _producerRepository;
        }

        private readonly AppDbContext dbContext;

        public IActorRepository ActorRepository { get; set; }

        public IActorsMoviesRepository ActorsMoviesRepository { get; set; }

        public ICinemaRepository CinemaRepository { get; set; }

        public IMovieRepository MovieRepository { get; set; }

        public IProducerRepository ProducerRepository { get; set; }

        public int Complete() => dbContext.SaveChanges();

        public void Dispose() => dbContext.Dispose();

        #region Method Injection 
        public void SetActor(IActorRepository _actorRepository)
                => ActorRepository = _actorRepository;

        public void SetActorsMovies(IActorsMoviesRepository _actorsMoviesRepository)
                => ActorsMoviesRepository = _actorsMoviesRepository;

        public void SetCinema(ICinemaRepository _cinemaRepository)
                => CinemaRepository = _cinemaRepository;

        public void SetMovie(IMovieRepository _movieRepository)
                => MovieRepository = _movieRepository;

        public void SetProducer(IProducerRepository _producerRepository)
                => ProducerRepository = _producerRepository;


        #endregion
    }
}
