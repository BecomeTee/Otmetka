namespace RESTfull.Domain.Model
{
    public class Attendance
    {
        //test
        public Guid Id { get; set; }

        public Guid Id_class { get; set; }
        public Guid Id_student { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }

        public bool Attend { get; set; }
        //Присутствие на занятии
    }
}
