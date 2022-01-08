using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private IPetService _petService;
        public PersonController(IPersonService personService, IPetService petService)
        {
            _personService = personService;
            _petService = petService;
        }
        // GET: PersonController
        public ActionResult AllUsers(string searchString, int? page)
        {
            int pageSize = 3;
            int pageNum = page ?? 1;
            if (string.IsNullOrEmpty(searchString))
            {
                IPagedList<PersonDto> pAllPaged = _personService.GetAll().ToList().ToPagedList(pageNum, pageSize);
                return View(pAllPaged);
            }
            IPagedList<PersonDto> pAllPagedFiltered = _personService.GetPeopleByName(searchString).ToPagedList();
            return View(pAllPagedFiltered);
        }

        // GET: PersonController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int ownerId)
        {
            return View(await _personService.GetByIdAsync(ownerId));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        public async Task<ActionResult> Create(PersonDto model)
        {
            await _personService.AddAsync(model);
            return RedirectToAction("AllUsers");
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
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

        // GET: PersonController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _personService.GetByIdAsync(id));
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, PersonDto person)
        {
            try
            {
                await _personService.DeleteByIdAsync(id);
                return RedirectToAction("AllUsers");
            }
            catch
            {
                return View();
            }
        }
    }
}
