using AutoMapper;
using Task.Task.Bal.Dto;
using Task.Task.Dal.Models;

namespace Task.Task.Bal.Mapping
{
    public class InvoiceMapper : Profile
    {
        public InvoiceMapper()
        {
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}
