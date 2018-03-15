using System.Collections.Generic;
using static CoreAPIWeb.Models.Common;

namespace CoreAPIWeb.Models
{
    public interface ICommonRepository
        {
            List<Country> GetAllCountries();
        }
}
