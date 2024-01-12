using RESTfull.Domain.Model;

namespace RESTfull.API.DTO
{
    public class AttendDto
    {
        public Guid Id_class { get; set; }
        public Guid Id_student { get; set; }
        public bool Attend { get; set; }
    }
}
