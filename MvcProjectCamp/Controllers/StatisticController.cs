using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());
        // GET: Statistic
        public ActionResult Index()
        {
            //Number Of Categories
            var categorycount = cm.GetList().Count();
            ViewBag.categorycount = categorycount;

            //Number Of Headings Where Category Name == Series
            var t = cm.Filter();
            var headingbycategory =hm.GetHeading(t).Count();
            ViewBag.headingbycategory=headingbycategory;

            //Number Of Authors With "a" In Their Name
            var writerfilter = wm.GetWriters("a");
            ViewBag.writernuberwitha=writerfilter;

            //Category With The Most Headings
            var c=hm.GetMaxCatId();
            var f=cm.FilterByCategoryId(c);
            ViewBag.FilterByCategoryId=f;

            //Numerical Difference Between True and False Category
            var n = cm.CategoryCountBySituation();
            ViewBag.CategoryCountBySituation=n;

            return View();
        }
       
    }
}