using CustomerFinaktiva.Api.Models;
using CustomerFinaktiva.Core.Models;
using CustomerFinaktiva.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerFinaktiva.Core.Enums;

namespace CustomerFinaktiva.Services
{
    public class ClientService : IClientService
    {
        private readonly FinaktivaTestContext _db;
        public ClientService(FinaktivaTestContext db)
        {
            _db = db;
        }

        async public Task<CreateGenericResult> Add(Client newClient)
        {
            // IdDocumentType 2 = C.E
            if (newClient.IdDocumentType == 2)
            {
                return new CreateGenericResult(GenericResult.ErrorValidation, 0);
            }
            newClient.IsActive = true;
            await _db.Clients.AddAsync(newClient);
            await _db.SaveChangesAsync();
            return new CreateGenericResult(GenericResult.Successful, newClient.IdClient);
        }

        async public Task<GenericResult> AssignProvider(ClientProvider clientProvider)
        {
            var checkAsignProvider = await _db.ClientProviders.Where(cp => cp.IdClient == clientProvider.IdClient && cp.IdProvider == clientProvider.IdProvider).SingleOrDefaultAsync();
            if (checkAsignProvider == null)
            {
                await _db.ClientProviders.AddAsync(clientProvider);
                await _db.SaveChangesAsync();
                return GenericResult.Successful;
            }
            else
            {
                return GenericResult.AlreadyExists;
            }
        }

        async public Task<GenericResult> AssignProviders(List<ClientProvidersModel> clientProvidersModel)
        {
            var clientProviderAdd = clientProvidersModel
                .Where(cp => cp.Action == "Add")
                .Select(cp => new ClientProvider {
                    IdClient = cp.IdClient,
                    IdProvider = cp.IdProvider
                });                        
            var clientProviderRemove = clientProvidersModel
                .Where(cp => cp.Action == "Remove")
                .Select(cp => new ClientProvider
                {
                    IdClientProvider =  Convert.ToInt32(cp.idClientProvider),
                });;
            await _db.ClientProviders.AddRangeAsync(clientProviderAdd);
            _db.ClientProviders.RemoveRange(clientProviderRemove);
            await _db.SaveChangesAsync();
            return GenericResult.Successful;
        }

        async public Task<GenericResult> Delete(int idClient)
        {
            var client = await _db.Clients.FindAsync(idClient);
            if (client != null)
            {
                try
                {
                    var clientProviders = await _db.ClientProviders.Where(c => c.IdClient == idClient).ToListAsync();
                    _db.ClientProviders.RemoveRange(clientProviders);
                    _db.Clients.Remove(client);
                    await _db.SaveChangesAsync();
                    return GenericResult.Successful;
                }
                catch (Exception)
                {
                    _db.Entry(client).Reload();
                    client.IsActive = false;
                    await _db.SaveChangesAsync();
                    return GenericResult.Successful;
                }
            }
            else
            {
                return GenericResult.NotFound;
            }
        }

        async public Task<IEnumerable<VwClient>> GetAll() => await _db.VwClients.Where(c => c.IsActive == true).ToListAsync();

        async public Task<VwClient> GetById(int idClient) => await _db.VwClients.SingleOrDefaultAsync(c => c.IdClient == idClient);
     
        async public Task<GenericResult> Update(Client newClient, int idClient)
        {
            // IdDocumentType 2 = C.E
            if (newClient.IdDocumentType == 2)
            {
                return GenericResult.ErrorValidation;
            }
            var oldClient = _db.Clients.Find(idClient);
            if (oldClient != null)
            {
                oldClient.Names = newClient.Names;
                oldClient.Surnames = newClient.Surnames;
                oldClient.DocumentNumber = newClient.DocumentNumber;
                oldClient.IdDocumentType = newClient.IdDocumentType;
                oldClient.BusinessName = newClient.BusinessName;
                oldClient.SalesLastYear = newClient.SalesLastYear;
                await _db.SaveChangesAsync();
                return GenericResult.Successful;
            }
            else
            {
                return GenericResult.NotFound;
            }
        }
    }
}
