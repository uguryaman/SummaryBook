using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(50)]

        public string BookName { get; set; }
       
      
        [StringLength(500)]

        public string BookPicture { get; set; }

        public bool BookStatu { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Summary> summaries { get; set; }


    }
}
