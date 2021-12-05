using System;
using NUnit.Framework;

namespace NoteApp.UnitTests
{

    [TestFixture]
    public class NoteTest
    {
        
        [Test(Description = "Тестирования методов свойства Name с корректными данными.")]
        public void TestName_CurrectValue()
        {
            var expectedName = "Заметка";
            var actualNote = new Note();
            actualNote.Name = expectedName;
            
            Assert.AreEqual(expectedName, actualNote.Name, 
                "В результате работы метода свайства Name имеет некорректное значение.");
        }
        
        [TestCase("", "Должно возникать исключение, если имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Заметкаааа-Заметкаааа-Заметкаааа-Заметкаааа-Заметкаааа-", 
            "Должно возникать исключение, если имя длиннее 50 символов",
            TestName = "Присвоение неправильного имени больше 50 символов")]
        public void TestNameSet_ArgumentException(string expectedName, string message)
        {
            var actualNote = new Note();
            
            Assert.Throws<ArgumentException>(
                () => { actualNote.Name = expectedName; },
                message);
        }

        [Test(Description = "Тестирования методов свойства Category с корректными данными.")]
        public void TestCategory_CurrectValue()
        {
            var expectedCategory = NoteCategory.Home;
            var actualNote = new Note();
            actualNote.Category = expectedCategory;
            
            Assert.AreEqual(expectedCategory, actualNote.Category, 
                "В результате работы метода свайства Category имеет некорректное значение.");
        }
        
        [Test(Description = "Тестирования методов свойства Text с корректными данными.")]
        public void TestText_CurrectValue()
        {
            var expectedText = "Текст";
            var actualNote = new Note();
            actualNote.Text = expectedText;
            
            Assert.AreEqual(expectedText, actualNote.Text, 
                "В результате работы метода свайства Text имеет некорректное значение.");
        }
        
        [Test(Description = "Тестирования методов свойства CreationTime с корректными данными.")]
        public void TestCreationTime_CurrectValue()
        {
            var expectedCreationTime = new DateTime();
            var actualNote = new Note();
            actualNote.CreationTime = expectedCreationTime;
            
            Assert.AreEqual(expectedCreationTime, actualNote.CreationTime, 
                "В результате работы метода свайства CreationTime имеет некорректное значение.");
        }
        
        [Test(Description = "Тестирования методов свойства LastChangeTime с корректными данными.")]
        public void TestLastChangeTime_CurrectValue()
        {
            var expectedLastChangeTime = new DateTime();
            var actualNote = new Note();
            actualNote.LastChangeTime = expectedLastChangeTime;
            
            Assert.AreEqual(expectedLastChangeTime, actualNote.LastChangeTime, 
                "В результате работы метода свайства LastChangeTime имеет некорректное значение.");
        }
        
        [Test(Description = "Тестированиe клонирования Note.")]
        public void TestNoteClone_CorrectValue()
        {
            var expectedNote = new Note(){Name = "Заметка", Category = NoteCategory.Home, Text = "Текст", 
                CreationTime = DateTime.Now,LastChangeTime = DateTime.Now};
            var actualNote = (Note)expectedNote.Clone();
            
            Assert.IsFalse(!(expectedNote.Name == actualNote.Name && expectedNote.Category == actualNote.Category &&
                             expectedNote.Text == actualNote.Text && expectedNote.CreationTime == actualNote.CreationTime &&
                             expectedNote.LastChangeTime == actualNote.LastChangeTime), "Клонирование произошло неуспешно.");
        }

        [Test(Description = "Тестирование сравнения с корректными Notes")]
        public void TestNoteEquals_CorrectValue()
        {
            var expectedNote = new Note(){Name = "Заметка", Category = NoteCategory.Home, Text = "Текст", 
                CreationTime = DateTime.Now,LastChangeTime = DateTime.Now};
            var actualNote = new Note(){Name = "Заметка", Category = NoteCategory.Home, Text = "Текст", 
                CreationTime = DateTime.Now,LastChangeTime = DateTime.Now};
            
            Assert.IsFalse(!expectedNote.Equals(actualNote),"Неверное сравнение данных.");
        }
    }
}