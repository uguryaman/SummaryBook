using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        void UserAdd(User user);
        void UserDelete(User user);
        void UserEdit(User user);
        User GetById(int id);
        User GetByMail(string mail);
        bool IsLoginSuccess(string userMail, string userPassword);
    }
}
