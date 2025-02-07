using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products
{
    public class GetProductById
    {
        private readonly IProductRepository _productRepository;

        public GetProductById(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Execute(int id)
        {
            return await _productRepository.GetProductById(id);
        }
    }
}
