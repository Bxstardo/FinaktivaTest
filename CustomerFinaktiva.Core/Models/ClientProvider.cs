using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class ClientProvider
    {
        public int IdClientProvider { get; set; }
        public int? IdClient { get; set; }
        public int? IdProvider { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Provider IdProviderNavigation { get; set; }
    }
}
