using System.Collections.Generic;
using System.IO;

namespace Magazine
{
    public class StudentsFileRepository : IStudentsRepository
    {
        public IEnumerable<Student> Students { get; private set; }

        public StudentsFileRepository()
        {
            var data = File.ReadAllLines("..\\..\\..\\DB.txt");

            Students = new List<Student>
            {
                new Student
                {
                    Name = data[0],
                    Surname = data[1],
                    Mark = int.Parse(data[2])
                },
                new Student
                {
                    Name = data[3],
                    Surname = data[4],
                    Mark = int.Parse(data[5])
                },
                new Student
                {
                    Name = data[6],
                    Surname = data[7],
                    Mark = int.Parse(data[8])
                }
            };
        }
    }
}