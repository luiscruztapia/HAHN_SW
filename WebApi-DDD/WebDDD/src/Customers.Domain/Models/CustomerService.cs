using Customers.Domain.Interfaces;

namespace Customers.Domain.Models
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _contatoRepository;

        public CustomerService(IRepository<Customer> contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Create(int id, string nome, string email)
        {
            var contato = _contatoRepository.GetById(id);

            if(contato == null)
            {
                contato = new Customer(nome, email);
                _contatoRepository.Save(contato);
            }
            else
                contato.Update(nome, email);
        }
    }
}