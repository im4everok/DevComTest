using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Controllers
{
    public class PersonPetController : Controller
    {
        // GET: PersonPetController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonPetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonPetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonPetController/Create
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

        // GET: PersonPetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonPetController/Edit/5
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

        // GET: PersonPetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonPetController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
