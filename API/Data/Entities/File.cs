using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class File
    {
        public int FileID { get; set; }
        public string Base64 { get; set; }
        public string Extension { get; set; }
        public int WhistleID { get; set; }
    }
}
