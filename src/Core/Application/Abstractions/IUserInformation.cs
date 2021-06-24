using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Abstractions
{
    public interface IUserInformation
    {
        public Dictionary<Guid, string> GetUsers();
    }
}
