using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetById(int id)
        {

            return _userDal.Get(x => x.UserId == id);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(x => x.UserMail == mail);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public bool IsLoginSuccess(string userMail, string userPassword)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            using (Context db = new Context())
            {
                var user = db.Users.FirstOrDefault(u => u.UserMail == userMail);
                if (user != null)
                {
                    if (user.UserPassword == crypto.Compute(userPassword, user.AdminSalt.ToString()))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        public void UserAdd(User admin)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encryedPassword = crypto.Compute(admin.UserPassword);
            var amdin = new User();
            if (admin.UserId == 0)
            {
                amdin.UserName = admin.UserName;
                amdin.UserPassword = encryedPassword;
                amdin.AdminSalt = crypto.Salt.ToString();
                amdin.UserSurname = admin.UserSurname;
                amdin.UserMail = admin.UserMail;
                amdin.UserPicture = admin.UserPicture;
                amdin.UserStatu = admin.UserStatu;
                amdin.UserStatu = true;
            }


            amdin.UserStatu = true;
            _userDal.Insert(amdin);
        }

        public void UserDelete(User user)
        {
            _userDal.Delete(user);
        }

        public void UserEdit(User user)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encryedPassword = crypto.Compute(user.UserPassword);

            var admin = new User();


            admin.UserId = user.UserId;
            admin.UserMail = user.UserMail;
            admin.UserPassword = encryedPassword;
            admin.AdminSalt = crypto.Salt.ToString();
            admin.summaries = user.summaries;
            admin.UserName = user.UserName;
            admin.UserSurname = user.UserSurname;
            admin.UserPicture = user.UserPicture;
            admin.UserStatu = user.UserStatu;



            _userDal.Update(admin);
        }
    }
}
