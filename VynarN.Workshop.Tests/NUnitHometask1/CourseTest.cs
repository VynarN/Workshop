using NUnit.Framework;
using System.Linq;
using System;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class CourseTest
    {
        [Test]
        public void Check_Max_Size_Of_Group()
        {
            var testData = new TestData();

            var student = testData.TestSchool.GetStudents().Last();
            
            var isAdded = testData.TestCourse1.EnrollStudent(student);

            Assert.IsFalse(isAdded);
        }
    }
}