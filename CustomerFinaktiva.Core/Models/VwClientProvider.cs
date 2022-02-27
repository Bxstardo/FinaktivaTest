using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class VwClientProvider
    {
        public int IdProvider { get; set; }
        public string Name { get; set; }
        public int? IdClient { get; set; }
        public int IdClientProvider { get; set; }
    }
}
