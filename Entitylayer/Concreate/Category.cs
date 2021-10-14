using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]

        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
