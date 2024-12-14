namespace RoutingAssignment.Model
{
    public class CountriesClass
    {
        public Dictionary<int, string> GetCountries() { 
            
            Dictionary <int , string> Countries = new Dictionary <int , string> ();
            Countries.Add(1, "India");
            Countries.Add(2, "USA");                
            Countries.Add(3, "China");
            Countries.Add(4, "Russia");
            Countries.Add(5, "Italy");
            Countries.Add(6, "Sweden");
            Countries.Add(7, "Dubai");
            Countries.Add(8, "Saudi Arabia");
            Countries.Add(9, "Canada");
            Countries.Add(10, "Brazil");
            Countries.Add(11, "Srilanka");
            Countries.Add(12, "Israel");


            return Countries;
        }
    }
}
