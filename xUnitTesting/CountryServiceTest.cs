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

        #region AddCountry
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
            CountryAddRequest request2 = new CountryAddRequest() { CountryName = "india" };

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

            List<CountryAddResponse> listOfCountries = _countryService.GetAllCountries();
         
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, listOfCountries);

        }

        #endregion

        #region GetAllContries

        [Fact]
        public void GetAllCountries_EmptyList()
        {
            List<CountryAddResponse> listOfCountries = _countryService.GetAllCountries();
            Assert.Empty(listOfCountries);
        }

        [Fact]
        public void GetAllCountries_AddCountries()
        {
            List<CountryAddRequest> requests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() {CountryName = "India" },
                new CountryAddRequest() {CountryName = "Japan" }
            };

            List<CountryAddResponse> expectedListOfCountries = new List<CountryAddResponse>();

            foreach (CountryAddRequest request in requests)
            {
                CountryAddResponse addedCountry = _countryService.AddCountry(request);
                expectedListOfCountries.Add(addedCountry);
            }

            List<CountryAddResponse> actualListOfCountires = _countryService.GetAllCountries();

            foreach (var expectedCountry in expectedListOfCountries)
            {
                Assert.Contains(expectedCountry, actualListOfCountires);
            }

        }

        #endregion
    }
}
