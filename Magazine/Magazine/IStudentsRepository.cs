using System.Collections.Generic;

namespace Magazine
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> Students { get; }
    }
}