﻿using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid employeeId, Guid companyId, bool trackChanges);
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateDto employee, bool trackChanges);
        void DeleteEmployeeForCompany(Guid companyId, Guid employeeId, bool trackChanges);
    }
}
