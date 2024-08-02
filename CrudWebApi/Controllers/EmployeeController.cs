using CrudWebApi.Database;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmplyoyeeDbContext EmpployeeDbContext;

        public EmployeeController(EmplyoyeeDbContext exmployeeDbContext)
        {
            this.EmpployeeDbContext = exmployeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var Employees = await EmpployeeDbContext.Employees.ToListAsync();
            return Ok(Employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp)
        {
            emp.Id = new Guid();

            await EmpployeeDbContext.Employees.AddAsync(emp);
            await EmpployeeDbContext.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee emp)
        {
            var employee = await EmpployeeDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);

            if (employee != null)
            {
                employee.Name = emp.Name;
                employee.MobileNo = emp.MobileNo;
                employee.EmailID = emp.EmailID;
                await EmpployeeDbContext.SaveChangesAsync();

                return Ok(emp);
            }
            else
            {
                return NotFound("Employee not found");
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await EmpployeeDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);

            if (employee != null)
            {
                EmpployeeDbContext.Employees.Remove(employee);
                await EmpployeeDbContext.SaveChangesAsync();

                return Ok(employee);
            }
            else
            {
                return NotFound("Employee not found");
            }

        }
    }
}
