using System;

namespace Magazine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var magazine = new Magazine(new StudentsFileRepository());

            foreach (var listStudent in magazine.GetAll())
            {
                Console.WriteLine(listStudent);
            }

            Console.ReadLine();
        }
    }
}
