using System;

namespace Magazine
{
    public class Student
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public int Mark { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name;
        }
    }
}