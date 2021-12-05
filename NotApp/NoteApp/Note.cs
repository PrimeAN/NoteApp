using System;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс <see cref="Note"/>, хранящий информацию о заметке
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки. Название не должно превышать 50 символов.
        /// </summary>
        private string _name = "Без названия";
        
        /// <summary>
        /// Возвращает и задает название заметки
        /// </summary>
        public string Name
        {
            get => _name;
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Название должно быть!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Название не должно превышать 50 символов!");
                }
        
                _name = value;
                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Возвращает и задает категорию заметки
        /// </summary>
        public NoteCategory Category
        {
            get => _category;
            
            set
            {
                _category = value;
                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;

        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string Text
        {
            get => _text;

            set
            {
                _text = value;
                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задает время создания заметки
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Возвращает и задает время последнего изменения заметки
        /// </summary>
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>
        /// </summary>
        public Note()
        {
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
        }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="text"></param>
        public Note(string name, NoteCategory category, string text)
        {
            Name = name;
            Category = category;
            Text = text;
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
        }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="text"></param>
        /// <param name="creationTime"></param>
        /// <param name="lastChangeTime"></param>
        [JsonConstructor]
        public Note(string name, NoteCategory category, string text, DateTime creationTime,
            DateTime lastChangeTime)
        {
            Name = name;
            Category = category;
            Text = text;
            CreationTime = creationTime;
            LastChangeTime = lastChangeTime;
        }

        /// <summary>
        /// Метод для создания копии объекта
        /// </summary>
        public object Clone() => this.MemberwiseClone();
        
        /// <summary>
        /// Метод для сравнения значений двух объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var note = (Note) obj;

            if (Name == note.Name && Category == note.Category && Text == note.Text &&
                CreationTime == note.CreationTime && LastChangeTime == note.LastChangeTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}