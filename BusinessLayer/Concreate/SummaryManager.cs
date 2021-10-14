using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class SummaryManager : ISummaryService
    {
        ISummaryDal _summaryDal;

        public SummaryManager(ISummaryDal summaryDal)
        {
            _summaryDal = summaryDal;
        }

        public Summary GetById(int id)
        {
            return _summaryDal.Get(a => a.BookId == id);
                }

        public List<Summary> GetList()
        {
            return _summaryDal.List();
        }

        public List<Summary> GetListBookSummary(int id)
        {
            return _summaryDal.List(x => x.BookId==id);
        }

        public List<Summary> GetListUserSummary(string p)
        {
            return _summaryDal.List(x => x.User.UserMail == p);
        }

        public void SummaryAdd(Summary summary)
        {
            _summaryDal.Insert(summary);
        }

        public void SummaryDelete(Summary summary)
        {
            _summaryDal.Delete(summary);
        }

        public void SummaryEdit(Summary summary)
        {
            _summaryDal.Update(summary);
        }
    }
}
