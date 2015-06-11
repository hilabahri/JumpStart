using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Restaurants.Domain.Options
{
    public class CountrySubdivisionsLocalFavoritesOptions
    {
        public string Country { get; set; }

        public CountrySubdivisionsLocalFavoritesOptions(string country)
        {
            this.Country = country;
        }
    }
}
