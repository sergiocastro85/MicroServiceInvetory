using Application.UseCases.Products;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GetAllProducts _getAllProducts;
        private readonly GetProductById _getProductById;
        private readonly AddProduct _addProduct;
        private readonly UpdateProduct _updateProduct;
        private readonly DeleteProduct _deleteProduct;

        public ProductController(GetAllProducts getAllProducts, GetProductById getProductById,
                                    AddProduct addProduct, UpdateProduct updateProduct, DeleteProduct deleteProduct)
        {
            _getAllProducts = getAllProducts;
            _getProductById = getProductById;
            _addProduct = addProduct;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _getAllProducts.Execute();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) 
        {
            var product = _getProductById.Execute(id);
            if (product==null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product)
        {

            _addProduct.Execute(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult PutUpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _updateProduct.Execute(product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the product.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _getProductById.Execute(id);
            if (product == null)
            {
                return NotFound();
            }

            _deleteProduct.Execute(id);
            return NoContent();
        }

    }




}
