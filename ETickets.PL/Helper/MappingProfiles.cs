using AutoMapper;
using ETickets.DAL.Models;
using ETickets.PL.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ETickets.PL.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Actor, ActorViewModel>().ReverseMap();

            CreateMap<Producer, ProducerViewModel>().ReverseMap();

            CreateMap<Cinema, CinemaViewModel>().ReverseMap();

            CreateMap<Movie, MovieViewModel>().ReverseMap();
        }

    }
}
