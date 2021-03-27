using FelfelWarehouse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FelfelWarehouse
{
    [Route("api/batches")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly MyDBContext db;
        private readonly ILogger<BatchesController> _logger;

        public BatchesController(MyDBContext context, ILogger<BatchesController> logger)
        {
            db = context;
            _logger = logger;
        }
        // GET: api/<BatchesController>
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, db.Batches);
        }

        // GET api/<BatchesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(StatusCodes.Status200OK, db.Batches.Find(id));
        }

        // POST api/<BatchesController>
        [HttpPost]
        public IActionResult Post([FromBody] Batch value)
        {
            if (db.Products.Find(value.ProductId) == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Product not found."));

            if(value.Quantity <= 0)
                return StatusCode(StatusCodes.Status500InternalServerError, new ArgumentException("Quantity cannot be null or zero."));

            if (value.ExpirationDate <= DateTime.Now)
                return StatusCode(StatusCodes.Status500InternalServerError, new ArgumentException("Expiration Date cannot be null or in the past."));

            EntityEntry<Batch> batch = db.Batches.Add(value);
            db.SaveChanges();

            Movement movement = new Movement();
            movement.Amount = value.Quantity;
            movement.BatchId = batch.Entity.Id;
            movement.Reason = "First Load";
            movement.Timestamp = DateTime.Now;
            db.Movements.Add(movement);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, batch.Entity);
        }

        // PUT api/<BatchesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Batch value)
        {
            Batch batch = db.Batches.Find(id);
            if (batch == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Batch not found."));

            Movement movement = new Movement();
            movement.Amount = value.Quantity - batch.Quantity;
            movement.BatchId = id;
            movement.Reason = "Manual Update on Batch";
            movement.Timestamp = DateTime.Now;
            db.Movements.Add(movement);

            batch.ExpirationDate = value.ExpirationDate;
            batch.Quantity = value.Quantity;
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, batch);
        }

        // DELETE api/<BatchesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Batch batch = db.Batches.Find(id);
            if (batch == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Batch not found."));

            db.RemoveRange(db.Movements.Where(m => m.BatchId == id));
            db.Remove(batch);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("{id}/history")]
        public IActionResult History(int id)
        {
            Batch batch = db.Batches.Find(id);
            if(batch == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Batch not found."));

            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("batch", batch);
            dictionary.Add("product", db.Products.Find(batch.ProductId));
            dictionary.Add("movements", db.Movements.OrderBy(m => m.Timestamp).Where<Movement>(m => m.BatchId == batch.Id));

            return StatusCode(StatusCodes.Status200OK, dictionary);
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return StatusCode(
                StatusCodes.Status200OK,
                db.Batches.ToList().GroupBy(x => x.FreshnessStatus).ToDictionary(x => x.Key, x => x.ToList().Select(x => new { x.Id, db.Products.Find(x.ProductId).Name, x.Quantity, x.ExpirationDate }))
            );
        }

        [HttpGet("stock")]
        public IActionResult Stock(bool byBatch = false)
        {
            var groups = db.Batches.ToList().GroupBy(x => x.ProductId);

            if (byBatch)
                return StatusCode(
                    StatusCodes.Status200OK,
                    groups.ToDictionary(x => db.Products.Find(x.Key).Name, x => x.ToList().Select(x => new { x.Id, x.Quantity }))
                );
            else
                return StatusCode(
                    StatusCodes.Status200OK,
                    groups.ToDictionary(x => db.Products.Find(x.Key).Name, x => x.ToList().Sum(b => b.Quantity))
                );
            
        }
    }
}
