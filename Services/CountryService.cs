using ServiceContracts;
using ServiceContracts.DTO;
using Entites;

namespace Services
{
    public class CountryService : ICountryService
    {
        private List<Country> _countries;
        public CountryService()
        {
            _countries = new List<Country>();
        }

        public CountryAddResponse AddCountry(CountryAddRequest? Request)
        {
            try
            {

                if (Request == null)
                {
                    throw new ArgumentNullException(nameof(Request));
                }
                if (string.IsNullOrEmpty(Request.CountryName))
                {
                    throw new ArgumentException(nameof(Request.CountryName));
                }

                Country country = Request.ToCountry();
                
                if (_countries.Where(c => c.CountryName.Equals(country.CountryName, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                {
                    throw new ArgumentException("CountryName already exist");
                }



                country.CountryId = Guid.NewGuid();
                _countries.Add(country);
                return country.ToCountryAddResponse();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CountryAddResponse> GetAllCountries()
        {
            List<CountryAddResponse> allCountries = new List<CountryAddResponse>();
            if (_countries.Count() == 0)
            {
                return allCountries;
            }

            foreach (var item in _countries)
            {
                allCountries.Add(item.ToCountryAddResponse());
            }

            return allCountries;
        }
    }
}