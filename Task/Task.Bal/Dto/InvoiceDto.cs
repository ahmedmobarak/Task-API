using Task.Task.Dal.Enums;
using Task.Task.Dal.Models;

namespace Task.Task.Bal.Dto
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Value { get; set; }
        public InvoiceState State { get; set; }
        public Customer? Customer { get; set; }
    }
}
