using AutoMapper;
using ETickets.BLL.Interfaces;
using ETickets.DAL.Models;
using ETickets.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ETickets.PL.Controllers
{
    public class CinemaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CinemaController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            var cinemaModel = await unitOfWork.CinemaRepository.GetAllAsync();

            var cinemaMappedVM =
                mapper.Map<IEnumerable<Cinema>, IEnumerable<CinemaViewModel>>(cinemaModel);

            return View(cinemaMappedVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaViewModel _cinemaViewModel)
        {
            if (_cinemaViewModel is null)
                return View(nameof(NotFound));

            if (ModelState.IsValid == true)
            {
                var mappedCinemaToModel = mapper.Map<CinemaViewModel, Cinema>(_cinemaViewModel);

                await unitOfWork.CinemaRepository.AddAsync(mappedCinemaToModel);

                unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            return View(_cinemaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return View(nameof(NotFound));

            var model = await unitOfWork.CinemaRepository.GetByIdAsync(id.Value);

            if (model is null)
                return View(nameof(NotFound));

            var mappedCinemaToVM = mapper.Map<Cinema, CinemaViewModel>(model);

            return View(mappedCinemaToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, CinemaViewModel _cinemaViewModel)
        {
            if (id != _cinemaViewModel.Id)
                return View(nameof(NotFound));

            if (ModelState.IsValid == true)
            {
                try
                {
                    var mappedCinemaToModel = mapper.Map<CinemaViewModel, Cinema>(_cinemaViewModel);

                    await unitOfWork.CinemaRepository.AddAsync(mappedCinemaToModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(nameof(Edit));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return View(nameof(NotFound));

            var model = await unitOfWork.CinemaRepository.GetByIdAsync(id.Value);

            if (model is null)
                return View(nameof(NotFound));

            var mappedCinemaToVM = mapper.Map<Cinema, CinemaViewModel>(model);

            return View(mappedCinemaToVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return View(nameof(NotFound));

            var model = await unitOfWork.CinemaRepository.GetByIdAsync(id.Value);

            if (model is null)
                return View(nameof(NotFound));

            var mappedModelToVM = mapper.Map<Cinema, CinemaViewModel>(model);

            return View(mappedModelToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CinemaViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedModel = mapper.Map<CinemaViewModel, Cinema>(viewModel);

                    await unitOfWork.CinemaRepository.AddAsync(mappedModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(nameof(NotFound));
        }


    }
}
