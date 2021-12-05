using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        private List<Note> GetNoteEmptyDateList()
        {
            return new List<Note>()
            {
                new Note("Other", NoteCategory.Other, "Текст Other"),
                new Note("Work", NoteCategory.Work, "Текст Work"),
                new Note("Home", NoteCategory.Home, "Текст Home"),
                new Note("HealthAndSport", NoteCategory.HealthAndSport, "Текст HealthAndSport"),
                new Note("People", NoteCategory.People, "Текст People"),
                new Note("Documents", NoteCategory.Documents, "Текст Documents"),
                new Note("Finance", NoteCategory.Finance, "Текст Finance")
            };
        }
        
        private List<Note> GetNoteList()
        {
            return new List<Note>()
            {
                new Note("Other", NoteCategory.Other, "Текст Other",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("8/7/2021 00:00:00")),
                new Note("Work", NoteCategory.Work, "Текст Work",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("9/7/2021 00:00:00")),
                new Note("Home", NoteCategory.Home, "Текст Home",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("10/7/2021 00:00:00")),
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("11/7/2021 00:00:00")),
                new Note("People", NoteCategory.People, "Текст People",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("12/7/2021 00:00:00")),
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("13/7/2021 00:00:00")),
                new Note("Finance", NoteCategory.Finance, "Текст Finance",
                    DateTime.Parse("1/7/2021 00:00:00"),DateTime.Parse("14/7/2021 00:00:00"))
            };
        }

        [Test(Description = "Тестирования методов свойства Notes с корректными данными.")]
        public void TestNotes_CorrectValue()
        {
            var expectedList = GetNoteEmptyDateList();
            var actualProject = new Project();
            actualProject.Notes = expectedList;
            
            Assert.AreEqual(expectedList,actualProject.Notes,
                "В результате работы метода свайства Notes имеет некорректное значение.");
            Assert.That(actualProject.Notes, Is.EquivalentTo(expectedList),
                "В результате работы метода свайства Notes имеет некорректные элементы коллекции.");
        }
        
        [Test(Description = "Тестирования методов свойства CurrentNote с корректными данными.")]
        public void TestCurrentNote_CorrectValue()
        {
            var expectedList = GetNoteEmptyDateList();
            var expectedNote = expectedList[1];
            var actualProject = new Project();
            actualProject.CurrentNote = expectedNote;

            Assert.AreEqual(expectedNote,actualProject.CurrentNote,
                "В результате работы метода свайства CurrentNote имеет некорректное значение.");
        }

        [Test(Description = "Сортировка по дате изменения листа Notes с корректными данными.")]
        public void TestLastChangeTimeSort_CorrectValue()
        {
            var expectedList = new List<Note>()
            {
                new Note("Finance", NoteCategory.Finance, "Текст Finance",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("14/7/2021 00:00:00")),
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("13/7/2021 00:00:00")),
                new Note("People", NoteCategory.People, "Текст People",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("12/7/2021 00:00:00")),
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("11/7/2021 00:00:00")),
                new Note("Home", NoteCategory.Home, "Текст Home",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("10/7/2021 00:00:00")),
                new Note("Work", NoteCategory.Work, "Текст Work",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("9/7/2021 00:00:00")),
                new Note("Other", NoteCategory.Other, "Текст Other",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("8/7/2021 00:00:00"))
            };
            var actualProject = new Project();
            actualProject.Notes = GetNoteList();

            var actualList = actualProject.LastChangeTimeSort();
            
            Assert.AreEqual(expectedList.Count,actualList.Count,"Листы должен быть равны");
            Assert.That(actualList, Is.EquivalentTo(expectedList),
                "Лист должен быть отсортирован по убыванию даты изменения.");
        }
        
        [Test(Description = "Сортировка по дате изменения листа Notes с определённой категорией.")]
        public void TestLastChangeTimeSortWithCategory_CorrectValue()
        {
            var expectedList = new List<Note>()
            {
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("13/7/2021 00:00:00")),
                new Note("Documents", NoteCategory.Documents, "Текст Documents",
                    DateTime.Parse("1/7/2021 00:00:00"), DateTime.Parse("11/7/2021 00:00:00"))
            };
            var actualProject = new Project();
            actualProject.Notes = GetNoteList();

            var actualList = actualProject.LastChangeTimeSortWithCategory(NoteCategory.Documents);
            
            Assert.AreEqual(expectedList.Count,actualList.Count,"Листы должен быть равны");
            Assert.That(actualList, Is.EquivalentTo(expectedList),
                "Лист должен быть отсортирован по убыванию даты изменения с определённой категорией");
        }
    }
}
