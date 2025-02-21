using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class AddCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Execute(Category category)
        {
            await _categoryRepository.AddCategory(category);
        }

    }
}
