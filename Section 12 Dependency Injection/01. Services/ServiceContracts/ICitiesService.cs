using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICitiesService
    {
        Guid ServiceInstanceID { get; }
        List<string> GetCountries();

        List<string> GetCities();
    }
}
