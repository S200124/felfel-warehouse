using FelfelWarehouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FelfelWarehouse
{
    [Route("api/movements")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly MyDBContext db;
        private readonly ILogger<MovementsController> _logger;

        public MovementsController(MyDBContext context, ILogger<MovementsController> logger)
        {
            db = context;
            _logger = logger;
        }
        // GET: api/<MovementsController>
        [HttpGet]
        public IEnumerable<Movement> Get()
        {
            return db.Set<Movement>();
        }

        // GET api/<MovementsController>/5
        [HttpGet("{id}")]
        public Movement Get(int id)
        {
            return db.Movements.Find(id);
        }

        // POST api/<MovementsController>
        [HttpPost]
        public void Post([FromBody] Movement value)
        {
            db.Movements.Add(value);
            db.SaveChanges();
        }

        // PUT api/<MovementsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movement value)
        {
            Movement movement = db.Movements.Find(id);
            movement.Amount = value.Amount;
            movement.BatchId = value.BatchId;
            movement.Reason = value.Reason;
            movement.Timestamp = value.Timestamp;
            db.SaveChanges();
        }

        // DELETE api/<MovementsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Movements.Remove(db.Movements.Find(id));
            db.SaveChanges();
        }
    }
}
