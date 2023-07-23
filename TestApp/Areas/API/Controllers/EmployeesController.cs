using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;

namespace TestApp.Areas.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public object Data;
        private readonly Entities db_context;
        public EmployeesController(Entities entities)
        {
            this.db_context = entities;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = db_context.employees.ToList();
                Data = new
                {
                    status = "success",
                    data = employees
                };
            }
            catch
            {
                throw;
            }
            return Ok(Data);
        }
    }
}
