﻿using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace ExperimentNetApi6
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Company, CompanyDto>()
            //    .ForCtorParam("FullAddress",
            //        opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));

            // For supporting XML Formats
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));
            
            CreateMap<CompanyCreateDto, Company>();

            CreateMap<Employee, EmployeeDto>();
            
            CreateMap<EmployeeCreateDto,  Employee>();
        }
    }
}
