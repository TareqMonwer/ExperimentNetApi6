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

        public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges)
        {
            if (companyIds is null)
            {
                throw new IdParametersBadRequestException();
            }

            var companyEntities = _repository.Company.GetByIds(companyIds, trackChanges);
            if (companyIds.Count() != companyEntities.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var companiesResponse = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            return companiesResponse;
        }

        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyCreateDto> companyCollection)
        {
            if (companyCollection is null)
            {
                throw new CompanyCollectionBadRequest();
            }

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);

            foreach ( var companyEntity in companyEntities)
            {
                _repository.Company.CreateCompany(companyEntity);
            }

            _repository.Save();

            var companyCollectionResponse = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionResponse.Select(companyEntity => companyEntity.Id));

            return (companies:  companyCollectionResponse, ids);
        }
    }
}
