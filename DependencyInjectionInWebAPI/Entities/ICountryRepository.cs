using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInWebAPI.Entities
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();

        void Dispose();
    }
}
