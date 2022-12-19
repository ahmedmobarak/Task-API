using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task.Task.Dal.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Invoice>? Invoices { get; set; }
    }
}
