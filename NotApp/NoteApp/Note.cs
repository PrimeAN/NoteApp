﻿using System;
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
        private string _name = "Untitled";
        
        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;
        
        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category;
        
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
        /// Возвращает и задает название заметки
        /// </summary>
        public string Name
        {
            get => _name;
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title should be!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Title must not exceed 50 characters!");
                }
        
                _name = value;
                LastChangeTime = DateTime.Now;
            }
        }

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
            if (obj==null)
            {
                return false;
            }
            var note = (Note) obj;

            return Name == note.Name 
                   && Category == note.Category 
                   && Text == note.Text 
                   && CreationTime == note.CreationTime 
                   && LastChangeTime == note.LastChangeTime;
        }
    }
}