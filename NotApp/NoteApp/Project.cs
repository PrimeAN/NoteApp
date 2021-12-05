using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    /// <summary>
    /// Класс <see cref="Project"/>, хранящий список заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Возвращает и задает список всех заметок
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Возвращает и задает текущую заметку
        /// </summary>
        public Note CurrentNote { get; set; }

        /// <summary>
        /// Создает экземпляр <see cref="Project"/>
        /// </summary>
        public Project()
        {
            Notes = new List<Note>();
        }

        /// <summary>
        /// Метод для сортировки списка заметок по дате изменения (по убыванию)
        /// </summary>
        /// <returns></returns>
        public List<Note> LastChangeTimeSort()
        {
            var orderedList = 
                Notes.OrderByDescending(note => note.LastChangeTime);
            return orderedList.ToList();
        }

        /// <summary>
        /// Метод для сортировки списка заметок по дате изменения (по убыванию)
        /// при определенной категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Note> LastChangeTimeSortWithCategory(NoteCategory category)
        {
            return Notes.OrderByDescending(note => note.LastChangeTime).
                Where(note => note.Category == category).ToList();
        }
    }
}