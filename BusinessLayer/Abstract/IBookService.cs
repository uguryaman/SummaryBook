using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IBookService
    {
        List<Book> GetList();
        List<Book> GetListSearchBook(string p);
        void BookAdd(Book book);
        void BookDelete(Book book);
        void BookEdit(Book book);
        Book GetById(int id);
    }
}
