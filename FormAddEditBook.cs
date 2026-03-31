using library_ver2.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace library_ver2
{
    public partial class FormAddEditBook : Form
    {
        private Book _editingBook;
        private bool _isEditMode;

        public FormAddEditBook(Book book = null)
        {
            InitializeComponent();
            _editingBook = book;
            _isEditMode = book != null;

            LoadComboBoxes();

            if (_isEditMode)
            {
                Text = "Редактирование книги";
                LoadBookData();
            }
            else
            {
                Text = "Добавление книги";
            }
        }

        private void LoadComboBoxes()
        {
            using (var db = new LibraryContext())
            {
                cmbAuthor.DataSource = db.Authors.OrderBy(a => a.AuthorName).ToList();
                cmbAuthor.DisplayMember = "AuthorName";
                cmbAuthor.ValueMember = "Id";

                cmbGenre.DataSource = db.Genres.OrderBy(g => g.GenreName).ToList();
                cmbGenre.DisplayMember = "GenreName";
                cmbGenre.ValueMember = "Id";

                cmbPublisher.DataSource = db.Publishers.OrderBy(p => p.PublisherName).ToList();
                cmbPublisher.DisplayMember = "PublisherName";
                cmbPublisher.ValueMember = "Id";
            }
        }

        private void LoadBookData()
        {
            txtISBN.Text = _editingBook.Isbn;
            txtBookName.Text = _editingBook.BookName;
            cmbAuthor.SelectedValue = _editingBook.IdAuthor;
            cmbGenre.SelectedValue = _editingBook.IdGenre;
            cmbPublisher.SelectedValue = _editingBook.IdPublisher;
            numYear.Value = _editingBook.Year;
            numPages.Value = _editingBook.Pages;
            txtAnnotation.Text = _editingBook.Annotation;
            numTotal.Value = _editingBook.Total;
            numAvailable.Value = _editingBook.Avaiable;
            txtPhotoUrl.Text = _editingBook.PhotoUrl;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Выберите изображение книги";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPhotoUrl.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            using (var db = new LibraryContext())
            {
                if (_isEditMode)
                {
                    var book = db.Books.Find(_editingBook.Id);
                    UpdateBook(book);
                    db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    var book = new Book();
                    UpdateBook(book);
                    db.Books.Add(book);
                }
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateBook(Book book)
        {
            book.Isbn = txtISBN.Text;
            book.BookName = txtBookName.Text;
            book.IdAuthor = (int)cmbAuthor.SelectedValue;
            book.IdGenre = (int)cmbGenre.SelectedValue;
            book.IdPublisher = (int)cmbPublisher.SelectedValue;
            book.Year = (int)numYear.Value;
            book.Pages = (int)numPages.Value;
            book.Annotation = txtAnnotation.Text;
            book.Total = (int)numTotal.Value;
            book.Avaiable = (int)numAvailable.Value;
            book.PhotoUrl = txtPhotoUrl.Text;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Введите ISBN", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBookName.Text))
            {
                MessageBox.Show("Введите название книги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numAvailable.Value > numTotal.Value)
            {
                MessageBox.Show("Доступное количество не может превышать общее количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}