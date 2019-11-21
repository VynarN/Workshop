using System;
using NUnit.Framework;
using System.Linq;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class StudentTest
    {
        [Test]
        public void Students_Name_Cannot_Be_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Student(90000, ""));
        }

        [Test]
        public void Strudent_Joins_Course()
        {
            var testData = new TestData();

            var student = testData.TestSchool.GetStudents().Last();

            var isEnrolled = student.JoinCourse(testData.TestCourse2);

            Assert.IsTrue(isEnrolled);
        }
    }
}
