using System.Collections.Generic;
using System.Linq;
using Customers.Domain.Interfaces;
using Customers.Domain.Models;
using Customers.Infra.Repositories;
using Customers.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly IRepository<Customer> _customerRepository;

        public CustomersController(CustomerService customerService,
            IRepository<Customer> customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }

         [HttpGet]
         public IEnumerable<CustomerDTO> GetCustomers()
        {
             var customers = _customerRepository.GetAll();
            
            var resultado = customers.Select(c => new CustomerDTO{ Id = c.Id, Nome = c.Nome, Email= c.Email });

            return resultado;
         }


         [HttpGet("{id}")]
         public  ActionResult<Customer> GetCustomer(int id)
         {
             var contato = _customerRepository.GetById(id);
             if (contato == null)
             {
                 return NotFound(new { message = $"Customer de id={id} não encontrado" });
             }
             return contato;
         }
    }
}