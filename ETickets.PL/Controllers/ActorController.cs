using AutoMapper;
using ETickets.BLL.Interfaces;
using ETickets.DAL.Models;
using ETickets.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.PL.Controllers
{
    public class ActorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public ActorController(
            IUnitOfWork _unitOfWork,
            IMapper _mapper
            )
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
            var actorsModel = await unitOfWork.ActorRepository.GetAllAsync();

            var mappedActorToVM =
               mapper.Map<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(actorsModel);

            return View(mappedActorToVM);
        }

        #endregion

        #region Create
        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel actorViewModel)
        {
            if (actorViewModel is null)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                var mappedActorToView =
                     mapper.Map<ActorViewModel, Actor>(actorViewModel);

                if (mappedActorToView is not null)
                {
                    await unitOfWork.ActorRepository.AddAsync(mappedActorToView);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }

            }
            return View(actorViewModel);
        }
        #endregion

        #region Details 
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return View("NotFound");

            var actorModel = await unitOfWork.ActorRepository.GetByIdAsync(id.Value);

            if (actorModel is null)
                return NotFound();

            var mappedActorToVM = mapper.Map<Actor, ActorViewModel>(actorModel);

            return View(mappedActorToVM);

        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var actorModel = await unitOfWork.ActorRepository.GetByIdAsync(id.Value);

            if (actorModel is null)
                return NotFound();

            var mappedActorToVM = mapper.Map<Actor, ActorViewModel>(actorModel);

            return View(mappedActorToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, ActorViewModel _actorViewModel)
        {
            if (id != _actorViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                try
                {
                    var mappedActorToModel = mapper.Map<ActorViewModel, Actor>(_actorViewModel);

                    await unitOfWork.ActorRepository.UpdateAsync(mappedActorToModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(_actorViewModel);
        }

        #endregion


        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var actorModel = await unitOfWork.ActorRepository.GetByIdAsync(id.Value);

            if (actorModel is null)
                return NotFound();

            var mappedActorToVM = mapper.Map<Actor, ActorViewModel>(actorModel);

            return View(mappedActorToVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ActorViewModel _actorViewModel)
        {


            if (id != _actorViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid == true)
            {
                try
                {
                    var mappedActorToModel = mapper.Map<ActorViewModel, Actor>(_actorViewModel);

                    await unitOfWork.ActorRepository.DeleteAsync(mappedActorToModel);

                    unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(_actorViewModel);
        }

        #endregion




    }
}
