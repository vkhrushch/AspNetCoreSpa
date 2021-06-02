using System;

namespace AspNetCoreSpa.Web.Seed
{
    public interface IIdentitySeedData
    {
        void Seed(IServiceProvider serviceProvider);
    }
}