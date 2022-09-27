using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NiksDoughnuts.Web.Models;
using NiksDoughnuts.Web.Services;

namespace NiksDoughnuts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeesService _es;

        public EmployeesController(EmployeesService es)
        {
            _es = es;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            try
            {
                List<Employee> employees = _es.Get();
                return Ok(employees);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            try
            {
                Employee employee = _es.GetById(id);
                return Ok(employee);
            }
            catch(Exception e)
            {
               return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employeeData)
        {
            try
            {
                Employee newEmployee = _es.Create(employeeData);
                return Ok(newEmployee);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Employee> EditEmployee(int id, [FromBody] Employee employeeData)
        {
            try 
            {
                Employee update = _es.Edit(employeeData);
                return Ok(update);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<Employee> DeleteEmployee(int id)
        {
            try
            {
                Employee deleted = _es.Deleted(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
