using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class Summary
    {
        [Key]
        public int SummaryId { get; set; }
        public string BookSummary { get; set; }
        public DateTime SummaryDate { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
