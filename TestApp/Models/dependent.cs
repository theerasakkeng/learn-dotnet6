using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class dependent
    {
        public int dependent_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string relationship { get; set; } = null!;
        public int employee_id { get; set; }
    }
}
