using System.Drawing.Printing;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace library_ver2
{
    partial class FormBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonCreate = new Button();
            buttonOrders = new Button();
            labelFullName = new Label();
            buttonLogout = new Button();
            panelSearchFilter = new Panel();
            labelRecordsCount = new Label();
            buttonResetFilters = new Button();
            comboBoxPublisherFilter = new ComboBox();
            comboBoxSort = new ComboBox();
            textBoxSearch = new TextBox();
            labelSearch = new Label();
            labelSort = new Label();
            labelFilter = new Label();
            dataGridViewBook = new DataGridView();
            panel1.SuspendLayout();
            panelSearchFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(buttonUpdate);
            panel1.Controls.Add(buttonCreate);
            panel1.Controls.Add(buttonOrders);
            panel1.Controls.Add(labelFullName);
            panel1.Controls.Add(buttonLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 50);
            panel1.TabIndex = 0;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(74, 111, 165);
            buttonDelete.Dock = DockStyle.Left;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(338, 0);
            buttonDelete.Margin = new Padding(12, 3, 2, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(114, 50);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить книгу";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonUpdate.Dock = DockStyle.Left;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(212, 0);
            buttonUpdate.Margin = new Padding(12, 3, 2, 3);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(126, 50);
            buttonUpdate.TabIndex = 4;
            buttonUpdate.Text = "Редактировать книгу";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreate.Dock = DockStyle.Left;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(106, 0);
            buttonCreate.Margin = new Padding(12, 3, 2, 3);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(106, 50);
            buttonCreate.TabIndex = 3;
            buttonCreate.Text = "Добавить книгу";
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonOrders
            // 
            buttonOrders.BackColor = Color.FromArgb(74, 111, 165);
            buttonOrders.Dock = DockStyle.Left;
            buttonOrders.FlatStyle = FlatStyle.Flat;
            buttonOrders.ForeColor = Color.White;
            buttonOrders.Location = new Point(0, 0);
            buttonOrders.Margin = new Padding(2, 3, 2, 3);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(106, 50);
            buttonOrders.TabIndex = 2;
            buttonOrders.Text = "Посмотреть \r\nзаказы книг";
            buttonOrders.UseVisualStyleBackColor = false;
            buttonOrders.Click += buttonOrders_Click;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Dock = DockStyle.Right;
            labelFullName.ForeColor = Color.FromArgb(74, 111, 165);
            labelFullName.Location = new Point(741, 0);
            labelFullName.Margin = new Padding(2, 0, 2, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(51, 19);
            labelFullName.TabIndex = 1;
            labelFullName.Text = "label1";
            labelFullName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(74, 111, 165);
            buttonLogout.Dock = DockStyle.Right;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(792, 0);
            buttonLogout.Margin = new Padding(2, 3, 2, 3);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(138, 50);
            buttonLogout.TabIndex = 0;
            buttonLogout.Text = "Выход";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // panelSearchFilter
            // 
            panelSearchFilter.BackColor = Color.FromArgb(240, 248, 255);
            panelSearchFilter.Controls.Add(labelRecordsCount);
            panelSearchFilter.Controls.Add(buttonResetFilters);
            panelSearchFilter.Controls.Add(comboBoxPublisherFilter);
            panelSearchFilter.Controls.Add(comboBoxSort);
            panelSearchFilter.Controls.Add(textBoxSearch);
            panelSearchFilter.Controls.Add(labelSearch);
            panelSearchFilter.Controls.Add(labelSort);
            panelSearchFilter.Controls.Add(labelFilter);
            panelSearchFilter.Dock = DockStyle.Top;
            panelSearchFilter.Location = new Point(0, 50);
            panelSearchFilter.Margin = new Padding(2, 3, 2, 3);
            panelSearchFilter.Name = "panelSearchFilter";
            panelSearchFilter.Size = new Size(930, 68);
            panelSearchFilter.TabIndex = 2;
            panelSearchFilter.Visible = false;
            // 
            // labelRecordsCount
            // 
            labelRecordsCount.AutoSize = true;
            labelRecordsCount.ForeColor = Color.Gray;
            labelRecordsCount.Location = new Point(10, 42);
            labelRecordsCount.Margin = new Padding(2, 0, 2, 0);
            labelRecordsCount.Name = "labelRecordsCount";
            labelRecordsCount.Size = new Size(0, 19);
            labelRecordsCount.TabIndex = 7;
            // 
            // buttonResetFilters
            // 
            buttonResetFilters.BackColor = Color.FromArgb(74, 111, 165);
            buttonResetFilters.FlatStyle = FlatStyle.Flat;
            buttonResetFilters.ForeColor = Color.White;
            buttonResetFilters.Location = new Point(784, 11);
            buttonResetFilters.Margin = new Padding(2, 3, 2, 3);
            buttonResetFilters.Name = "buttonResetFilters";
            buttonResetFilters.Size = new Size(82, 28);
            buttonResetFilters.TabIndex = 6;
            buttonResetFilters.Text = "Сброс";
            buttonResetFilters.UseVisualStyleBackColor = false;
            // 
            // comboBoxPublisherFilter
            // 
            comboBoxPublisherFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPublisherFilter.FormattingEnabled = true;
            comboBoxPublisherFilter.Location = new Point(616, 13);
            comboBoxPublisherFilter.Margin = new Padding(2, 3, 2, 3);
            comboBoxPublisherFilter.Name = "comboBoxPublisherFilter";
            comboBoxPublisherFilter.Size = new Size(165, 27);
            comboBoxPublisherFilter.TabIndex = 5;
            // 
            // comboBoxSort
            // 
            comboBoxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Location = new Point(341, 13);
            comboBoxSort.Margin = new Padding(2, 3, 2, 3);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(181, 27);
            comboBoxSort.TabIndex = 3;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(72, 13);
            textBoxSearch.Margin = new Padding(2, 3, 2, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(165, 27);
            textBoxSearch.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(10, 17);
            labelSearch.Margin = new Padding(2, 0, 2, 0);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(59, 19);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Поиск:";
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Location = new Point(241, 17);
            labelSort.Margin = new Padding(2, 0, 2, 0);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(97, 19);
            labelSort.TabIndex = 2;
            labelSort.Text = "Сортировка:";
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(536, 17);
            labelFilter.Margin = new Padding(2, 0, 2, 0);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(80, 19);
            labelFilter.TabIndex = 4;
            labelFilter.Text = "Издатель:";
            // 
            // dataGridViewBook
            // 
            dataGridViewBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewBook.BackgroundColor = Color.White;
            dataGridViewBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBook.Dock = DockStyle.Fill;
            dataGridViewBook.Location = new Point(0, 118);
            dataGridViewBook.Margin = new Padding(2, 3, 2, 3);
            dataGridViewBook.Name = "dataGridViewBook";
            dataGridViewBook.RowHeadersWidth = 51;
            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.Size = new Size(930, 466);
            dataGridViewBook.TabIndex = 1;
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(930, 584);
            Controls.Add(dataGridViewBook);
            Controls.Add(panelSearchFilter);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "FormBooks";
            Text = "Библиотека";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelSearchFilter.ResumeLayout(false);
            panelSearchFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelFullName;
        private Button buttonLogout;
        private Button buttonOrders;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private DataGridView dataGridViewBook;
        private Panel panelSearchFilter;
        private Label labelRecordsCount;
        private Button buttonResetFilters;
        private ComboBox comboBoxPublisherFilter;
        private ComboBox comboBoxSort;
        private TextBox textBoxSearch;
        private Label labelSearch;
        private Label labelSort;
        private Label labelFilter;
    }
}