using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface InterfaceAttend
    {
        ICollection<Attendance> GetAttends();
        Attendance GetAttend(Guid id);
        ICollection<Attendance> GetAttendsByStudentId(Guid id);
        
        bool CreateAttend(Attendance Attend);
        bool UpdateAttend(Attendance Attend);
        bool DeleteAttend(Attendance Attend);
        bool AttendExist(Guid id);
        bool Save();

        //ICollection<Attendance> GetAttendsByNameClass(string name);
        //Student GetStudentById(Guid id);
        //void CreateStudent(Student student);
        //void UpdateStudent(Student student);
        //void DeleteStudent(Student student);
    }
}
