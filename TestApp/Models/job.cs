using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class job
    {
        public int job_id { get; set; }
        public string job_title { get; set; } = null!;
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }
    }
}
