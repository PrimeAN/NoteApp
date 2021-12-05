using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using NoteApp;

namespace NoteAppUI
{
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Заметка
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает и задает заметку
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                
                TitleTextBox.Text = _note.Name;
                CategoryComboBox.SelectedItem = _note.Category;
                CreationDatePicker.Text = _note.CreationTime.ToShortDateString();
                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
                NoteContentTextBox.Text = _note.Text;
            }
        }

        public NoteForm()
        {
            InitializeComponent();
            FillCategoryComboBox();
        }

        /// <summary>
        /// Метод, заполняющий выпадающий список категорий
        /// </summary>
        private void FillCategoryComboBox()
        {
            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoryComboBox.Items.Add(category);
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Note.Name = TitleTextBox.Text;
                TitleTextBox.BackColor = Color.White;
                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
            }
            catch (ArgumentException exception)
            {
                TitleTextBox.BackColor = Color.LightCoral;
            }
        }

        private void CategoryComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Если значение не определено в перечислении, то выбросит исключение
                Enum.IsDefined(typeof(NoteCategory), CategoryComboBox.SelectedItem);
                Note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
                CategoryComboBox.BackColor = Color.White;

                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
            }
            catch (JsonSerializationException exception)
            {
                CategoryComboBox.BackColor = Color.LightCoral;
            }
        }

        private void NoteContentTextBox_TextChanged(object sender, EventArgs e)
        {
            Note.Text = NoteContentTextBox.Text;
            ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}