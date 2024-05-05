using ETickets.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IActorRepository ActorRepository {  get; set; }

        IActorsMoviesRepository ActorsMoviesRepository { get; set; }

        ICinemaRepository CinemaRepository { get; set; }

        IMovieRepository MovieRepository { get; set; }

        IProducerRepository ProducerRepository { get; set; }

        int Complete();

        public void SetActor(IActorRepository _actorRepository);

        public void SetActorsMovies(IActorsMoviesRepository _actorsMoviesRepository);

        public void SetCinema(ICinemaRepository _cinemaRepository);

        public void SetMovie(IMovieRepository _movieRepository);

        public void SetProducer(IProducerRepository _producerRepository);
    }
}
