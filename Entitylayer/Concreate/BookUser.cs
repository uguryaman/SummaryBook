using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class BookUser
    {
        [Key]
        public int BookUserId { get; set; }
        [StringLength(50)]

        public string BookUserName { get; set; }
        public string BookUserUser { get; set; }

        [StringLength(50)]

        public string BookUserCategory { get; set; }
        [StringLength(100)]

        public string BookUserWriter { get; set; }

        [StringLength(50)]

        public string BookUserYear { get; set; }
       
        public string BookUserSummary { get; set; }
        public DateTime BookUserAddTime { get; set; }

    }
}
