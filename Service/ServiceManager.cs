using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, INLoggerManager nLoggerManager)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, nLoggerManager));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, nLoggerManager));
        }

        public ICompanyService CompanyService => _companyService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
