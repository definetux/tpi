using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace Lab2.Tests
{
    [TestFixture]
    public class SystemFileExplorerTestWithCI
    {
        private const string DIR = @"C:\Temporary\";


        private readonly string[] _filesData =
        {
            "data from file 1",
            "data from file 2",
            "bad data",
            "good data",
            "other data"
        };

        /// <summary>
        /// Проверяем метод сохранения бэкапа используя собственный класс-заглушку, тестируем мок и стаб
        /// </summary>
        [Test]
        public void MergeTemporaryFiles_TestWithFakeDependency()
        {
            // arrange
            var fileManager = new FakeFileManager();
            var fileExplorer = new SystemFileExplorerWithCI(fileManager);

            // act
            var result = fileExplorer.MergeTemporaryFiles(DIR);

            // assert
            Assert.That(fileManager.Call, Is.EqualTo(2));
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Проверяем метод сохранения бэкапа используя Moq, тестируем мок и стаб
        /// </summary>
        [Test]
        public void MergeTemporaryFiles_TestWithMoq()
        {
            // arrange  
            var fileManager = new Mock<IFileManager>();

            fileManager.Setup(s => s.GetFilesData(DIR)).Returns(_filesData);
            fileManager.Setup(s => s.SaveBackup(DIR, String.Concat(_filesData))).Returns(true);

            var fileExplorer = new SystemFileExplorerWithCI(fileManager.Object);

            // act
            var result = fileExplorer.MergeTemporaryFiles(DIR);

            // assert
            fileManager.Verify(s => s.GetFilesData(DIR));
            fileManager.Verify(s => s.SaveBackup(DIR, String.Concat(_filesData)));

            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Проверяем метод удаления файлов используя собственный класс-заглушку, тестируем мок и стаб
        /// </summary>
        [Test]
        public void RemoveTemporaryFiles_TestWithFakeDependency()
        {
            // arrange
            var fileManager = new FakeFileManager();
            var fileExplorer = new SystemFileExplorerWithCI(fileManager);

            // act
            var result = fileExplorer.RemoveTemporaryFiles(DIR);
            
            // assert
            Assert.That(fileManager.Call, Is.EqualTo(2));
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Проверяем метод удаления файлов используя Moq, тестируем мок и стаб
        /// </summary>
        [Test]
        public void RemoveTemporaryFiles_TestWithMoq()
        {
            // arrange  
            var fileManager = new Mock<IFileManager>();

            fileManager.Setup(s => s.FilesToRemove(DIR)).Returns(_filesData);
            fileManager.Setup(s => s.RemoveFiles(_filesData)).Returns(true);
            var fileExplorer = new SystemFileExplorerWithCI(fileManager.Object);

            // act
            var result = fileExplorer.RemoveTemporaryFiles(DIR);

            // assert

            fileManager.Verify(s => s.FilesToRemove(DIR));
            fileManager.Verify(s => s.RemoveFiles(_filesData));

            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Метод принимает принимает некорректный путь к директории
        /// </summary>
        [Test]
        public void MergeTemporaryFiles_BadPath()
        {
            // arrange
            var fileManager = new Mock<IFileManager>();

            fileManager.Setup(s => s.GetFilesData("Bad path")).Returns(_filesData);
            fileManager.Setup(s => s.SaveBackup("Bad path", String.Concat(_filesData))).Throws<ArgumentException>();
            var fileExplorer = new SystemFileExplorerWithCI(fileManager.Object);

            // act | assert

            Assert.Throws<ArgumentException>(() => fileExplorer.MergeTemporaryFiles("Bad path"));
        }

        /// <summary>
        /// Метод принимает принимает некорректный путь к директории
        /// </summary>
        [Test]
        public void RemoveTemporaryFiles_BadPath()
        {
            // arrange
            var fileManager = new Mock<IFileManager>();

            fileManager.Setup(s => s.FilesToRemove("Bad path")).Throws<ArgumentException>();
            var fileExplorer = new SystemFileExplorerWithCI(fileManager.Object);

            // act | assert

            Assert.Throws<ArgumentException>(() => fileExplorer.RemoveTemporaryFiles("Bad path"));
        }
    }
}
