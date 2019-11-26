using System;
using System.Collections.Generic;
using System.Linq;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class Course
    {
        private HashSet<Student> Students;

        public Course()
        {
            Students = new HashSet<Student>();
        }

        public HashSet<Student> GetStudents()
        {
            if (Students != null)
            {
                return Students.Take(Students.Count).ToHashSet();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public bool EnrollStudent(Student student)
        {
            if (student != null)
            {
                if (Students.Count < 29)
                {
                    return Students.Add(student);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public bool UnenrollStudent(int id)
        {
            return Students.RemoveWhere(x => x.Id == id) != 0;
        }
    }
}
