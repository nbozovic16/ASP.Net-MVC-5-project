using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using VidlyOrg.Models;
using VidlyOrg.ViewModel;
using VidlyOrg.Dtos;
using System.Web.Http;
using AutoMapper;
using System.Net;
using System.Web.Mvc;

namespace VidlyOrg.Controllers
{
    [System.Web.Mvc.Authorize]
    public class CustomersController : Controller
    {
        //DBContext
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Customers/Add
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        
        //add new from .ajax
        public ActionResult New1()
        {

            return View("CustomerFormAjax");
        }

        [System.Web.Http.HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;

        }




        //Save data from form to DB
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //validation
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DrivingLicence = customer.DrivingLicence;
                customerInDb.DrivinLicenceReleaseDate = customer.DrivinLicenceReleaseDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Birhdate = customer.Birhdate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //GET: Customers/Index
        
        [System.Web.Http.AllowAnonymous]
        public ViewResult Index()
        {
            if(User.IsInRole("CanManageCar"))
            {
                return View("Index");
            }
            else
            {
                return View("IndexReadOnly");
            }
            
        }

        //GET: Customers/Details/1
        public ActionResult Details (int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //PUT: Customers/Edit/1
        public ActionResult Edit (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}