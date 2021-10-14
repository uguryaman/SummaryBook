using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetList();
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageEdit(Message message);
        Message GetById(int id);
    }
}
