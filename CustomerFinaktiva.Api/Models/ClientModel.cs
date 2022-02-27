using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Api.Models
{
    /// <summary>
    /// ClientModel
    /// </summary>
    public class ClientModel
    {
        /// <summary>
        /// Gets or sets the identifier client.
        /// </summary>
        /// <value>
        /// The identifier client.
        /// </value>
        public int IdClient { get; set; }
        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        public string Names { get; set; }
        /// <summary>
        /// Gets or sets the surnames.
        /// </summary>
        /// <value>
        /// The surnames.
        /// </value>
        public string Surnames { get; set; }
        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the identifier document.
        /// </summary>
        /// <value>
        /// The type of the identifier document.
        /// </value>
        public int? IdDocumentType { get; set; }
        /// <summary>
        /// Gets or sets the name of the business.
        /// </summary>
        /// <value>
        /// The name of the business.
        /// </value>
        public string BusinessName { get; set; }
        /// <summary>
        /// Gets or sets the sales last year.
        /// </summary>
        /// <value>
        /// The sales last year.
        /// </value>
        public decimal? SalesLastYear { get; set; }
    }
}
