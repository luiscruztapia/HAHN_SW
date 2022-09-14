using System.Collections.Generic;
using System.Linq;
using Customers.Domain.Interfaces;
using Customers.Domain.Models;
using Customers.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerService _contatoService;
        private readonly IRepository<Customer> _contatoRepository;

        public CustomersController(CustomerService contatoService,
            IRepository<Customer> contatoRepository)
        {
            _contatoService = contatoService;
            _contatoRepository = contatoRepository;
        }

         [HttpGet]
         public IEnumerable<CustomerDTO> GetCustomers()
         {
             var contatos = _contatoRepository.GetAll();
            
            var resultado = contatos.Select(c => new CustomerDTO{ Id = c.Id, Nome = c.Nome, Email= c.Email });

            return resultado;
         }


         [HttpGet("{id}")]
         public  ActionResult<Customer> GetCustomer(int id)
         {
             var contato =  _contatoRepository.GetById(id);
             if (contato == null)
             {
                 return NotFound(new { message = $"Customer de id={id} não encontrado" });
             }
             return contato;
         }
    }
}