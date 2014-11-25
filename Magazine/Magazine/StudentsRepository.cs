using System.Collections.Generic;

namespace Magazine
{
    public class StudentsRepository : IStudentsRepository
    {
        public IEnumerable<Student> Students { get; private set; }

        public StudentsRepository()
        {
            Students = new List<Student>()
            {
                new Student
                {
                    Name = "Misha", Surname = "Hramov", Mark = 2
                },
                new Student
                {
                    Name = "Nick", Surname = "Lion", Mark = 5
                },
                new Student
                {
                    Name = "Nick", Surname = "Ovcharenko", Mark = 4
                }
            };
        }
    }
}