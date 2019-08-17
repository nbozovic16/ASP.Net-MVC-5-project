using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VidlyOrg.Models;
using VidlyOrg.ViewModel;

namespace VidlyOrg.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        //DBContext
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        

        //Add new Car
        public ViewResult New()
        {
            var carBodies = _context.CarBodies.ToList();

            var viewModel = new CarFormViewModel
            {
                CarBodies = carBodies
            };

            return View("CarForm", viewModel);
        }

        //Save data from form to DB
        [HttpPost]
        public ActionResult Save(Car car)
        {
            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.SingleOrDefault(c => c.Id == car.Id);
                carInDb.Brand = car.Brand;
                carInDb.Model = car.Model;
                carInDb.CarBodyId = car.CarBodyId;
                carInDb.Fuel = car.Fuel;
                carInDb.PricePerDay = car.PricePerDay;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

        //PUT: Cars/Edit/1
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CarFormViewModel
            {
                Car = car,
                CarBodies = _context.CarBodies.ToList()
            };

            return View("CarForm", viewModel);
        }

        // GET: Cars/Index
        [AllowAnonymous]
        public ViewResult Index()
        {
            var cars = _context.Cars.Include(c => c.CarBody).ToList();

            return View(cars);
        }

        //GET: Cars/Details/1
        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(c => c.CarBody).SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        //DELETE: /Cars/delete/1
        public ActionResult DeleteConfirmed(int id)
        {
            

            Car car = _context.Cars.Include(c => c.CarBody).SingleOrDefault(c => c.Id == id);

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}