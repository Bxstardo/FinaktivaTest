using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class DocumentType
    {
        public int IdDocumentType { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
