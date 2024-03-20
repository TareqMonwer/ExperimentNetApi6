using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyCreateDto company);
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);
    }
}
