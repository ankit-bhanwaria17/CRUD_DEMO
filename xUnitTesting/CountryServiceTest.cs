using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;


namespace xUnitTesting
{
    public class CountryServiceTest
    {
        public readonly ICountryService _countryService;
        public CountryServiceTest()
        {
            _countryService = new CountryService(); 
        }

        [Fact]
        public void AddCountry_ArgumentNull()
        {
            CountryAddRequest request = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_ArgumentInvalid()
        {
            CountryAddRequest request = new CountryAddRequest() { CountryName = null };
            Assert.Throws<ArgumentException>(() =>
            {
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_DuplicateCountry()
        {
            CountryAddRequest request1 = new CountryAddRequest() { CountryName = "India" };
            CountryAddRequest request2 = new CountryAddRequest() { CountryName = "India" };

            Assert.Throws<ArgumentException>(() =>
            {
                _countryService.AddCountry(request1);
                _countryService.AddCountry(request2);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            CountryAddRequest request = new CountryAddRequest() { CountryName = "India" };

            var response = _countryService.AddCountry(request);

            Assert.True(response.CountryId != Guid.Empty);
            
        }
    }
}
