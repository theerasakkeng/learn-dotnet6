using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class country
    {
        public string country_id { get; set; } = null!;
        public string? country_name { get; set; }
        public int region_id { get; set; }
    }
}
