using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBoxRental.Entities;
using BlueBoxRental.Entities.Extended;
using BlueBoxRental.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlueBoxRental.Web.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;

        public RentalsController(IConfiguration config)
        {
            _config = config;
            _apiUrl = _config.GetSection("BlueBoxRentalConfig").GetValue<string>("ApiUrl");
        }
        // GET: Rentals
        public async Task<ActionResult> Index()
        {
            List<Rental> listRentals = await HttpClientGenerics.GetList<Rental>(_apiUrl, "/api/Rental/");
            return View(listRentals);
        }

        // GET: Rentals/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Rental rental = await HttpClientGenerics.Get<Rental>(_apiUrl, "/api/Rental/", id.ToString());
            return View(rental);
        }

        // GET: Rentals/Create
        public async Task<ActionResult> Create()
        {
            RentalViewModel rental = await HttpClientGenerics.Get<RentalViewModel>(_apiUrl, "/api/Rental/New");
            return View(rental);
        }

        [HttpPost]
        public ActionResult Create(RentalViewModel rentalViewModel)
        {
            return View();
        }

        // POST: Rentals/Create
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

        // GET: Rentals/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rentals/Edit/5
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

        // GET: Rentals/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rentals/Delete/5
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