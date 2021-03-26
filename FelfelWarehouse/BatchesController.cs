using FelfelWarehouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<Batch> Get()
        {
            return db.Set<Batch>();
        }

        // GET api/<BatchesController>/5
        [HttpGet("{id}")]
        public Batch Get(int id)
        {
            return db.Batches.Find(id);
        }

        // POST api/<BatchesController>
        [HttpPost]
        public void Post([FromBody] Batch value)
        {
            EntityEntry<Batch> batch = db.Batches.Add(value);
            db.SaveChanges();

            Movement movement = new Movement();
            movement.Amount = value.Quantity;
            movement.BatchId = batch.Entity.Id;
            movement.Reason = "First Load";
            movement.Timestamp = DateTime.Now;
            db.Movements.Add(movement);
            db.SaveChanges();
        }

        // PUT api/<BatchesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Batch value)
        {
            Batch batch = db.Batches.Find(id);

            Movement movement = new Movement();
            movement.Amount = value.Quantity - batch.Quantity;
            movement.BatchId = id;
            movement.Reason = "Manual Update on Batch";
            movement.Timestamp = DateTime.Now;
            db.Movements.Add(movement);

            batch.ExpirationDate = value.ExpirationDate;
            batch.ProductId = value.ProductId;
            batch.Quantity = value.Quantity;
            db.SaveChanges();
        }

        // DELETE api/<BatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.RemoveRange(db.Movements.Where(m => m.BatchId == id));
            db.Remove(db.Batches.Find(id));
            db.SaveChanges();
        }
    }
}
