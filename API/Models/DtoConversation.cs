using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class DtoConversation
    {
        [Key]
        public int ConversationID { get; set; }
        public string Message { get; set; }
        public int WhistleID { get; set; }
        public Sender Sender { get; set; }
        public System.DateTime Sent { get; set; }
        public System.DateTime Read { get; set; }
        public int FileID { get; set; }
    }
}