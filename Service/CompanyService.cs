using Contracts;
using Entities;
using Service.Contracts;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly INLoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repository, INLoggerManager loggerManager)
        {
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                return _repository.Company.GetAllCompanies(trackChanges);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(
                    $"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}"
                );
                throw;
            }
        }
    }
}
