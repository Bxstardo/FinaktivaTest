using CustomerFinaktiva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Core.Services
{
    public interface IDocumentTypeService
    {
        public Task<IEnumerable<DocumentType>> GetAll();
    }
}
