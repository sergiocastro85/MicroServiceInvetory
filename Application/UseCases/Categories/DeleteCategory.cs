using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class DeleteCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Execute(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}
