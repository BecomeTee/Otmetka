using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface InterfaceClass
    {
        ICollection<Class> GetClasses();
        Class GetClass(Guid id);
        ICollection<Class> GetClassByName(string name);
        Class GetClassByAttend(Attendance attend);
        ICollection<Class> GetClassesByAttends(ICollection<Attendance> attends);
        bool CreateClass(Class clas);
        bool UpdateClass(Class clas);
        bool DeleteClass(Class clas);
        bool ClassExist(Guid id);
        bool Save();


        /*Class GetClassByDateStart(DateTime dateStart);
        Class GetClassByDateFinish(DateTime dateFinish);*/
        //Class GetClassByRoom(int /*roomint*/ room);
        //Class GetClassByTeacher(string teacher);
        //ICollection<Student> GetStudentsByNameNGroup(string name, string group);  зачем оно????
    }
}