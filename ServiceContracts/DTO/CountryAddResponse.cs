using System;
using System.Collections.Generic;
using Entites;

namespace ServiceContracts.DTO
{
    public class CountryAddResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(CountryAddResponse)) return false;

            CountryAddResponse countryObj = (CountryAddResponse)obj;

            return CountryId == countryObj.CountryId && CountryName == countryObj.CountryName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class CountryExtensions
    {
        public static CountryAddResponse ToCountryAddResponse(this Country country)
        {
            return new CountryAddResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
            };
        }
    }
}
