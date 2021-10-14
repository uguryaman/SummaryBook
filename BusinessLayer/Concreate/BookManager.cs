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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void BookAdd(Book book)
        {
            _bookDal.Insert(book);
        }

        public void BookDelete(Book book)
        {
            _bookDal.Delete(book);
        }

        public void BookEdit(Book book)
        {
            _bookDal.Update(book);
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(x=>x.BookId==id);
        }

        public List<Book> GetList()
        {
            return _bookDal.List();
        }

        public List<Book> GetListSearchBook(string p)
        {
            return _bookDal.List(x=>x.BookName.Contains(p));
        }
    }
}
