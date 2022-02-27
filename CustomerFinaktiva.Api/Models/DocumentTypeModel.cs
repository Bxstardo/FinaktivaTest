using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Api.Models
{
    /// <summary>
    /// DocumentTypeModel
    /// </summary>
    public class DocumentTypeModel
    {
        /// <summary>
        /// Gets or sets the type of the identifier document.
        /// </summary>
        /// <value>
        /// The type of the identifier document.
        /// </value>
        public int IdDocumentType { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
