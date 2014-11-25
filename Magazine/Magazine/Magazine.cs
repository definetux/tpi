using System;
using System.Collections.Generic;
using System.Linq;

namespace Magazine
{
    public class Magazine
    {
        private readonly IStudentsRepository _studentsRepository;

        public Magazine(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentsRepository.Students;
        }

        public IEnumerable<Student> GetSortedByMark()
        {
            return _studentsRepository.Students.OrderByDescending(s => s.Mark);
        }

        public Student GetWorstStudent()
        {
            return _studentsRepository.Students.OrderBy(s => s.Mark).FirstOrDefault();
        }

        public int GetStudentsCount()
        {
            return _studentsRepository.Students.Count();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }
            ((List<Student>)_studentsRepository.Students).Add(student);
        }

        public bool SetStudentName(String oldName, String newName)
        {
            if (oldName == String.Empty || newName == String.Empty)
            {
                throw new ArgumentException();                
            }
            var student = _studentsRepository.Students.FirstOrDefault(s => s.Name == oldName);

            if (student == null)
            {
                return false;
            }
            student.Name = newName;
            return true;
        }

    }
}
