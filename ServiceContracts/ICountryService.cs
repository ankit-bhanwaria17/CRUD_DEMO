using System;
using System.Collections.Generic;
using Entites;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountryService
    {
        public CountryAddResponse AddCountry(CountryAddRequest? Request);

        public List<CountryAddResponse> GetAllCountries();
    }
}
