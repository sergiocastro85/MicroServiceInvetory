using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class GetCategoryById
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryById(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Exucte(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }
    }
}
