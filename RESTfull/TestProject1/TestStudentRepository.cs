using NUnit.Framework;
using RESTfull.Domain.Model;

namespace TestProject1
{
    public class TestStudentRepository
    {
        public void VoidTest()
        {
            var testHelper = new TestHelper();
            var studentRepository = testHelper.StudentRepository;

            Assert.Equals(1, 1);
        }

        public async void TestAdd()
        {
            var testHelper = new TestHelper();
            var studentRepository = testHelper.StudentRepository;
            var student = new Student
            {
                Name = "Maks",
                Group = "123",
            };
            var id = new Guid();
            student.Id = id;

            var person = studentRepository.CreateStudent(student);

            Assert.True((studentRepository.GetStudents()).ToList().Count == 2);

            Assert.Equals("Maks", studentRepository.GetStudentByName("Maks").Name);
        }

    }
}