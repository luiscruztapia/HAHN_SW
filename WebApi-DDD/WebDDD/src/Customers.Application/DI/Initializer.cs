using Customers.Domain.Interfaces;
using Customers.Domain.Models;
using Customers.Infra.Context;
using Customers.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Application.DI {
    public class Initializer {
        public static void Configure (IServiceCollection services, string conection) 
        {
            services.AddDbContext<AppDbContext> (options => options.UseSqlServer (conection));

            services.AddScoped (typeof (IRepository<Customer>), typeof (CustomerRepository));
            services.AddScoped (typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped (typeof (CustomerService));
            services.AddScoped (typeof (IUnitOfWork), typeof (UnitOfWork));
        }
    }
}