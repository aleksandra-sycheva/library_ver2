using library_ver2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace library_ver2
{
    public partial class FormOrders : Form
    {
        public Models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private BookLoan selectedBookLoan;

        public FormOrders(Models.User user, bool quest, string currentRole)
        {
            InitializeComponent();

            dataGridViewHistory.AutoGenerateColumns = false;
            dataGridViewHistory.RowHeadersVisible = false;
            dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var colUserBook = new DataGridViewTextBoxColumn();
            colUserBook.Name = "colUserBook";
            colUserBook.FillWeight = 20;
            colUserBook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDateOfIssue = new DataGridViewTextBoxColumn();
            colDateOfIssue.Name = "colDateOfIssue";
            colDateOfIssue.FillWeight = 50;
            colDateOfIssue.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colPlannedReturnDate = new DataGridViewTextBoxColumn();
            colPlannedReturnDate.Name = "colPlannedReturnDate";
            colPlannedReturnDate.FillWeight = 50;
            colPlannedReturnDate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colActualReturnDate = new DataGridViewTextBoxColumn();
            colActualReturnDate.Name = "colActualReturnDate";
            colActualReturnDate.FillWeight = 50;
            colActualReturnDate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.FillWeight = 50;
            colStatus.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewHistory.Columns.AddRange(
            [
                colUserBook,
                colDateOfIssue,
                colPlannedReturnDate,
                colActualReturnDate,
                colStatus
            ]);

            CurrentUser = user;
            IsGuest = quest;

            if (currentRole == "Библиотекарь")
            {
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                panel.Visible = false;
                dataGridViewHistory.Dock = DockStyle.Fill;
            }

            dataGridViewHistory.Columns["colUserBook"].HeaderText = "Данные";
            dataGridViewHistory.Columns["colDateOfIssue"].HeaderText = "Дата выдачи";
            dataGridViewHistory.Columns["colPlannedReturnDate"].HeaderText = "Планируемая дата возвращения";
            dataGridViewHistory.Columns["colActualReturnDate"].HeaderText = "Фактическая дата возврата";
            dataGridViewHistory.Columns["colStatus"].HeaderText = "Статус";

            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var books = db.BookLoans
                        .Include(i => i.IdStatusNavigation)
                        .Include(i => i.IdBookNavigation)
                        .Include(i => i.IdUserNavigation)
                        .OrderBy(p => p.Id)
                        .ToList();

                    dataGridViewHistory.SuspendLayout();
                    dataGridViewHistory.Rows.Clear();
                    // Подключаем событие выделения строки
                    dataGridViewHistory.SelectionChanged += DataGridViewHistory_SelectionChanged;

                    foreach (var book in books)
                    {
                        int rowIndex = dataGridViewHistory.Rows.Add();
                        var row = dataGridViewHistory.Rows[rowIndex];

                        row.Cells["colUserBook"].Value = LoadUserBook(book);
                        row.Cells["colDateOfIssue"].Value = FormatDateOnly(book.DateOfIssue);
                        row.Cells["colPlannedReturnDate"].Value = FormatDateOnly(book.PlannedReturnDate);
                        row.Cells["colActualReturnDate"].Value = FormatDateOnly(book.ActualReturnDate);
                        row.Cells["colStatus"].Value = $"{book.IdStatusNavigation.StatusName}";
                        row.Tag = book;

                        // Подсветка просроченных книг (книга выдана более 30 дней назад и еще не возвращена)
                        if (book.ActualReturnDate == null)
                        {
                            // Получаем дату выдачи (DateOnly не nullable, поэтому просто используем)
                            DateTime dateOfIssue = book.DateOfIssue.ToDateTime(TimeOnly.MinValue);
                            TimeSpan daysSinceIssue = DateTime.Now.Date - dateOfIssue;

                            if (daysSinceIssue.TotalDays > 30)
                            {
                                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA"); // #D4EDDA
                            }
                        }
                    }

                    dataGridViewHistory.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательный метод для форматирования DateOnly
        private string FormatDateOnly(DateOnly date)
        {
            return date.ToString("dd.MM.yyyy");
        }

        // Вспомогательный метод для форматирования nullable DateOnly
        private string FormatDateOnly(DateOnly? date)
        {
            return date.HasValue ? date.Value.ToString("dd.MM.yyyy") : "";
        }

        private void DataGridViewHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewHistory.SelectedRows.Count > 0)
            {
                selectedBookLoan = dataGridViewHistory.SelectedRows[0].Tag as BookLoan;
            }
            else
            {
                selectedBookLoan = null;
            }
        }

        private string LoadUserBook(BookLoan bookLoan)
        {
            return $"Читатель: {bookLoan.IdUserNavigation.LastName} {bookLoan.IdUserNavigation.FirstName} {bookLoan.IdUserNavigation.MiddleName}" + Environment.NewLine +
                $"Книга: {bookLoan.IdBookNavigation.BookName}";
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            FormCreateOrUpdateOrders createForm = new FormCreateOrUpdateOrders(CurrentUser, IsGuest);
            createForm.ShowDialog();
            LoadHistory();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookLoan == null)
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            FormCreateOrUpdateOrders editForm = new FormCreateOrUpdateOrders(CurrentUser, IsGuest, selectedBookLoan);
            editForm.ShowDialog();
            LoadHistory();
        }
    }
}