using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Api.Models
{
    /// <summary>
    /// ClientProvidersModel
    /// </summary>
    public class ClientProvidersModel
    {
        public int? idClientProvider { get; set; }
        /// <summary>
        /// Gets or sets the identifier client.
        /// </summary>
        /// <value>
        /// The identifier client.
        /// </value>
        public int? IdClient { get; set; }
        /// <summary>
        /// Gets or sets the identifier provider.
        /// </summary>
        /// <value>
        /// The identifier provider.
        /// </value>
        public int? IdProvider { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }
    }
}
