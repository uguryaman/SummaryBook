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
    public class BookUserManager : IBookUserService
    {
        IBookUserDal _bookUserDal;

        public BookUserManager(IBookUserDal bookUserDal)
        {
            _bookUserDal = bookUserDal;
        }

        public void BookAdd(BookUser book)
        {
            _bookUserDal.Insert(book);
        }

        public void BookDelete(BookUser book)
        {
            _bookUserDal.Delete(book);
        }

        public void BookEdit(BookUser book)
        {
            _bookUserDal.Update(book);
        }

        public BookUser GetById(int id)
        {
            return _bookUserDal.Get(x => x.BookUserId == id);
        }

        public List<BookUser> GetList()
        {
            return _bookUserDal.List();
        }
    }
}
