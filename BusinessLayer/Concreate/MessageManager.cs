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
   public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
           return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetList()
        {
            return _messageDal.List();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageEdit(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
