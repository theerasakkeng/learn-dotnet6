using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class department
    {
        public int department_id { get; set; }
        public string department_name { get; set; } = null!;
        public int? location_id { get; set; }
    }
}
