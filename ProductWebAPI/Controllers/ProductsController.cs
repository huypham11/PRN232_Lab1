using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using BusinessObjects.ViewModel;
using DataAccessObjects;
using Services;
using MyStoreDbContext = DataAccessObjects.MyStoreDbContext;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _context;
        private readonly IMapper _mapper;
        public ProductsController(IProductService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            List<Product> listP = _context.GetProducts();
            if (listP.Count == 0)
            {
                return NotFound(new { message = "No products found" });
            }
            else
            {
                return Ok(new
                {
                    message = "Get " +listP.Count +" product successful",
                    data = listP
                });
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _context.GetProductById(id);
            if (product.ProductName == String.Empty)
            {
                return NotFound(new {message = "Can not found product with id = " + id});
            }
            return Ok(new
            {
                message = "Get product successful",
                data = product
            });
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductViewModel productViewModel)
        {
            // Optionally, you can add ProductId to ProductViewModel or use 'id' directly
            var existingProduct = _context.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Update failed, not found product with id = {id}" });
            }

            // Map the incoming view model to the existing product entity
            // This assumes ProductViewModel does not have ProductId, so we set it manually
            var updatedProduct = _mapper.Map<Product>(productViewModel);
            updatedProduct.ProductId = id;

            try
            {
                _context.UpdateProduct(updatedProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.GetProductById(id) == null)
                {
                    return NotFound(new { message = $"Update failed, not found product with id = {id}" });
                }
                else
                {
                    return BadRequest();
                }
            }

            return Ok(new { message = "Update successful" });
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductViewModel product)
        {
          

            var p = _mapper.Map<Product>(product);
            try
            {
                _context.SaveProduct(p);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "An error occurred while saving the product", error = e.InnerException });
            }

            return CreatedAtAction(
                "GetProduct",
                new { id = p.ProductId },
                new { message = "Create successful", data = p }
            );
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.DeleteProduct(product);

            return Ok(new { message = "Delete successful" });
        }


    }
}
