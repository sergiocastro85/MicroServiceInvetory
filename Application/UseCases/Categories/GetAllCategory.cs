using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class GetAllCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Execute()
        {
            return await _categoryRepository.GetAllCategory();
        }
    }
}
