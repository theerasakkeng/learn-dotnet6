using System;
using System.Collections.Generic;

namespace TestApp.Models
{
    public partial class region
    {
        public region()
        {
            countries = new HashSet<country>();
        }

        public int region_id { get; set; }
        public string? region_name { get; set; }

        public virtual ICollection<country> countries { get; set; }
    }
}
