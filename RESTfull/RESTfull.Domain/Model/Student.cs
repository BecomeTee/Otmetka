namespace RESTfull.Domain.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Group { get; set; } = String.Empty;

        //public bool Attend { get; set; }
        //Присутствие на занятии

        public ICollection<Attendance> StudentClass { get; set; }

    }
}