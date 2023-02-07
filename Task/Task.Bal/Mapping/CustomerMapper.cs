using AutoMapper;
using Task.Task.Bal.Dto;
using Task.Task.Dal.Models;

namespace Task.Task.Bal.Mapping
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
