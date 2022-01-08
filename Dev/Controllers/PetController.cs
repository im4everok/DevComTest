using BLL.Interfaces;
using BLL.Models;
using Dev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Controllers
{
    public class PetController : Controller
    {
        private IPetService _petService;
        private IPersonService _personService;

        public PetController(IPetService petService, IPersonService personService)
        {
            _petService = petService;
            _personService = personService;
        }
        // GET: PetController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PetController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Delete/5&5
        public async Task<ActionResult> Delete(int petId, int ownerId)
        {
            var owner = await _personService.GetByIdAsync(ownerId);
            var pet = await _petService.GetByIdAsync(petId);
            PetModel model = new PetModel { Pet = pet, Owner = owner};
            return View(model);
        }

        // POST: PetController/Delete/5&5
        [HttpPost]
        public async Task<ActionResult> Delete(int petId, int ownerId, PetDto model)
        {
            try
            {
                await _petService.DeleteByIdAsync(petId);
                return RedirectToAction("Details", "Person", new { ownerId = ownerId });
            }
            catch
            {
                return View();
            }
        }
    }
}
