using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Проект
        /// </summary>
        private Project _project;

        /// <summary>
        /// Список заметок, сортированный по дате изменения
        /// </summary>
        private List<Note> _currentDisplayedNotes;

        public MainForm()
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

            InitializeComponent();
            FillCategoryComboBox();

            _currentDisplayedNotes = _project.LastChangeTimeSort();
            _project.Notes = _currentDisplayedNotes;

            FillNoteListBox();

            if (_project.CurrentNote != null)
            {
                var currentNoteIndex = _project.Notes.IndexOf(_project.CurrentNote);
                NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
            }
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
            CategoryComboBox.Items.Add("All");
        }

        /// <summary>
        /// Метод, заполняющий список заметок
        /// </summary>
        private void FillNoteListBox()
        {
            NotesListBox.Items.Clear();

            foreach (var note in _currentDisplayedNotes)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }

            var realIndexInProject = _project.Notes.IndexOf(_currentDisplayedNotes[selectedIndex]);
            _project.CurrentNote = _project.Notes[realIndexInProject];

            NoteTitleTextBox.Text = _currentDisplayedNotes[selectedIndex].Name;
            CategoryTextBox.Text = _currentDisplayedNotes[selectedIndex].Category.ToString();
            CreatedDatePicker.Text =
                _currentDisplayedNotes[selectedIndex].CreationTime.ToShortDateString();
            ModifiedDatePicker.Text =
                _currentDisplayedNotes[selectedIndex].LastChangeTime.ToShortDateString();
            NoteContentTextBox.Text = _currentDisplayedNotes[selectedIndex].Text;
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var inner = new NoteForm();
            inner.Note = new Note();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var newNote = inner.Note;
            _project.Notes.Add(newNote);

            FillNotesListBoxAfterEdit(newNote);

            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = NotesListBox.SelectedIndex;
            var selectedNote = _currentDisplayedNotes[selectedIndex];
            var realIndexInProject = _project.Notes.IndexOf(selectedNote);

            var inner = new NoteForm();
            inner.Note = (Note)selectedNote.Clone();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var updatedNote = inner.Note;
            _project.Notes.RemoveAt(realIndexInProject);
            _project.Notes.Insert(realIndexInProject, updatedNote);

            FillNotesListBoxAfterEdit(updatedNote);

            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        /// <summary>
        /// Метод для заполнения списка заметок после и выбора текущей заметки
        /// после добавления, редактирования или удаления заметки
        /// </summary>
        private void FillNotesListBoxAfterEdit(Note note)
        {
            if (CategoryComboBox.SelectedItem != null && CategoryComboBox.SelectedItem != "All")
            {
                _currentDisplayedNotes = _project.LastChangeTimeSortWithCategory(
                    (NoteCategory)CategoryComboBox.SelectedItem);
            }
            else
            {
                _currentDisplayedNotes = _project.LastChangeTimeSort();
            }

            FillNoteListBox();

            if (CategoryComboBox.SelectedItem != null && CategoryComboBox.SelectedItem != "All")
            {
                if (note.Category.Equals((NoteCategory)CategoryComboBox.SelectedItem))
                {
                    var currentNoteIndex = _currentDisplayedNotes.IndexOf(note);
                    NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
                }
                else
                {
                    if (NotesListBox.Items.Count > 0)
                    {
                        NotesListBox.SelectedItem = NotesListBox.Items[0];
                    }
                    else
                    {
                        _project.CurrentNote = null;
                        ClearAllFields();
                    }
                }
            }
            else
            {
                NotesListBox.SelectedItem = NotesListBox.Items[0];
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var inner = new AboutForm();
            inner.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Do you really want to remove this note: {NotesListBox.SelectedItem}",
                "Remove Note",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                var selectedIndex = NotesListBox.SelectedIndex;
                var selectedNote = _currentDisplayedNotes[selectedIndex];
                var realIndexInProject = _project.Notes.IndexOf(selectedNote);

                var copyNote = (Note)selectedNote.Clone();

                _project.Notes.RemoveAt(realIndexInProject);
                
                if (CategoryComboBox.SelectedItem != null && CategoryComboBox.SelectedItem != "All")
                {
                    _currentDisplayedNotes = _project.LastChangeTimeSortWithCategory(
                        (NoteCategory)CategoryComboBox.SelectedItem);
                }
                else
                {
                    _currentDisplayedNotes = _project.LastChangeTimeSort();
                }

                FillNoteListBox();

                if (NotesListBox.Items.Count > 0)
                {
                    NotesListBox.SelectedItem = NotesListBox.Items[0];
                }
                else
                {
                    _project.CurrentNote = null;
                    ClearAllFields();
                }

                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            }
        }

        private void ExitMenuStrip_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            this.Close();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem == "All")
            {
                _currentDisplayedNotes = _project.LastChangeTimeSort();
            }
            else
            {
                _currentDisplayedNotes = _project.LastChangeTimeSortWithCategory(
                    (NoteCategory)CategoryComboBox.SelectedIndex);
            }

            NotesListBox.Items.Clear();
            
            foreach (var note in _currentDisplayedNotes)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }

        private void ClearAllFields()
        {
            NoteTitleTextBox.Clear();
            CategoryTextBox.Clear();
            CreatedDatePicker.Text = DateTime.Now.ToString();
            ModifiedDatePicker.Text = DateTime.Now.ToString();
            NoteContentTextBox.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //todo ИЗМЕНЕНИЕ РАЗМЕРОВ
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoteContentTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}