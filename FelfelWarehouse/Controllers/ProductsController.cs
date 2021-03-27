using FelfelWarehouse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;

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
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, db.Products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(StatusCodes.Status200OK, db.Products.Find(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            EntityEntry<Product> product = db.Products.Add(value);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, product.Entity);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Product not found."));

            product.Name = value.Name;
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return StatusCode(StatusCodes.Status404NotFound, new NullReferenceException("Product not found."));

            db.Products.Remove(product);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
