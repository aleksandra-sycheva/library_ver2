using static System.Net.Mime.MediaTypeNames;

namespace library_ver2
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pblogo = new PictureBox();
            pnMain = new Panel();
            btnGuest = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lbPassword = new Label();
            txtLogin = new TextBox();
            lbLogin = new Label();
            ((System.ComponentModel.ISupportInitialize)pblogo).BeginInit();
            pnMain.SuspendLayout();
            SuspendLayout();
            // 
            // pblogo
            // 
            pblogo.Anchor = AnchorStyles.None;
            pblogo.Image = Properties.Resources.book_placeholder;
            pblogo.Location = new Point(161, 12);
            pblogo.Name = "pblogo";
            pblogo.Size = new Size(148, 145);
            pblogo.SizeMode = PictureBoxSizeMode.Zoom;
            pblogo.TabIndex = 0;
            pblogo.TabStop = false;
            // 
            // pnMain
            // 
            pnMain.Anchor = AnchorStyles.None;
            pnMain.Controls.Add(btnGuest);
            pnMain.Controls.Add(btnLogin);
            pnMain.Controls.Add(txtPassword);
            pnMain.Controls.Add(lbPassword);
            pnMain.Controls.Add(txtLogin);
            pnMain.Controls.Add(lbLogin);
            pnMain.Location = new Point(39, 173);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(402, 277);
            pnMain.TabIndex = 1;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.AliceBlue;
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Location = new Point(80, 218);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(242, 30);
            btnGuest.TabIndex = 5;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += BtnGuest_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(74, 111, 165);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(80, 176);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(242, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(53, 134);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(297, 30);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(165, 100);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(72, 22);
            lbPassword.TabIndex = 2;
            lbPassword.Text = "Пароль";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(53, 58);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(297, 30);
            txtLogin.TabIndex = 1;
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.Location = new Point(165, 24);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(64, 22);
            lbLogin.TabIndex = 0;
            lbLogin.Text = "Логин";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(471, 462);
            Controls.Add(pnMain);
            Controls.Add(pblogo);
            Font = new System.Drawing.Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ((System.ComponentModel.ISupportInitialize)pblogo).EndInit();
            pnMain.ResumeLayout(false);
            pnMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pblogo;
        private Panel pnMain;
        private Button btnGuest;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label lbPassword;
        private TextBox txtLogin;
        private Label lbLogin;
    }
}
