namespace ViewsExample.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }

        public Gender PersonGender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
