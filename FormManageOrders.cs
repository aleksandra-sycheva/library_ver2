using library_ver2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace library_ver2
{
    public partial class FormManageOrders : Form
    {
        private User _currentUser;

        public FormManageOrders(User user)
        {
            InitializeComponent();
            _currentUser = user;
            ConfigureDataGridView();
            LoadOrders();
        }

        private void ConfigureDataGridView()
        {
            dgvManageOrders.AutoGenerateColumns = false;
            dgvManageOrders.Columns.Clear();

            var colReader = new DataGridViewTextBoxColumn();
            colReader.Name = "colReader";
            colReader.HeaderText = "Читатель";
            colReader.DataPropertyName = "IdReaderNavigation.FullName";
            colReader.FillWeight = 30;

            var colBook = new DataGridViewTextBoxColumn();
            colBook.Name = "colBook";
            colBook.HeaderText = "Книга";
            colBook.DataPropertyName = "IdBookNavigation.BookName";
            colBook.FillWeight = 40;

            var colDateOut = new DataGridViewTextBoxColumn();
            colDateOut.Name = "colDateOut";
            colDateOut.HeaderText = "Дата выдачи";
            colDateOut.DataPropertyName = "DateOut";
            colDateOut.DefaultCellStyle.Format = "dd.MM.yyyy";
            colDateOut.FillWeight = 15;

            var colReturnDate = new DataGridViewTextBoxColumn();
            colReturnDate.Name = "colReturnDate";
            colReturnDate.HeaderText = "Дата возврата";
            colReturnDate.DataPropertyName = "ReturnDate";
            colReturnDate.DefaultCellStyle.Format = "dd.MM.yyyy";
            colReturnDate.FillWeight = 15;

            dgvManageOrders.Columns.AddRange(colReader, colBook, colDateOut, colReturnDate);
        }

        private void LoadOrders()
        {
            using (var db = new LibraryContext())
            {
                var orders = db.Orders
                    .Include(o => o.IdBookNavigation)
                    .Include(o => o.IdReaderNavigation)
                    .OrderByDescending(o => o.DateOut)
                    .ToList();

                dgvManageOrders.Rows.Clear();
                foreach (var order in orders)
                {
                    int rowIndex = dgvManageOrders.Rows.Add();
                    var row = dgvManageOrders.Rows[rowIndex];
                    row.Tag = order;

                    string readerName = $"{order.IdReaderNavigation.LastName} {order.IdReaderNavigation.FirstName}";
                    row.Cells["colReader"].Value = readerName;
                    row.Cells["colBook"].Value = order.IdBookNavigation?.BookName;
                    row.Cells["colDateOut"].Value = order.DateOut;
                    row.Cells["colReturnDate"].Value = order.ReturnDate;

                    if (order.ReturnDate == null)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF3CD");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            string statusFilter = comboBoxStatus.SelectedItem?.ToString() ?? "Все";

            using (var db = new LibraryContext())
            {
                var orders = db.Orders
                    .Include(o => o.IdBookNavigation)
                    .Include(o => o.IdReaderNavigation)
                    .ToList();

                var filteredOrders = orders.Where(o =>
                {
                    bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                        o.IdReaderNavigation.LastName.ToLower().Contains(searchText) ||
                        o.IdReaderNavigation.FirstName.ToLower().Contains(searchText) ||
                        (o.IdBookNavigation != null && o.IdBookNavigation.BookName.ToLower().Contains(searchText));

                    bool matchesStatus = statusFilter == "Все" ||
                        (statusFilter == "На руках" && o.ReturnDate == null) ||
                        (statusFilter == "Возвращена" && o.ReturnDate != null);

                    return matchesSearch && matchesStatus;
                }).OrderByDescending(o => o.DateOut).ToList();

                dgvManageOrders.Rows.Clear();
                foreach (var order in filteredOrders)
                {
                    int rowIndex = dgvManageOrders.Rows.Add();
                    var row = dgvManageOrders.Rows[rowIndex];
                    row.Tag = order;

                    string readerName = $"{order.IdReaderNavigation.LastName} {order.IdReaderNavigation.FirstName}";
                    row.Cells["colReader"].Value = readerName;
                    row.Cells["colBook"].Value = order.IdBookNavigation?.BookName;
                    row.Cells["colDateOut"].Value = order.DateOut;
                    row.Cells["colReturnDate"].Value = order.ReturnDate;

                    if (order.ReturnDate == null)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF3CD");
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            comboBoxStatus.SelectedIndex = 0;
            LoadOrders();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция одобрения заказа", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция отклонения заказа", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvManageOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для возврата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Здесь важно: убедитесь, что Tag содержит объект именно того типа, который в БД (BookLoan или Order)
            // Судя по контексту ошибки, это BookLoan
            var selectedOrder = (BookLoan)dgvManageOrders.SelectedRows[0].Tag;

            if (selectedOrder.ActualReturnDate != null)
            {
                MessageBox.Show("Эта книга уже возвращена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Подтвердите возврат книги", "Возврат",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                using (var db = new LibraryContext())
                {
                    var loan = db.BookLoans.Find(selectedOrder.Id);
                    if (loan != null)
                    {
                        // Используем правильное имя свойства и конвертацию в DateOnly
                        loan.ActualReturnDate = DateOnly.FromDateTime(DateTime.Now);

                        var book = db.Books.Find(loan.IdBook);
                        if (book != null)
                        {
                            book.Avaiable++;
                        }

                        db.SaveChanges();
                        MessageBox.Show("Книга возвращена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}