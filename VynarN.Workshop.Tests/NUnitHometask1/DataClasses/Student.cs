using System;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class Student
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Student(int id, string name)
        {
            if((id > 10000 && id < 99999) && !string.IsNullOrEmpty(name))
            {
                Id = id;
                Name = name;
            }
            else
            {
                throw new ArgumentException("Id should be in the range of 10000 to 99999 and Name can not be null or empty!");
            }
        }

        public bool JoinCourse(Course course)
        {
            if (course != null)
            {
                return course.EnrollStudent(this);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public bool LeaveCourse(Course course)
        {
            if (course != null)
            {
                return course.UnenrollStudent(Id);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
