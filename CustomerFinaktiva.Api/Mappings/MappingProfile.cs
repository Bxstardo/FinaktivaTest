using AutoMapper;
using CustomerFinaktiva.Api.Models;
using CustomerFinaktiva.Core.Models;

namespace CustomerFinaktiva.Api.Mappings
{
    /// <summary>
    /// Mappings models
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            GeneralMappings();
        }

        /// <summary>
        /// Generals the mappings.
        /// </summary>
        public void GeneralMappings()
        {
            CreateMap<Client, ClientModel>();
            CreateMap<ClientModel, Client>();
            CreateMap<Provider, ProviderModel>();
            CreateMap<Provider, ProviderModel>();
            CreateMap<DocumentType, DocumentTypeModel>();
            CreateMap<ClientProviderModel, ClientProvider>();
        }
    }
}
