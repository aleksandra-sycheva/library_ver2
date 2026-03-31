using library_ver2.Properties;
using library_ver2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace library_ver2
{
    public partial class FormBooks : Form
    {
        public Models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private string currentUserRole;
        private Book selectedBook;

        public FormBooks(Models.User user, bool quest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            labelFullName.Text = IsGuest ? "Гость" : $"{CurrentUser.LastName} {CurrentUser.FirstName} {CurrentUser.MiddleName}";

            dataGridViewBook.AutoGenerateColumns = false;
            dataGridViewBook.RowHeadersVisible = false;

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 20;

            var colInfoBook = new DataGridViewTextBoxColumn();
            colInfoBook.Name = "colInfoBook";
            colInfoBook.FillWeight = 60;
            colInfoBook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoBook.DefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            colInfoBook.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            var colInfoCount = new DataGridViewTextBoxColumn();
            colInfoCount.Name = "colInfoCount";
            colInfoCount.FillWeight = 20;
            colInfoCount.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoCount.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoCount.DefaultCellStyle.Padding = new Padding(5);

            dataGridViewBook.Columns.AddRange(colPhoto, colInfoBook, colInfoCount);
            dataGridViewBook.ColumnHeadersVisible = false;

            // Загружаем роль пользователя, если это не гость
            if (!IsGuest && CurrentUser != null)
            {
                using (var db = new LibraryContext())
                {
                    var userWithRole = db.Users
                        .Include(u => u.IdRoleNavigation)
                        .FirstOrDefault(u => u.Id == CurrentUser.Id);

                    if (userWithRole != null)
                    {
                        currentUserRole = userWithRole.IdRoleNavigation?.RoleName ?? "Читатель";
                        CurrentUser = userWithRole; // Обновляем CurrentUser с загруженной ролью
                    }
                    else
                    {
                        currentUserRole = "Читатель";
                    }
                }
            }

            bool isAdminManager = !IsGuest && (currentUserRole == "Менеджер" || currentUserRole == "Администратор");
            bool isAdminOnly = !IsGuest && currentUserRole == "Администратор";

            // Configure visibility based on role
            if (IsGuest)
            {
                buttonOrders.Visible = false;
                txtSearch.Visible = false;
                cmbSort.Visible = false;
                cmbPublisherFilter.Visible = false;
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
            }

            if (!isAdminManager && !IsGuest)
            {
                // Reader role - only orders button visible
                txtSearch.Visible = false;
                cmbSort.Visible = false;
                cmbPublisherFilter.Visible = false;
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
                buttonOrders.Visible = true;
                buttonOrders.Text = "Мои заказы";
            }

            if (isAdminManager)
            {
                // Librarian and Admin - show search/filter/sort
                txtSearch.Visible = true;
                cmbSort.Visible = true;
                cmbPublisherFilter.Visible = true;
                buttonOrders.Visible = true;
                buttonOrders.Text = "Управление выдачей книг";
            }

            if (isAdminOnly)
            {
                // Admin - show all buttons
                buttonCreate.Visible = true;
                buttonUpdate.Visible = true;
                buttonDelete.Visible = true;
            }

            ConfigureDgvProducts();

            // Init admin tools
            cmbSort.Items.AddRange(new object[] { "По ID (возр.)", "Запас (возр.)", "Запас (убыв.)" });
            cmbSort.SelectedIndex = 0;
            LoadPublishers();

            LoadBooksSortedFiltered();
            HookEvents();

            // Attach button click events
            buttonOrders.Click += ButtonOrders_Click;
            buttonCreate.Click += ButtonCreate_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
            buttonDelete.Click += ButtonDelete_Click;
        }

        private void HookEvents()
        {
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cmbPublisherFilter.SelectedIndexChanged += CmbPublisher_SelectedIndexChanged;
            cmbSort.SelectedIndexChanged += CmbSort_SelectedIndexChanged;
            dataGridViewBook.SelectionChanged += DgvProducts_SelectionChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooksSortedFiltered();
        }

        private void CmbPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBooksSortedFiltered();
        }

        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBooksSortedFiltered();
        }

        private void LoadPublishers()
        {
            using (var db = new LibraryContext())
            {
                cmbPublisherFilter.Items.Clear();
                cmbPublisherFilter.Items.Add("Все издательства");
                var pubs = db.Publishers.OrderBy(p => p.PublisherName).ToList();
                foreach (var p in pubs)
                {
                    cmbPublisherFilter.Items.Add(p);
                }
                cmbPublisherFilter.SelectedIndex = 0;
            }
        }

        private void LoadBooksSortedFiltered()
        {
            string searchStr = txtSearch.Text.ToLower();
            int sortIdx = cmbSort.SelectedIndex;
            object selectedPubObj = cmbPublisherFilter.SelectedItem;
            int? pubId = null;
            if (selectedPubObj is Publisher p && p != null)
            {
                pubId = p.Id;
            }

            try
            {
                using (var db = new LibraryContext())
                {
                    var query = db.Books
                        .Include(b => b.IdAuthorNavigation)
                        .Include(b => b.IdGenreNavigation)
                        .Include(b => b.IdPublisherNavigation)
                        .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(searchStr))
                    {
                        query = query.Where(b =>
                            b.Isbn.ToLower().Contains(searchStr) ||
                            b.BookName.ToLower().Contains(searchStr) ||
                            b.Annotation.ToLower().Contains(searchStr) ||
                            b.IdAuthorNavigation.AuthorName.ToLower().Contains(searchStr) ||
                            b.IdGenreNavigation.GenreName.ToLower().Contains(searchStr) ||
                            b.IdPublisherNavigation.PublisherName.ToLower().Contains(searchStr)
                        );
                    }

                    if (pubId.HasValue)
                    {
                        query = query.Where(b => b.IdPublisher == pubId.Value);
                    }

                    switch (sortIdx)
                    {
                        case 1:
                            query = query.OrderBy(b => b.Avaiable);
                            break;
                        case 2:
                            query = query.OrderByDescending(b => b.Avaiable);
                            break;
                        default:
                            query = query.OrderBy(b => b.Id);
                            break;
                    }

                    var books = query.ToList();
                    dataGridViewBook.SuspendLayout();
                    dataGridViewBook.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dataGridViewBook.Rows.Add();
                        var row = dataGridViewBook.Rows[rowIndex];
                        row.Tag = book;
                        row.Cells["colPhoto"].Value = LoadProductImage(book.PhotoUrl);
                        row.Cells["colInfoBook"].Value = FormatBookInfo(book);
                        row.Cells["colInfoCount"].Value = $"{book.Total} / {book.Avaiable}";

                        if (book.Avaiable == 0)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
                        }
                        else if (book.Avaiable == 1 || book.Avaiable == 2)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        }
                    }

                    dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridViewBook.ResumeLayout();
                    dataGridViewBook.ClearSelection();
                    selectedBook = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDgvProducts()
        {
            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.MultiSelect = false;
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count > 0)
            {
                selectedBook = dataGridViewBook.SelectedRows[0].Tag as Book;
            }
            else
            {
                selectedBook = null;
            }
        }

        private string FormatBookInfo(Book book)
        {
            return $"{book.Isbn} | {book.BookName}" + Environment.NewLine +
                $"Автор: {book.IdAuthorNavigation.AuthorName}" + Environment.NewLine +
                $"Жанр: {book.IdGenreNavigation.GenreName}" + Environment.NewLine +
                $"Издатель: {book.IdPublisherNavigation.PublisherName}" + Environment.NewLine +
                $"Год: {book.Year}" + Environment.NewLine +
                $"Страниц: {book.Pages}" + Environment.NewLine +
                $"Аннотация: {book.Annotation}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!string.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }
            return Resources.book_placeholder;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Book management methods for Admin
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var addBookForm = new FormAddEditBook();
            if (addBookForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooksSortedFiltered();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBook != null)
            {
                var editBookForm = new FormAddEditBook(selectedBook);
                if (editBookForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooksSortedFiltered();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (selectedBook != null)
            {
                // Check if book has any active orders
                using (var db = new LibraryContext())
                {
                    var hasActiveOrders = db.Orders.Any(o => o.IdBook == selectedBook.Id && o.ReturnDate == null);
                    if (hasActiveOrders)
                    {
                        MessageBox.Show("Нельзя удалить книгу, которая находится на руках у читателей",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show($"Удалить книгу \"{selectedBook.BookName}\"?",
                    "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    using (var db = new LibraryContext())
                    {
                        db.Books.Remove(selectedBook);
                        db.SaveChanges();
                    }
                    LoadBooksSortedFiltered();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Orders management
        private void ButtonOrders_Click(object sender, EventArgs e)
        {
            if (IsGuest)
            {
                MessageBox.Show("Гостям недоступен просмотр заказов", "Доступ запрещен",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentUserRole == "Читатель")
            {
                // Reader - show their own orders history
                var ordersForm = new FormReaderOrders(CurrentUser);
                ordersForm.ShowDialog();
            }
            else if (currentUserRole == "Менеджер" || currentUserRole == "Администратор")
            {
                // Librarian/Admin - show order management form
                var manageOrdersForm = new FormManageOrders(CurrentUser);
                manageOrdersForm.ShowDialog();
                LoadBooksSortedFiltered(); // Refresh to update available counts
            }
        }
    }
}