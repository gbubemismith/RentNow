using AutoMapper;
using RentNow.Dtos;
using RentNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace RentNow.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customer = _context.Customers
                          .Include(c => c.MembershipType)
                          .ToList()
                          .Select(Mapper.Map<Customer , CustomerDto>);

            return Ok(customer);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map < Customer , CustomerDto >(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto , Customer>(customerDto);

            _context.Customers.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine("ERROR: " + ex);
            }
           

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id) , customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id , CustomerDto customerDto)
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

            Mapper.Map(customerDto, customerInDb);

            

            _context.SaveChanges(); 
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
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
