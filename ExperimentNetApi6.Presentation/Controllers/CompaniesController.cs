using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ExperimentNetApi6.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            throw new Exception("Something terrrible happened. Lets check!");
            var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
        }
    }
}
