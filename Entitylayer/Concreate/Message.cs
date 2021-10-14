using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitylayer.Concreate
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(100)]

        public string SenderMail { get; set; }
        [StringLength(100)]

        public string ReceiverMail { get; set; }
        [StringLength(250)]

        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
