using System.Linq;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class TestData
    {
        public School TestSchool = new School();

        public Course TestCourse1 = new Course();

        public Course TestCourse2 = new Course();

        public TestData()
        { 
            for(int i = 0; i < 100; i++)
            {
                TestSchool.AddStudent(new Student((10001 + i), $"student #{i}"));
            }
 
            foreach(var student in TestSchool.GetStudents().Take(29))
            {
                TestCourse1.EnrollStudent(student);
            }

            foreach (var student in TestSchool.GetStudents().Take(15))
            {
                TestCourse1.EnrollStudent(student);
            }
        }

    }
}
