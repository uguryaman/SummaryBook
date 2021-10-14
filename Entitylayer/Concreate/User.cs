using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]

        public string UserName { get; set; }
        [StringLength(100)]

        public string UserSurname { get; set; }
        [StringLength(250)]

        public string UserMail { get; set; }
        [StringLength(1)]

        public string UserRole { get; set; }
        [StringLength(500)]

        public string UserPassword { get; set; }
        [StringLength(500)]

        public string UserPicture { get; set; }


        public bool UserStatu { get; set; }
        public string AdminSalt { get; set; }

        public ICollection<Summary> summaries { get; set; }
    }
}
