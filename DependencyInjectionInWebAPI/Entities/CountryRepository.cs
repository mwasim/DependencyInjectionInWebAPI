using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionInWebAPI.Entities;

namespace DependencyInjectionInWebAPI.Entities
{
    public class CountryRepository : IDisposable, ICountryRepository
    {
        private CountriesDbEntities _db;

        public CountryRepository(CountriesDbEntities db)
        {
            _db = db;
        }

        public IEnumerable<Country> GetAll()
        {
            return _db.Countries.OrderBy(x => x.Name).ToList();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
