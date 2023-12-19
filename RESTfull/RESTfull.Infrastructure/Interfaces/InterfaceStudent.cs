using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface InterfaceStudent
    {
        ICollection<Student> GetStudents();
        Student GetStudent(Guid id);
        Student GetStudent(string id);
        //Student GetStudentById(Guid id);
        //void CreateStudent(Student student);
        //void UpdateStudent(Student student);
        //void DeleteStudent(Student student);
    }
}
