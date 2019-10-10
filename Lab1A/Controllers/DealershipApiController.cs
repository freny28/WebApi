// I, Freny Patel, student number 000744054, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab1A.Models;
using Lab1A.Data;

namespace Lab1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipApiController : ControllerBase
    {
        private DealershipMgr _contextDmgr;

        public DealershipApiController()
        {
            _contextDmgr = new DealershipMgr();
        }

        // GET: api/DealershipApi
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contextDmgr.Get());
        }

        // GET: api/DealershipApi/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_contextDmgr.Get(id));
        }

        // POST: api/DealershipApi
        [HttpPost]
        public IActionResult Post([FromBody] Dealership dealership)
        {
            _contextDmgr.Post(dealership);

            return Ok();
        }

        // PUT: api/DealershipApi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dealership dealership)
        {
            _contextDmgr.Put(id, dealership);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contextDmgr.Delete(id);

            return Ok();
        }
    }
}
