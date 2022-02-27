using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Core.Enums
{
    public class CreateGenericResult
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public GenericResult Result { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGenericResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="id">The identifier.</param>
        public CreateGenericResult(GenericResult result, int id)
        {
            Result = result;
            Id = id;
        }
    }
}
