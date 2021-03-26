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
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext db;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(MyDBContext context, ILogger<ProductsController> logger)
        {
            db = context;
            _logger = logger;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Set<Product>();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            db.Products.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            Product product = db.Products.Find(id);
            product.Name = value.Name;
            db.SaveChanges();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
        }
    }
}
