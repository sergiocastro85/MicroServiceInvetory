using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();

        Task<Category> GetCategoryById(int id);

        Task AddCategory(Category category);

        Task UpdateCategory (Category category);

        Task DeleteCategory(int id);
    }
}
