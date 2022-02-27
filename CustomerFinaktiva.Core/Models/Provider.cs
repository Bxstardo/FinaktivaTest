using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class Provider
    {
        public Provider()
        {
            ClientProviders = new HashSet<ClientProvider>();
        }

        public int IdProvider { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ClientProvider> ClientProviders { get; set; }
    }
}
