using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;

using System.Web.Http;
using VidlyOrg.Dtos;
using VidlyOrg.Models;
using AutoMapper;

namespace VidlyOrg.Controllers.Api
{
    //Api Customer Controllers
    //mora da se skine autorizacija radi testiranja API-a u postmanu
    //[Authorize] 
    public class CustomersController : ApiController
    {
        //DBContext
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/customers
        
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        //GET /api/customers/1
        
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return (Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers/
        [HttpPost]
        public CustomerDto CreateCustomer (CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
            
        }

        //PUT /api/customers/1
        [HttpPut]
        public void  UpdateCustomer(int id, CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name = customerDto.Name;
            //customerInDb.DrivingLicence = customerDto.DrivingLicence;
            //customerInDb.DrivinLicenceReleaseDate = customerDto.DrivinLicenceReleaseDate;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerInDb.Birhdate = customerDto.Birhdate;

            _context.SaveChanges();


        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
