using ServiceContracts;

namespace Services
{
  public class CitiesService : ICitiesService, IDisposable
  {
        private List<string> _cities;
        private List<string> _countries;

        private Guid _serviceInstanceID;
        public Guid ServiceInstanceID
        {

            get 
            { 
                return _serviceInstanceID;
            } 
        }



        public CitiesService()
        {
                _serviceInstanceID = Guid.NewGuid();
                
                _cities = new List<string>() { 
                  "London",
                  "Paris",
                  "New York",
                  "Tokyo",
                  "Rome"
                };

                _countries = new List<string>()
                {
                    "UK",
                    "France",
                    "USA",
                    "Japan",
                    "Italy"
                };  

        }

        public List<string> GetCities()
        {
          return _cities;
        }

        public List<string> GetCountries()
        {
              return _countries;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
