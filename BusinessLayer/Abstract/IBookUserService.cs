using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IBookUserService
    {
        List<BookUser> GetList();
        void BookAdd(BookUser book);
        void BookDelete(BookUser book);
        void BookEdit(BookUser book);
        BookUser GetById(int id);
    }
}
