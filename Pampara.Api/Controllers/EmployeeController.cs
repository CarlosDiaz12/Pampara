using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pampara.BusinessLogic.Service;
using Pampara.DataAccess.Model;
using Microsoft.Net.Http.Headers;
using System.Net.Http;

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

        [HttpGet, Route("{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize)
        {
            var employees = _service.GetEmployeeList(page, pageSize);
            //var response = Response;
            //var request = Request;
            //Response.Headers.Add("Authorization", "Bearer Token here");
            //var cookie = new CookieHeaderValue("token", "dhbchdbfhsbfajjfhsdbfsajs");
            //var cookieOptions = new CookieOptions()
            //{
            //    HttpOnly = true,
            //    Expires = DateTimeOffset.Now.AddDays(1),
            //    Domain = Request.Host.Host,
            //    // SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
            //    Path = "/",
            //    Secure = true
            //};

            //HttpContext.Response.Cookies.Append("fgdgfd", "dfdsdsd", cookieOptions);
            //// Response.Cookies.Append(cookie.Name.Value, cookie.Value.Value, cookieOptions);
            //HttpResponseMessage res = new HttpResponseMessage();
  
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
