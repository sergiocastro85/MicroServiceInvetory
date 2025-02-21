using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class UpdateCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        public async Task Execute(Category category)
        {
            await _categoryRepository.UpdateCategory(category);
        }
    }
}
