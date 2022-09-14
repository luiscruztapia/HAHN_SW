using System.ComponentModel.DataAnnotations;

namespace Customers.Web.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email{ get; set; }
    }
}