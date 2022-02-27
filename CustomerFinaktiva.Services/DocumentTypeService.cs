using CustomerFinaktiva.Core.Models;
using CustomerFinaktiva.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerFinaktiva.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly FinaktivaTestContext _db;
        public DocumentTypeService(FinaktivaTestContext db)
        {
            _db = db;
        }

        async public Task<IEnumerable<DocumentType>> GetAll() => await _db.DocumentTypes.Where(d => d.IsActive == true).ToListAsync();
     
    }
}
