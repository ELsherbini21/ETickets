using AutoMapper;
using ETickets.BLL.Interfaces;
using ETickets.DAL.Models;
using ETickets.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETickets.PL.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MovieController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            var movieModel = await unitOfWork.MovieRepository.GetAllAsync();

            var movieMappedToVM =
                mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movieModel);

            return View(movieMappedToVM);
        }
    }
}
