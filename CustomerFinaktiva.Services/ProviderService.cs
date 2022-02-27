using CustomerFinaktiva.Core.Models;
using CustomerFinaktiva.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerFinaktiva.Api.Models;

namespace CustomerFinaktiva.Services
{
    public class ProviderService : IProviderService
    {
        private readonly FinaktivaTestContext _db;
        public ProviderService(FinaktivaTestContext db)
        {
            _db = db;
        }

        async public Task<IEnumerable<Provider>> GetAll() => await  _db.Providers.Where(p => p.IsActive == true).ToListAsync();

        async public Task<IEnumerable<VwClientProvider>> GetAllByClient(int idClient) => await _db.VwClientProviders.Where(p => p.IdClient == idClient).ToListAsync();
    }
}
