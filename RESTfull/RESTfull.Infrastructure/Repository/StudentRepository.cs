using RESTfull.Domain.Model;
using RESTfull.Infrastructure.Data;
using RESTfull.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Repository
{
    public class StudentRepository : InterfaceStudent
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        public ICollection<Student> GetStudents()
        {
            return _context.students.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Student> GetStudentsByNameNGroup(string name, string group)
        {
            return _context.students.Where(s => s.Name == name && s.Group == group).ToList();
        }

        public Student GetStudent(Guid id) 
        {
            return _context.students.Where(x => x.Id == id).FirstOrDefault();
        }

        public Student GetStudentByName(string name)
        {
            return _context.students.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool CreateStudent(Student student)
        {
            _context.Add(student);
            return Save();
        }

        public bool UpdateStudent(Student student)
        {
            _context.Update(student);
            return Save();
        }

        public bool DeleteStudent(Student student)
        {
            _context.Remove(student);
            return Save();
        }


        public bool StudentExist(Guid id)
        {
            return _context.students.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
