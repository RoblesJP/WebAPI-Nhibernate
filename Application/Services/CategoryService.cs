using Application.Models;
using Application.Services.Interfaces;
using Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            Category category = await _categoryRepository.Get(id);

            CategoryModel categoryModel = new CategoryModel { Id = category.Id, Name = category.Name };

            return categoryModel;
        }
    }
}
