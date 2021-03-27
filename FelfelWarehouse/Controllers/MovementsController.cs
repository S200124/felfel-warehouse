using FelfelWarehouse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;

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
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, db.Movements);
        }

        // GET api/<MovementsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(StatusCodes.Status200OK, db.Movements.Find(id));
        }

        // POST api/<MovementsController>
        [HttpPost]
        public IActionResult Post([FromBody] Movement value)
        {
            if(value.Amount == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, new ArgumentException("Amount cannot be null or zero."));

            Batch batch = db.Batches.Find(value.BatchId);
                
            if (batch == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Batch not found."));

            batch.Quantity += value.Amount;

            EntityEntry<Movement> movement = db.Movements.Add(value);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, movement.Entity);
        }

        // PUT api/<MovementsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movement value)
        {
            Movement movement = db.Movements.Find(id);
            if (movement == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Movement not found."));

            Batch batch = db.Batches.Find(movement.BatchId);

            batch.Quantity -= movement.Amount;
            batch.Quantity += value.Amount;

            movement.Amount = value.Amount;
            movement.Reason = value.Reason;
            movement.Timestamp = value.Timestamp;

            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, movement);
        }

        // DELETE api/<MovementsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Movement movement = db.Movements.Find(id);
            if (movement == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Movement not found."));

            db.Movements.Remove(movement);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
