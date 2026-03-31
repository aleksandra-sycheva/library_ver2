using library_ver2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace library_ver2
{
    public partial class FormReaderOrders : Form
    {
        private User _currentUser;

        public FormReaderOrders(User user)
        {
            InitializeComponent();
            _currentUser = user;
            ConfigureDataGridView();
            LoadOrders();
        }

        private void ConfigureDataGridView()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();

            var colBookName = new DataGridViewTextBoxColumn();
            colBookName.Name = "colBookName";
            colBookName.HeaderText = "Название книги";
            colBookName.DataPropertyName = "IdBookNavigation.BookName";
            colBookName.FillWeight = 50;

            var colDateOut = new DataGridViewTextBoxColumn();
            colDateOut.Name = "colDateOut";
            colDateOut.HeaderText = "Дата выдачи";
            colDateOut.DataPropertyName = "DateOut";
            colDateOut.DefaultCellStyle.Format = "dd.MM.yyyy";
            colDateOut.FillWeight = 20;

            var colReturnDate = new DataGridViewTextBoxColumn();
            colReturnDate.Name = "colReturnDate";
            colReturnDate.HeaderText = "Дата возврата";
            colReturnDate.DataPropertyName = "ReturnDate";
            colReturnDate.DefaultCellStyle.Format = "dd.MM.yyyy";
            colReturnDate.FillWeight = 20;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.FillWeight = 10;

            dgvOrders.Columns.AddRange(colBookName, colDateOut, colReturnDate, colStatus);
        }

        private void LoadOrders()
        {
            using (var db = new LibraryContext())
            {
                var orders = db.Orders
                    .Include(o => o.IdBookNavigation)
                    .Where(o => o.IdReader == _currentUser.Id)
                    .OrderByDescending(o => o.DateOut)
                    .ToList();

                dgvOrders.Rows.Clear();
                foreach (var order in orders)
                {
                    int rowIndex = dgvOrders.Rows.Add();
                    var row = dgvOrders.Rows[rowIndex];
                    row.Tag = order;

                    row.Cells["colBookName"].Value = order.IdBookNavigation?.BookName;

                    // Исправлено: DateOut - это DateTime, а не DateTime?
                    row.Cells["colDateOut"].Value = order.DateOut.ToString("dd.MM.yyyy");

                    // ReturnDate может быть null, поэтому используем тернарный оператор
                    row.Cells["colReturnDate"].Value = order.ReturnDate.HasValue
                        ? order.ReturnDate.Value.ToString("dd.MM.yyyy")
                        : "—";

                    // Определяем статус заказа
                    if (order.ReturnDate.HasValue)
                    {
                        row.Cells["colStatus"].Value = "Возвращена";
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E8F5E9");
                    }
                    else if (order.DateOut != default(DateTime))
                    {
                        row.Cells["colStatus"].Value = "На руках";
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF3CD");
                    }
                    else
                    {
                        row.Cells["colStatus"].Value = "Ожидает выдачи";
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E3F2FD");
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