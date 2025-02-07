using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
       Task<IEnumerable<Product>> GetProducts();

       Task<Product> GetProductById(int id);

       Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
