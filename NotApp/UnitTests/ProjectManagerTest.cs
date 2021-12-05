using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        private string _pathCorrectProjectFail = "TestData\\CorrectProjectFail.json";
        
        private List<Note> GetNoteList()
        {
            return new List<Note>()
            {
                new Note("Other", NoteCategory.Other, "Текст Other",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("8/7/2021 00:00:00")),
                new Note("Work", NoteCategory.Work, "Текст Work",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("9/7/2021 00:00:00")),
                new Note("Home", NoteCategory.Home, "Текст Home",
                DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("12/7/2021 00:00:00"))
            };
        }
        
        [Test(Description = "Тестирования методов свойства DefaultPath с корректными данными.")]
        public void TestDefaultPath_CorrectValue()
        {
            var expectedPath= "Path";
            ProjectManager.DefaultPath = expectedPath;
            
            Assert.AreEqual(expectedPath,ProjectManager.DefaultPath,
                "В результате работы метода свайства DefaultPath имеет некорректное значение.");
        }
        
        [Test(Description = "Создание файла с корректными значениями.")]
        public void TestProjectManagerSaveToFile_CorrectSave()
        {
            var expectedLines = File.ReadAllLines(_pathCorrectProjectFail);
            var actualProject = new Project();
            actualProject.Notes = GetNoteList();
            var actualPath = "Output\\ProjectFail.json";
            
            ProjectManager.SaveToFile(actualProject,actualPath);

            var actualLines = File.ReadAllLines(actualPath);
            Assert.That(actualLines, Is.EquivalentTo(expectedLines),"Некорректное создание файла.");
        }
        
        [Test(Description = "Чтение файла с корректными значениями.")]
        public void TestProjectManagerLoadFromFile_CorrectLoad()
        {
            var expectedProject = new Project();
            expectedProject.Notes = GetNoteList();
            
            var actualProject = ProjectManager.LoadFromFile(_pathCorrectProjectFail);
            
            Assert.AreEqual(expectedProject.Notes.Count,actualProject.Notes.Count,
                "Некорректное чтение файла: количество элементов не совпадает.");
            Assert.That(actualProject.Notes, Is.EquivalentTo(expectedProject.Notes),
                "Некорректное чтение файла: элементы не совпадают.");
        }
        
        [Test(Description = "Чтение повреждённого файла.")]
        public void TestProjectManagerLoadFromDamagedFile_CorrectLoad()
        {
            var actualProject = ProjectManager.LoadFromFile("TestData\\DamagedProjectFail.json");

            Assert.IsTrue(actualProject == null, "Повреждённый файл невозможно считать.");
        }
        
        [Test(Description = "Чтение несуществующего файла.")]
        public void TestProjectManagerLoadFromExistentFile_CorrectLoad()
        {
            Assert.Throws<ArgumentException>(
                () => {var actualProject = ProjectManager.LoadFromFile("TestData\\ExistentProjectFail.json");},
                "Несуществующий файл возможно считать.");
        }
    }
}