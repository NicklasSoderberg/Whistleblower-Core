﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class DtoSubject
    {
        [Key]
        public int SubjectID { get; set; }
        public string Text { get; set; }
        public System.DateTime? Created { get; set; }
        public System.DateTime? Modified { get; set; }
        public System.DateTime? Deleted { get; set; }
        public bool Active { get; set; }
    }
}
