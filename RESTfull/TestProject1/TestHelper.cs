using RESTfull.Domain.Model;
using RESTfull.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RESTfull.Infrastructure.Repository;

namespace TestProject1
{
    public class TestHelper
    {
        private readonly Context _context;

        public TestHelper()
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseNpgsql(@"Server=(localhost)\postgres;Database=Test")
                .Options;

            _context = new Context(contextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var student = new Student
            {
                Name = "Sonya",
                Group = "121",
            };
            _context.students.Add(student);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public StudentRepository StudentRepository 
        {
            get
            {
                return new StudentRepository(_context);
            }
        }
    }
}