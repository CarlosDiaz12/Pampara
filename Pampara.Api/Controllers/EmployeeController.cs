using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pampara.BusinessLogic.Service;
using Pampara.DataAccess.Model;
namespace Pampara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _service.GetEmployeeList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var result = _service.SaveEmployee(employee);
            return CreatedAtAction("Get", new { Id = result.Id }, result);
        }

        //[HttpGet("{Id}")]
        //public IActionResult Get(int Id)
        //{

        //}
    }
}
