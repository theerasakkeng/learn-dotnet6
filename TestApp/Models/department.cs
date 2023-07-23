using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class department
    {
        public department()
        {
            employees = new HashSet<employee>();
        }

        public int department_id { get; set; }
        public string department_name { get; set; } = null!;
        public int? location_id { get; set; }

        public virtual location? location { get; set; }
        public virtual ICollection<employee> employees { get; set; }
    }
}
