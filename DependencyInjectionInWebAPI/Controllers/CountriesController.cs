using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using DependencyInjectionInWebAPI.Entities;

namespace DependencyInjectionInWebAPI.Controllers
{
    public class CountriesController : ApiController
    {
        private ICountryRepository _repository;

        public CountriesController(ICountryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Country> Get()
        {
            return _repository.GetAll();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_repository != null)
                {
                    _repository.Dispose();
                    _repository = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
