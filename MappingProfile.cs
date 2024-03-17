using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace ExperimentNetApi6
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                    opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
        }
    }
}
