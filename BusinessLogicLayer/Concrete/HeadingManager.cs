using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class HeadingManager:IHeadingService
    {
        IHeadingDAL _headingdal;


        public HeadingManager(IHeadingDAL headingdal)
        {
            _headingdal = headingdal;
        }

        

        public List<Heading> GetHeading(int id)
        {
            return _headingdal.List(x=>x.CategoryId==id);
        }

        public int GetMaxCatId()
        {
            
            var maxcount= _headingdal.List().GroupBy(x=>x.CategoryId).Select(z=> new {a=z.Count()}).OrderByDescending(t=>t.a).FirstOrDefault();
            var categoryid = _headingdal.Get(x => x.HeadingId == maxcount.a).CategoryId;
            int b=Convert.ToInt32(categoryid);
            return b;
        }

        //public HeadingManager(IHeadingDAL headingdal)
        //{
        //    _headingdal = headingdal;
        //}


    }
}
