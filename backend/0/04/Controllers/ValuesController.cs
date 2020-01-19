using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        //NEW
        public ValuesController(DataContext context)
        {
            //this.context = context;
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //public IActionResult GetValues()
        public async Task<IActionResult> GetValues()
        {
            // throw new Exception("Test Exception");
            // return new string[] { "value1", "value3" };
            //var values = _context.Values.ToList();
            var values = await _context.Values.ToListAsync();
            return Ok(values); // 200(OK) response returned to client
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //public IActionResult GetValue(int id)
        public async Task<IActionResult> GetValue(int id)
        {
            //return "value";
            var value = _context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
