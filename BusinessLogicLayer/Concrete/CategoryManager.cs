using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categorydal;
        //IHeadingDAL _headingdal;
        
        public CategoryManager(ICategoryDAL categorydal)
        {
            _categorydal = categorydal;
        }
        //public CategoryManager(IHeadingDAL headingdal)
        //{
        //    _headingdal = headingdal;
        //}

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetById(int id)
        {
            
            return _categorydal.Get(x=>x.CategoryId==id);
        }

        public List<Category> GetList()
        {
            
            return _categorydal.List();

        }
        public int Filter()
        {
            return _categorydal.Get(x => x.CategoryName == "Series").CategoryId;

        }

        public string FilterByCategoryId(int categoryid)
        {
            return _categorydal.Get(x=>x.CategoryId == categoryid).CategoryName;
        }

        public int CategoryCountBySituation()
        {
            int truecategory= _categorydal.List(x=>x.CategoryStatus==true).Count();
            int falsecategory = _categorydal.List(x => x.CategoryStatus == false).Count();
            return (truecategory-falsecategory);
        }

        //public List<Heading> FilterList()
        //{
        //    var t = _categorydal.Get(x => x.CategoryName == "Series").CategoryId;
        //    return _headingdal.List(x=>x.CategoryId==t);
        //}
    }
}
