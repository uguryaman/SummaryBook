using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ISummaryService
    {
        List<Summary> GetList();
        List<Summary> GetListBookSummary(int id);
        List<Summary> GetListUserSummary(string p);
        void SummaryAdd(Summary summary);
        void SummaryDelete(Summary summary);
        void SummaryEdit(Summary summary);
        Summary GetById(int id);
    }
}
