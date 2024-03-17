using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ExperimentNetApi6.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }

        [HttpGet("{employeeId:guid}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid employeeId)
        {
            var employee = _service.EmployeeService.GetEmployee(employeeId, companyId, trackChanges: false);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeCreateDto companyCreateDto)
        {
            if (companyCreateDto == null)
            {
                return BadRequest("CompanyCreateDto cannot be null");
            }

            var employee = _service.EmployeeService.CreateEmployeeForCompany(companyId, companyCreateDto, trackChanges: false);
            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employee.Id }, employee);
        }
    }
}
