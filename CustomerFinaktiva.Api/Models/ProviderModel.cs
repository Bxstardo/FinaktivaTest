using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Api.Models
{
    /// <summary>
    /// ProviderModel
    /// </summary>
    public class ProviderModel
    {
        /// <summary>
        /// Gets or sets the identifier provider.
        /// </summary>
        /// <value>
        /// The identifier provider.
        /// </value>
        public int IdProvider { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
