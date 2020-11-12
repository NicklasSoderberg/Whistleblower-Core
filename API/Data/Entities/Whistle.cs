using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Whistle
    {
        public int WhistleID { get; set; }
        public Guid? LawyerID { get; set; }
        public Guid? UserID { get; set; }
        public string AboutInfo { get; set; }
        public string WhenInfo { get; set; }
        public string WhereInfo { get; set; }
        public string DescriptionInfo { get; set; }
        public string OtherEmployeeInfo { get; set; }
        public string CurrentStatus { get; set; }
        public System.DateTime? Created { get; set; }
        public System.DateTime? Modified { get; set; }
        public System.DateTime? Deleted { get; set; }
        public bool Active { get; set; }
        public Guid? RemovedAdminID { get; set; }
    }
}
