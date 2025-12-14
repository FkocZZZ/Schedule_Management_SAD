using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.DAL;

namespace ScheduleManagement.BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _dal;

        public CategoryBLL()
        {
            _dal = new CategoryDAL();
        }
        public List<CategoryModel> GetAllCategories()
        {
            var dalCategories = _dal.GetAll(); // Category từ DAL
            return dalCategories.Select(c => new CategoryModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }

        public void AddCategory(CategoryModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("Tên loại công việc không được để trống.");

            Category c = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            _dal.Add(c);
        }

        public void UpdateCategory(CategoryModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("Tên loại công việc không được để trống.");

            Category c = new Category
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description
            };

            _dal.Update(c);
        }

        public void DeleteCategory(int id)
        {
            _dal.Delete(id);
        }

    }
}
