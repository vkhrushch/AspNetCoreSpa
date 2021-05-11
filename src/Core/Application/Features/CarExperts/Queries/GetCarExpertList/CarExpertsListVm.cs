using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertList
{
    public class CarExpertsListVm
    {
        public IList<CarExpertLookupDto> CarExperts { get; set; }
    }
}
