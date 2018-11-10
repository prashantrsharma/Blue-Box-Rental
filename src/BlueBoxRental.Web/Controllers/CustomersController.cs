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
    public class CustomersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        public CustomersController(IConfiguration config)
        {
            _config = config;
            _apiUrl = _config.GetSection("BlueBoxRentalConfig").GetValue<string>("ApiUrl");
        }
        // GET: Customers
        public  async  Task<ActionResult> Index()
        {
            List<Customer> listCustomers = await HttpClientGenerics.GetList<Customer>(_apiUrl,"/api/Customer/");
            return View(listCustomers);
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Customer customer = await HttpClientGenerics.Get<Customer>(_apiUrl, "/api/Customer/", id.ToString());
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
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

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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