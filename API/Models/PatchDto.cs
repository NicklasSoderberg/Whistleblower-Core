using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PatchDto
    {
        public string PropertyName { get; set; }
        public int PropertyValue { get; set; }
    }
}
