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
    public class AttendRepository : InterfaceAttend
    {
        private readonly Context _context;

        public AttendRepository(Context context)
        {
            _context = context;
        }

        public ICollection<Attendance> GetAttends()
        {
            return _context.attendances.OrderBy(x => x.Id).ToList();
        }

        public Attendance GetAttend(Guid id) 
        {
            return _context.attendances.Where(x => x.Id == id).FirstOrDefault();
        }

        /* public ICollection<Attendance> GetAttendsByNameClass(string name)
         {
             return _context.attendances.Where(x => x.Id_class == _context.classes.Where(y => y.Name == name).FirstOrDefault().Id).ToList();
         }*/


        public ICollection<Attendance> GetAttendsByStudentId(Guid studentId) 
        {
            return _context.attendances.Where(x => x.Id_student == studentId).ToList();
        }

        public bool CreateAttend(Attendance attend)
        {
            var findStudent = _context.students.Where(x => x.Id == attend.Id_student).FirstOrDefault();
            var findClass = _context.classes.Where(x => x.Id == attend.Id_class).FirstOrDefault();
            attend.Student = findStudent;
            attend.Class = findClass;
            _context.Add(attend);
            return Save();
        }

        public bool UpdateAttend(Attendance attend)
        {
            var findStudent = _context.students.Where(x => x.Id == attend.Id_student).FirstOrDefault();
            var findClass = _context.classes.Where(x => x.Id == attend.Id_class).FirstOrDefault();
            attend.Student = findStudent;
            attend.Class = findClass;
            _context.Update(attend);
            return Save();
        }

        public bool DeleteAttend(Attendance attend)
        {
            _context.Remove(attend);
            return Save();
        }


        public bool AttendExist(Guid id)
        {
            return _context.attendances.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
