namespace Students
{
    public class AttendDto
    {
        public Guid Id { get; set; }

        public Guid Id_class { get; set; }
        public Guid Id_student { get; set; }
        public StudentDto Student { get; set; }
        public ClassDto Class { get; set; }
        public bool Attend { get; set; }
    }
}
