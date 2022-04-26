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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerdal;
        
        
        public WriterManager(IWriterDAL writerdal)
        {
            _writerdal = writerdal;
        }

        public int GetWriters(string a)
        {
            var values = from x in _writerdal.List() where x.WriterName.Contains(a) select x;
            return values.Count();
        }
    }
}
