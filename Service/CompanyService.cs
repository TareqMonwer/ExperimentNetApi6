using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly INLoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, INLoggerManager loggerManager, IMapper mapper)
        {
            _repository = repository;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public CompanyDto GetCompany(Guid compnayId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(compnayId, trackChanges);
            if (company is null)
            {
                throw new CompanyNotFoundException(compnayId);
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public CompanyDto CreateCompany(CompanyCreateDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();

            var companyResult = _mapper.Map<CompanyDto>(companyEntity);
            return companyResult;
        }
    }
}
