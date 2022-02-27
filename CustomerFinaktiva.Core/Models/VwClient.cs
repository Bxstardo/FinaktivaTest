using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class VwClient
    {
        public int IdClient { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string DocumentNumber { get; set; }
        public int? IdDocumentType { get; set; }
        public string BusinessName { get; set; }
        public decimal? SalesLastYear { get; set; }
        public bool? IsActive { get; set; }
        public string Providers { get; set; }
    }
}
