using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Enums;

namespace Task.Domain.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Value { get; set; }
        public InvoiceState State { get; set; } 
    }
}
