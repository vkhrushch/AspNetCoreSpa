using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList
{
    public class AutomobilesListVm
    {
        public IList<AutomobileLookupDto> Automobiles { get; set; }
    }
}
