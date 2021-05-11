using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientList
{
    public class ClientsListVm
    {
        public IList<ClientLookupDto> Clients { get; set; }
    }
}
