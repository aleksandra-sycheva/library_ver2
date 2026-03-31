namespace library_ver2
{
    partial class FormManageOrders
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
            panelTop = new Panel();
            btnRefresh = new Button();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            btnSearch = new Button();
            labelTitle = new Label();
            buttonClose = new Button();
            dgvManageOrders = new DataGridView();
            panelButtons = new Panel();
            btnReturn = new Button();
            btnReject = new Button();
            btnApprove = new Button();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageOrders).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.AliceBlue;
            panelTop.Controls.Add(buttonClose);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(labelStatus);
            panelTop.Controls.Add(comboBoxStatus);
            panelTop.Controls.Add(labelSearch);
            panelTop.Controls.Add(textBoxSearch);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(labelTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 70);
            panelTop.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(74, 111, 165);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(290, 31);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Управление заказами";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(74, 111, 165);
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(831, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(169, 70);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Times New Roman", 12F);
            labelSearch.ForeColor = Color.FromArgb(74, 111, 165);
            labelSearch.Location = new Point(330, 24);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(82, 23);
            labelSearch.TabIndex = 4;
            labelSearch.Text = "Поиск:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Font = new Font("Times New Roman", 12F);
            textBoxSearch.Location = new Point(420, 21);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(180, 30);
            textBoxSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(74, 111, 165);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 32);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Font = new Font("Times New Roman", 12F);
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Все", "На руках", "Возвращена" });
            comboBoxStatus.Location = new Point(760, 21);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(130, 31);
            comboBoxStatus.TabIndex = 2;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Times New Roman", 12F);
            labelStatus.ForeColor = Color.FromArgb(74, 111, 165);
            labelStatus.Location = new Point(700, 24);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(60, 23);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Статус:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.LightGray;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(700, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 32);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvManageOrders
            // 
            dgvManageOrders.AllowUserToAddRows = false;
            dgvManageOrders.AllowUserToDeleteRows = false;
            dgvManageOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManageOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManageOrders.BackgroundColor = Color.White;
            dgvManageOrders.BorderStyle = BorderStyle.None;
            dgvManageOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageOrders.Location = new Point(12, 80);
            dgvManageOrders.Name = "dgvManageOrders";
            dgvManageOrders.ReadOnly = true;
            dgvManageOrders.RowHeadersVisible = false;
            dgvManageOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManageOrders.Size = new Size(976, 380);
            dgvManageOrders.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelButtons.Controls.Add(btnReturn);
            panelButtons.Controls.Add(btnReject);
            panelButtons.Controls.Add(btnApprove);
            panelButtons.Location = new Point(600, 470);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(388, 50);
            panelButtons.TabIndex = 2;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(255, 193, 7);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(270, 5);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(110, 40);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Вернуть";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.FromArgb(220, 53, 69);
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(140, 5);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(110, 40);
            btnReject.TabIndex = 1;
            btnReject.Text = "Отклонить";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.FromArgb(40, 167, 69);
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(10, 5);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(110, 40);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "Одобрить";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // FormManageOrders
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 530);
            Controls.Add(panelButtons);
            Controls.Add(dgvManageOrders);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormManageOrders";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление заказами";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageOrders).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Button btnRefresh;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private Button btnSearch;
        private Label labelTitle;
        private Button buttonClose;
        private DataGridView dgvManageOrders;
        private Panel panelButtons;
        private Button btnReturn;
        private Button btnReject;
        private Button btnApprove;
    }
}