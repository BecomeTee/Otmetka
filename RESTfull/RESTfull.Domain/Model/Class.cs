namespace RESTfull.Domain.Model
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public int Room {  get; set; }
        public string Teacher {  get; set; } = String.Empty;
        public ICollection<Attendance> StudentClass { get; set; }
    }
}
