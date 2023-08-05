using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class location
    {
        public int location_id { get; set; }
        public string? street_address { get; set; }
        public string? postal_code { get; set; }
        public string city { get; set; } = null!;
        public string? state_province { get; set; }
        public string country_id { get; set; } = null!;
    }
}
