using System.ComponentModel.DataAnnotations.Schema;
using Task.Task.Dal.Enums;

namespace Task.Task.Dal.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal Value { get; set; }
        
        public Customer? Customer { get; set; }
        public InvoiceState State { get; set; }
    }
}
