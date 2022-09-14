using System.Collections.Generic;
using System.Linq;
using Customers.Domain.Models;
using Customers.Infra.Context;

namespace Customers.Infra.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {}

        public override Customer GetById(int id)
        {
            var query = _context.Set<Customer>().Where(e => e.Id == id);

            if(query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Customer> GetAll()
        {
            var query = _context.Set<Customer>();

            return query.Any() ? query.ToList() : new List<Customer>();
        }
    }
}