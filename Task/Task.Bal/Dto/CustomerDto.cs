namespace Task.Task.Bal.Dto
{
    public class CustomerDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int InvoicesCount { get; set; }
    }

}
