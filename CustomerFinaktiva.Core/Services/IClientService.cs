using CustomerFinaktiva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerFinaktiva.Api.Models;
using CustomerFinaktiva.Core.Enums;

namespace CustomerFinaktiva.Core.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<VwClient>> GetAll();
      
        public Task<VwClient> GetById(int idClient);
      
        public Task<CreateGenericResult> Add(Client newclient);
      
        public Task<GenericResult> Update(Client newClient, int idClient);
      
        public Task<GenericResult> Delete(int idClient);

        public Task<GenericResult> AssignProvider(ClientProvider clientProvider);

        public Task<GenericResult> AssignProviders(List<ClientProvidersModel> clientProvidersModel);
    }
}
