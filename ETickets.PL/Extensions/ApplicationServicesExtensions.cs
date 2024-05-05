using ETickets.BLL.Interfaces;
using ETickets.BLL.Repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace ETickets.PL.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IActorRepository, ActorRepository>();

            services.AddScoped<IProducerRepository, ProducerRepository>();

            services.AddScoped<ICinemaRepository, CinemaRepository>();

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
