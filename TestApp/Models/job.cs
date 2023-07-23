using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class job
    {
        public job()
        {
            employees = new HashSet<employee>();
        }

        public int job_id { get; set; }
        public string job_title { get; set; } = null!;
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }

        public virtual ICollection<employee> employees { get; set; }
    }
}
