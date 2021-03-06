using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);
        void CategoryDelete(Category category);
        void CategoryEdit(Category category);
        Category GetById(int id);
    }
}
