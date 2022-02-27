using CustomerFinaktiva.Api.Models;
using CustomerFinaktiva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Core.Services
{
    public interface IProviderService
    {
        public Task<IEnumerable<Provider>> GetAll();
        public Task<IEnumerable<VwClientProvider>> GetAllByClient(int idClient);

    }
}
