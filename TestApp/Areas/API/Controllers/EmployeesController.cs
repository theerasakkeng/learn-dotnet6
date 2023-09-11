using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;

namespace TestApp.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public IActionResult GetEmployeeList()
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

        [HttpGet]
        public IActionResult GetEmployeeById([FromQuery] int id)
        {
            try
            {
                var employee = db_context.employees.Where(o => o.employee_id == id).FirstOrDefault();
                Data = new
                {
                    status = "success",
                    data = employee
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
