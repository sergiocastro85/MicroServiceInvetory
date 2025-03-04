using Application.UseCases.DTOs;
using Application.UseCases.Products;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public ProductController(GetAllProducts getAllProducts, GetProductById getProductById,
                                    AddProduct addProduct, UpdateProduct updateProduct, DeleteProduct deleteProduct,
                                    IMapper mapper)
        {
            _getAllProducts = getAllProducts;
            _getProductById = getProductById;
            _addProduct = addProduct;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _getAllProducts.Execute();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ProductDto>> GetProduct(int id) 
        {
            var product = await _getProductById.Execute(id);
            if (product==null)
            {
                return NotFound();
            }

            return  _mapper.Map<ProductDto>(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {

            await _addProduct.Execute(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.IdProduct }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.IdProduct)
            {
                return BadRequest();
            }

            try
            {
                await _updateProduct.Execute(product);
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
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _getProductById.Execute(id);
            if (product == null)
            {
                return NotFound();
            }

           await _deleteProduct.Execute(id);
            return NoContent();
        }

    }




}
