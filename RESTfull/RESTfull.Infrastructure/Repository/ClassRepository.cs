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
    public class ClassRepository : InterfaceClass
    {
        private readonly Context _context;

        public ClassRepository(Context context)
        {
            _context = context;
        }

        public ICollection<Class> GetClasses()
        {
            return _context.classes.OrderBy(x => x.Id).ToList();
        }

        public Class GetClassByAttend(Attendance attend)
        {
            return _context.classes.Where(x => x.Id == attend.Id_class).FirstOrDefault();
        }

        public ICollection<Class> GetClassesByAttends(ICollection<Attendance> attends)
        {
            var classes = new List<Class>();
            foreach (var attend in attends)
            {
                classes.Add(GetClassByAttend(attend));
            }
            return classes;
        }

        public Class GetClass(Guid id)
        {
            return _context.classes.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<Class> GetClassByName(string name)
        {
            return _context.classes.Where(x => x.Name == name).ToList();
        }

        /*public Class GetClassByDateStart(DateTime dateStart)
        {
            return _context.classes.Where(x => x.DateStart == dateStart).FirstOrDefault();
        }

        public Class GetClassByDateFinish(DateTime dateFinish)
        {
            return _context.classes.Where(x => x.DateFinish == dateFinish).FirstOrDefault();
        }

        public Class GetClassByRoom(int room)
        {
            return _context.classes.Where(x => x.Room == room).FirstOrDefault();
        }*/

        /*public Class GetClassByTeacher(string teacher)
        {
            return _context.classes.Where(x => x.Teacher == teacher).FirstOrDefault();
        }*/

        public bool CreateClass(Class clas)
        {
            _context.Add(clas);
            return Save();
        }

        public bool UpdateClass(Class clas)
        {
            _context.Update(clas);
            return Save();
        }

        public bool DeleteClass(Class clas)
        {
            _context.Remove(clas);
            return Save();
        }


        public bool ClassExist(Guid id)
        {
            return _context.classes.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
