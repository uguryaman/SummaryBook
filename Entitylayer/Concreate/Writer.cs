using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]

        public string WriterName { get; set; }
        [StringLength(50)]

        public string WriterSurname { get; set; }
        [StringLength(500)]

        public string WriterPicture { get; set; }
        public bool WriterStatu { get; set; }


        public ICollection<Book> Books { get; set; }
    }
}
