using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Magazine.Tests
{
    [TestClass]
    public class MagazineTest
    {
        private Mock<IStudentsRepository> _studentsRepository;

        [TestInitialize]
        public void SetUp()
        {
            _studentsRepository = new Mock<IStudentsRepository>();

            _studentsRepository.Setup(m => m.Students).Returns(new List<Student>
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
            });
        }

        [TestMethod]
        public void Test_Sort_List_Student_True()
        {
            // arrange
            var magazine = new Magazine( _studentsRepository.Object);

            // act
            var sortedList = magazine.GetSortedByMark();

            // assert
            Assert.AreEqual("Lion Nick", sortedList.FirstOrDefault().ToString());

        }

        [TestMethod]
        public void Test_GetWorstStudent_Without_NULL_Object()
        {
            // arrange
            var magazine = new Magazine( _studentsRepository.Object );

            // act
            var worsStudent = magazine.GetWorstStudent();

            // assert
            Assert.IsNotNull(worsStudent);
        }

        [TestMethod]
        public void Test_GetWorstStudent_With_Good_Object()
        {
            var fakeStudent = new Student
            {
                Name = "Max",
                Surname = "Goncharuk",
                Mark = 3
            };

            // arrange
            var fakeStudent1 = new Student
            {
                Name = "Zahar",
                Surname = "Zolotarev",
                Mark = 5
            };
            var fakeStudent2 = new Student
            {
                Name = "Michael", 
                Surname = "Hramov",
                Mark = 2
            };
            var list = new List<Student> {fakeStudent, fakeStudent1, fakeStudent2};

            _studentsRepository.Setup(m => m.Students).Returns(list);
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            var worsStudent = magazine.GetWorstStudent();

            // assert
            Assert.AreEqual(fakeStudent2, worsStudent);

            
        }

        [TestMethod]
        public void Test_MagazineCount_Not_Zero()
        {
            // arrange
            
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            var actualCount = magazine.GetStudentsCount();

            // assert
            Assert.AreNotEqual(0, actualCount);
        }

        [TestMethod]
        public void Test_MagazineCount_WithGoodResult()
        {
            // arrange
            var count = _studentsRepository.Object.Students.Count();
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            var actualCount = magazine.GetStudentsCount();

            // assert
            Assert.AreEqual(count, actualCount, "Bad result");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_AddStudentExpectedException()
        {
            // arrange
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            magazine.AddStudent(null);
        }

        [TestMethod]
        public void Test_AddStudentWithGoodObject()
        {
            // arrange
            _studentsRepository.Setup(m => m.Students).Returns(new List<Student>());
            var magazine = new Magazine(_studentsRepository.Object);
            var newStudent = new Student
            {
                Name = "Michael",
                Surname = "Hramov",
                Mark = 3
            };


            // act
            magazine.AddStudent(newStudent);

            // assert
            Assert.AreEqual(1, magazine.GetStudentsCount());
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_SetStudentNameWithEmptyString()
        {
            // arrange
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            magazine.SetStudentName(String.Empty, String.Empty);
        }

        [TestMethod]
        public void Test_SetStudentNameGetTrue()
        {
            // arrange
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            var result = magazine.SetStudentName("Misha", "Vitya");

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_SetStudentNameBadName()
        {
            var magazine = new Magazine(_studentsRepository.Object);

            // act
            var result = magazine.SetStudentName("Vitya", "Max");

            // assert
            Assert.IsFalse(result);
        }
    }
}
