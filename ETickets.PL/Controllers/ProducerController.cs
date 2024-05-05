using AutoMapper;
using ETickets.BLL.Interfaces;
using ETickets.DAL.Models;
using ETickets.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Unicode;

namespace ETickets.PL.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProducerController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public new IActionResult NotFound()
        {
            return View();
        }

        #region Index
        public async Task<IActionResult> Index()
        {

            var producerModel = await unitOfWork.ProducerRepository.GetAllAsync();

            var mappedActorToVM =
               mapper.Map<IEnumerable<Producer>, IEnumerable<ProducerViewModel>>(producerModel);

            return View(mappedActorToVM);
        }

        #endregion

        #region Create
        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create(ProducerViewModel producerViewModel)
        {
            if (producerViewModel is null)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                var mappedProducerToView =
                     mapper.Map<ProducerViewModel, Producer>(producerViewModel);

                if (mappedProducerToView is not null)
                {
                    await unitOfWork.ProducerRepository.AddAsync(mappedProducerToView);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }

            }
            return View(producerViewModel);
        }
        #endregion

        #region Details 
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return View("NotFound");

            var producerModel = await unitOfWork.ProducerRepository.GetByIdAsync(id.Value);

            if (producerModel is null)
                return NotFound();

            var mappedProducerToVM = mapper.Map<Producer, ProducerViewModel>(producerModel);

            return View(mappedProducerToVM);

        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var producerModel = await unitOfWork.ProducerRepository.GetByIdAsync(id.Value);

            if (producerModel is null)
                return NotFound();

            var mappedProducerToVM = mapper.Map<Producer, ProducerViewModel>(producerModel);

            return View(mappedProducerToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, ProducerViewModel _producerViewModel)
        {
            if (id != _producerViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                try
                {
                    var mappedProducerToModel = mapper.Map<ProducerViewModel, Producer>(_producerViewModel);

                    await unitOfWork.ProducerRepository.UpdateAsync(mappedProducerToModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(_producerViewModel);
        }

        #endregion


        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var producerModel = await unitOfWork.ProducerRepository.GetByIdAsync(id.Value);

            if (producerModel is null)
                return NotFound();

            var mappedActorToVM = mapper.Map<Producer, ProducerViewModel>(producerModel);

            return View(mappedActorToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProducerViewModel _producerViewModel)
        {


            if (id != _producerViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                try
                {
                    var mappedProducerToModel = mapper.Map<ProducerViewModel, Producer>(_producerViewModel);

                    await unitOfWork.ProducerRepository.DeleteAsync(mappedProducerToModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(_producerViewModel);
        }

        #endregion
    }
}
