using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products
{
    public class AddProduct
    {
        private readonly IProductRepository _productRepository;

        public AddProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute(Product product)
        {
            await _productRepository.AddProduct(product);
        }
    }
}
