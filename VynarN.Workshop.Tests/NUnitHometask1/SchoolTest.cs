using System.Linq;
using NUnit.Framework;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class SchoolTest
    {
        [Test]
        public void All_IDs_Are_Unique()
        {
            var testData = new TestData();

            var student = testData.TestSchool.GetStudents().First();

            var testStudent = new Student(student.Id, "testStudent");

            var isAdded = testData.TestSchool.AddStudent(testStudent);

            Assert.IsFalse(isAdded);
        }
    }
}
