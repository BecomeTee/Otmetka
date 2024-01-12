using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface InterfaceStudent
    {
        ICollection<Student> GetStudents();
        Student GetStudent(Guid id);
        Student GetStudentByName(string name);
        ICollection<Student> GetStudentsByNameNGroup(string name, string group);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool StudentExist(Guid id);
        bool Save();


        //Student GetStudentById(Guid id);
        //void CreateStudent(Student student);
        //void UpdateStudent(Student student);
        //void DeleteStudent(Student student);
    }
}
