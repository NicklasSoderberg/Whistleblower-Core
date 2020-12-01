using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Lawyer
    {
        public Guid LawyerId { get; set; }
        public string LawyerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
