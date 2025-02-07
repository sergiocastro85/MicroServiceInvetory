using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Products
{
    public class GetAllProducts
    {
        private readonly IProductRepository _productRepository;

        public GetAllProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Execute()
        {
            return await _productRepository.GetProducts();
        }
    }
}
