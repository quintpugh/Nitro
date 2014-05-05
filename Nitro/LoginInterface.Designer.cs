namespace Login
{
    partial class LoginInterface
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
            this.comboBox_userType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_loginError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_userType
            // 
            this.comboBox_userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_userType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_userType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_userType.FormattingEnabled = true;
            this.comboBox_userType.Items.AddRange(new object[] {
            "Student",
            "Teacher",
            "Database Administrator"});
            this.comboBox_userType.Location = new System.Drawing.Point(135, 65);
            this.comboBox_userType.Name = "comboBox_userType";
            this.comboBox_userType.Size = new System.Drawing.Size(257, 33);
            this.comboBox_userType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Type:";
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username.Location = new System.Drawing.Point(135, 104);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(257, 32);
            this.textBox_username.TabIndex = 1;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.Location = new System.Drawing.Point(145, 219);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(95, 40);
            this.button_login.TabIndex = 3;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // textbox_password
            // 
            this.textbox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password.Location = new System.Drawing.Point(135, 142);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(257, 32);
            this.textbox_password.TabIndex = 2;
            this.textbox_password.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Welcome to TurboType!";
            // 
            // label_loginError
            // 
            this.label_loginError.AutoSize = true;
            this.label_loginError.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_loginError.ForeColor = System.Drawing.Color.Red;
            this.label_loginError.Location = new System.Drawing.Point(12, 175);
            this.label_loginError.Name = "label_loginError";
            this.label_loginError.Size = new System.Drawing.Size(0, 26);
            this.label_loginError.TabIndex = 11;
            // 
            // LoginInterface
            // 
            this.AcceptButton = this.button_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 271);
            this.Controls.Add(this.label_loginError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_userType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginInterface";
            this.Text = "TurboType Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_userType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_loginError;

    }
}

