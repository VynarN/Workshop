using System;
using System.Collections.Generic;
using System.Linq;

namespace VynarN.Workshop.Tests.NUnitHometask1
{
    public class School
    {
        private HashSet<Student> Students;

        public School()
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

        public bool AddStudent(Student student)
        {
            if(student != null)
            {
                var ids = Students.Select(x => x.Id);
                if(!ids.Contains(student.Id))
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
    }
}
