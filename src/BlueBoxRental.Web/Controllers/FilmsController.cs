using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBoxRental.Entities;
using BlueBoxRental.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlueBoxRental.Web.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        public FilmsController(IConfiguration configuration)
        {
            _config = configuration;
            _apiUrl = _config.GetSection("BlueBoxRentalConfig").GetValue<string>("ApiUrl");
        }

        // GET: Films
        public async Task<ActionResult> Index()
        {
            List<Film> filmsList = await HttpClientGenerics.GetList<Film>(_apiUrl,"/api/Film/");
            return View(filmsList);
        }

        // GET: Films/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Film film = await HttpClientGenerics.Get<Film>(_apiUrl, "/api/Film/", id.ToString());
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Films/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}