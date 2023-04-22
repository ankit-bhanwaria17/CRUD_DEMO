using System;
using System.Collections.Generic;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountryService
    {
        public CountryAddResponse AddCountry(CountryAddRequest? Request);
    }
}
