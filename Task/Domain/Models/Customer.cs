using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Invoice>? Invoices { get; set; }
    }
}
