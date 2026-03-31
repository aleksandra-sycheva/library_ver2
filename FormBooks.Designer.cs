namespace library_ver2
{
    partial class FormBooks
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonCreate = new Button();
            buttonOrders = new Button();
            labelFullName = new Label();
            buttonLogout = new Button();
            labelSearch = new Label();
            txtSearch = new TextBox();
            labelPublisher = new Label();
            cmbPublisherFilter = new ComboBox();
            labelSort = new Label();
            cmbSort = new ComboBox();
            dataGridViewBook = new DataGridView();
            panel1.SuspendLayout();
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
            panel1.Controls.Add(labelSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(labelPublisher);
            panel1.Controls.Add(cmbPublisherFilter);
            panel1.Controls.Add(labelSort);
            panel1.Controls.Add(cmbSort);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 70);
            panel1.TabIndex = 0;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(74, 111, 165);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(500, 10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(120, 50);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить книгу";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(370, 10);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(120, 50);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Редактировать";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(240, 10);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(120, 50);
            buttonCreate.TabIndex = 9;
            buttonCreate.Text = "Добавить книгу";
            buttonCreate.UseVisualStyleBackColor = false;
            // 
            // buttonOrders
            // 
            buttonOrders.BackColor = Color.FromArgb(74, 111, 165);
            buttonOrders.FlatStyle = FlatStyle.Flat;
            buttonOrders.ForeColor = Color.White;
            buttonOrders.Location = new Point(110, 10);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(120, 50);
            buttonOrders.TabIndex = 8;
            buttonOrders.Text = "Заказы";
            buttonOrders.UseVisualStyleBackColor = false;
            // 
            // labelFullName
            // 
            labelFullName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFullName.AutoSize = true;
            labelFullName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            labelFullName.ForeColor = Color.FromArgb(74, 111, 165);
            labelFullName.Location = new Point(900, 25);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(60, 23);
            labelFullName.TabIndex = 7;
            labelFullName.Text = "User";
            labelFullName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLogout.BackColor = Color.FromArgb(220, 53, 69);
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(1080, 10);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(100, 50);
            buttonLogout.TabIndex = 6;
            buttonLogout.Text = "Выход";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            labelSearch.ForeColor = Color.FromArgb(74, 111, 165);
            labelSearch.Location = new Point(12, 15);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(60, 20);
            labelSearch.TabIndex = 5;
            labelSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Times New Roman", 11F);
            txtSearch.Location = new Point(12, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Название, автор, ISBN...";
            txtSearch.Size = new Size(220, 28);
            txtSearch.TabIndex = 4;
            // 
            // labelPublisher
            // 
            labelPublisher.AutoSize = true;
            labelPublisher.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            labelPublisher.ForeColor = Color.FromArgb(74, 111, 165);
            labelPublisher.Location = new Point(250, 15);
            labelPublisher.Name = "labelPublisher";
            labelPublisher.Size = new Size(96, 20);
            labelPublisher.TabIndex = 3;
            labelPublisher.Text = "Издательство:";
            // 
            // cmbPublisherFilter
            // 
            cmbPublisherFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPublisherFilter.Font = new Font("Times New Roman", 11F);
            cmbPublisherFilter.Location = new Point(250, 38);
            cmbPublisherFilter.Name = "cmbPublisherFilter";
            cmbPublisherFilter.Size = new Size(180, 29);
            cmbPublisherFilter.TabIndex = 2;
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            labelSort.ForeColor = Color.FromArgb(74, 111, 165);
            labelSort.Location = new Point(448, 15);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(80, 20);
            labelSort.TabIndex = 1;
            labelSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Font = new Font("Times New Roman", 11F);
            cmbSort.Location = new Point(448, 38);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(160, 29);
            cmbSort.TabIndex = 0;
            // 
            // dataGridViewBook
            // 
            dataGridViewBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewBook.BackgroundColor = Color.White;
            dataGridViewBook.BorderStyle = BorderStyle.None;
            dataGridViewBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBook.Dock = DockStyle.Fill;
            dataGridViewBook.Location = new Point(0, 70);
            dataGridViewBook.Name = "dataGridViewBook";
            dataGridViewBook.RowHeadersVisible = false;
            dataGridViewBook.RowHeadersWidth = 51;
            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.Size = new Size(1200, 600);
            dataGridViewBook.TabIndex = 2;
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 670);
            Controls.Add(dataGridViewBook);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            MinimizeBox = false;
            Name = "FormBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Библиотека";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Label labelFullName;
        private Button buttonLogout;
        private Button buttonOrders;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private DataGridView dataGridViewBook;
        private Label labelSearch;
        private TextBox txtSearch;
        private Label labelPublisher;
        private ComboBox cmbPublisherFilter;
        private Label labelSort;
        private ComboBox cmbSort;
    }
}