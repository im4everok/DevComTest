using BLL.Interfaces;
using BLL.Models;
using Dev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: PetController/Create
        public ActionResult Create(int ownerId)
        {
            PetModel petToGetOwnerId = new PetModel { Owner = new PersonDto { Id = ownerId } , Pet = new PetDto { Name = ""}};
            return View(petToGetOwnerId);
        }

        // POST: PetController/Create
        [HttpPost]
        public async Task<ActionResult> Create(PetModel petToGet, int ownerId)
        {
            try
            {
                var petFromModel = new PetDto { Name = petToGet.Pet.Name };
                await _petService.AddAsync(petFromModel, ownerId);
                return RedirectToAction("Details", "Person", new { ownerId });
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
