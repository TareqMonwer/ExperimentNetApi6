using Contracts;
using Entities;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
        {
            return FindByCondition(employee => employee.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(employee => employee.Name).ToList();
        }

        public Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) 
        {
            IQueryable<Employee> query = FindByCondition(
                e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges);
            return query.SingleOrDefault();
        }
    }
}
