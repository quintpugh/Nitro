namespace Dba
{
    partial class DbaInterface
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
            this.panel_menu = new System.Windows.Forms.Panel();
            this.button_menu_dba = new System.Windows.Forms.Button();
            this.button_menu_teacher = new System.Windows.Forms.Button();
            this.button_menu_class = new System.Windows.Forms.Button();
            this.button_menu_logout = new System.Windows.Forms.Button();
            this.button_menu_account = new System.Windows.Forms.Button();
            this.panel_class = new System.Windows.Forms.Panel();
            this.comboBox_class_teacher = new System.Windows.Forms.ComboBox();
            this.label_class_menu = new System.Windows.Forms.Label();
            this.button_class_save = new System.Windows.Forms.Button();
            this.button_class_delete = new System.Windows.Forms.Button();
            this.button_class_reset = new System.Windows.Forms.Button();
            this.textBox_class_name = new System.Windows.Forms.TextBox();
            this.label_class_teacher = new System.Windows.Forms.Label();
            this.label_class_name = new System.Windows.Forms.Label();
            this.button_class_new = new System.Windows.Forms.Button();
            this.listBox_class = new System.Windows.Forms.ListBox();
            this.panel_teacher = new System.Windows.Forms.Panel();
            this.button_teacher_new = new System.Windows.Forms.Button();
            this.button_teacher_save = new System.Windows.Forms.Button();
            this.button_teacher_delete = new System.Windows.Forms.Button();
            this.button_teacher_reset = new System.Windows.Forms.Button();
            this.textbox_teacher_password = new System.Windows.Forms.TextBox();
            this.textbox_teacher_username = new System.Windows.Forms.TextBox();
            this.textbox_teacher_lName = new System.Windows.Forms.TextBox();
            this.textbox_teacher_fName = new System.Windows.Forms.TextBox();
            this.label_teacher_password = new System.Windows.Forms.Label();
            this.label_teacher_username = new System.Windows.Forms.Label();
            this.label_teacher_lName = new System.Windows.Forms.Label();
            this.label_teacher_fName = new System.Windows.Forms.Label();
            this.label_teacher_menu = new System.Windows.Forms.Label();
            this.listBox_teacher = new System.Windows.Forms.ListBox();
            this.panel_dba = new System.Windows.Forms.Panel();
            this.button_dba_new = new System.Windows.Forms.Button();
            this.button_dba_save = new System.Windows.Forms.Button();
            this.button_dba_delete = new System.Windows.Forms.Button();
            this.button_dba_reset = new System.Windows.Forms.Button();
            this.textBox_dba_password = new System.Windows.Forms.TextBox();
            this.textBox_dba_username = new System.Windows.Forms.TextBox();
            this.textBox_dba_lName = new System.Windows.Forms.TextBox();
            this.textBox_dba_fName = new System.Windows.Forms.TextBox();
            this.label_dba_password = new System.Windows.Forms.Label();
            this.label_dba_username = new System.Windows.Forms.Label();
            this.label_dba_lName = new System.Windows.Forms.Label();
            this.label_dba_fName = new System.Windows.Forms.Label();
            this.label_dba_name = new System.Windows.Forms.Label();
            this.listBox_dba = new System.Windows.Forms.ListBox();
            this.panel_account = new System.Windows.Forms.Panel();
            this.label_account_error = new System.Windows.Forms.Label();
            this.button_account_save = new System.Windows.Forms.Button();
            this.button_account_reset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_account_confirmPassword = new System.Windows.Forms.TextBox();
            this.textBox_account_password = new System.Windows.Forms.TextBox();
            this.textBox_account_lName = new System.Windows.Forms.TextBox();
            this.textBox_account_fName = new System.Windows.Forms.TextBox();
            this.panel_menu.SuspendLayout();
            this.panel_class.SuspendLayout();
            this.panel_teacher.SuspendLayout();
            this.panel_dba.SuspendLayout();
            this.panel_account.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.Controls.Add(this.button_menu_dba);
            this.panel_menu.Controls.Add(this.button_menu_teacher);
            this.panel_menu.Controls.Add(this.button_menu_class);
            this.panel_menu.Controls.Add(this.button_menu_logout);
            this.panel_menu.Controls.Add(this.button_menu_account);
            this.panel_menu.Location = new System.Drawing.Point(12, 12);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(140, 495);
            this.panel_menu.TabIndex = 1;
            // 
            // button_menu_dba
            // 
            this.button_menu_dba.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_dba.Location = new System.Drawing.Point(3, 89);
            this.button_menu_dba.Name = "button_menu_dba";
            this.button_menu_dba.Size = new System.Drawing.Size(134, 37);
            this.button_menu_dba.TabIndex = 7;
            this.button_menu_dba.Text = "DBA";
            this.button_menu_dba.UseVisualStyleBackColor = true;
            this.button_menu_dba.Click += new System.EventHandler(this.button_menu_dba_Click);
            // 
            // button_menu_teacher
            // 
            this.button_menu_teacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_teacher.Location = new System.Drawing.Point(3, 46);
            this.button_menu_teacher.Name = "button_menu_teacher";
            this.button_menu_teacher.Size = new System.Drawing.Size(134, 37);
            this.button_menu_teacher.TabIndex = 6;
            this.button_menu_teacher.Text = "Teacher";
            this.button_menu_teacher.UseVisualStyleBackColor = true;
            this.button_menu_teacher.Click += new System.EventHandler(this.button_menu_teacher_Click);
            // 
            // button_menu_class
            // 
            this.button_menu_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_class.Location = new System.Drawing.Point(3, 3);
            this.button_menu_class.Name = "button_menu_class";
            this.button_menu_class.Size = new System.Drawing.Size(134, 37);
            this.button_menu_class.TabIndex = 5;
            this.button_menu_class.Text = "Class";
            this.button_menu_class.UseVisualStyleBackColor = true;
            this.button_menu_class.Click += new System.EventHandler(this.button_menu_class_Click);
            // 
            // button_menu_logout
            // 
            this.button_menu_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_logout.Location = new System.Drawing.Point(3, 455);
            this.button_menu_logout.Name = "button_menu_logout";
            this.button_menu_logout.Size = new System.Drawing.Size(134, 37);
            this.button_menu_logout.TabIndex = 4;
            this.button_menu_logout.Text = "Logout";
            this.button_menu_logout.UseVisualStyleBackColor = true;
            this.button_menu_logout.Click += new System.EventHandler(this.button_menu_logout_Click);
            // 
            // button_menu_account
            // 
            this.button_menu_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_account.Location = new System.Drawing.Point(3, 132);
            this.button_menu_account.Name = "button_menu_account";
            this.button_menu_account.Size = new System.Drawing.Size(134, 37);
            this.button_menu_account.TabIndex = 3;
            this.button_menu_account.Text = "My Account";
            this.button_menu_account.UseVisualStyleBackColor = true;
            this.button_menu_account.Click += new System.EventHandler(this.button_menu_account_Click);
            // 
            // panel_class
            // 
            this.panel_class.Controls.Add(this.comboBox_class_teacher);
            this.panel_class.Controls.Add(this.label_class_menu);
            this.panel_class.Controls.Add(this.button_class_save);
            this.panel_class.Controls.Add(this.button_class_delete);
            this.panel_class.Controls.Add(this.button_class_reset);
            this.panel_class.Controls.Add(this.textBox_class_name);
            this.panel_class.Controls.Add(this.label_class_teacher);
            this.panel_class.Controls.Add(this.label_class_name);
            this.panel_class.Controls.Add(this.button_class_new);
            this.panel_class.Controls.Add(this.listBox_class);
            this.panel_class.Location = new System.Drawing.Point(155, 5);
            this.panel_class.Name = "panel_class";
            this.panel_class.Size = new System.Drawing.Size(650, 500);
            this.panel_class.TabIndex = 2;
            this.panel_class.VisibleChanged += new System.EventHandler(this.panel_class_VisibleChanged);
            // 
            // comboBox_class_teacher
            // 
            this.comboBox_class_teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_class_teacher.FormattingEnabled = true;
            this.comboBox_class_teacher.Location = new System.Drawing.Point(332, 174);
            this.comboBox_class_teacher.Name = "comboBox_class_teacher";
            this.comboBox_class_teacher.Size = new System.Drawing.Size(200, 21);
            this.comboBox_class_teacher.TabIndex = 10;
            // 
            // label_class_menu
            // 
            this.label_class_menu.AutoSize = true;
            this.label_class_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_class_menu.Location = new System.Drawing.Point(41, 15);
            this.label_class_menu.Name = "label_class_menu";
            this.label_class_menu.Size = new System.Drawing.Size(111, 24);
            this.label_class_menu.TabIndex = 9;
            this.label_class_menu.Text = "Class Name";
            // 
            // button_class_save
            // 
            this.button_class_save.Location = new System.Drawing.Point(503, 201);
            this.button_class_save.Name = "button_class_save";
            this.button_class_save.Size = new System.Drawing.Size(75, 23);
            this.button_class_save.TabIndex = 8;
            this.button_class_save.Text = "Save";
            this.button_class_save.UseVisualStyleBackColor = true;
            this.button_class_save.Click += new System.EventHandler(this.button_class_save_Click);
            // 
            // button_class_delete
            // 
            this.button_class_delete.Location = new System.Drawing.Point(383, 201);
            this.button_class_delete.Name = "button_class_delete";
            this.button_class_delete.Size = new System.Drawing.Size(75, 23);
            this.button_class_delete.TabIndex = 7;
            this.button_class_delete.Text = "Delete";
            this.button_class_delete.UseVisualStyleBackColor = true;
            this.button_class_delete.Click += new System.EventHandler(this.button_class_delete_Click);
            // 
            // button_class_reset
            // 
            this.button_class_reset.Location = new System.Drawing.Point(266, 201);
            this.button_class_reset.Name = "button_class_reset";
            this.button_class_reset.Size = new System.Drawing.Size(75, 23);
            this.button_class_reset.TabIndex = 6;
            this.button_class_reset.Text = "Reset";
            this.button_class_reset.UseVisualStyleBackColor = true;
            this.button_class_reset.Click += new System.EventHandler(this.button_class_reset_Click);
            // 
            // textBox_class_name
            // 
            this.textBox_class_name.Location = new System.Drawing.Point(332, 149);
            this.textBox_class_name.Name = "textBox_class_name";
            this.textBox_class_name.Size = new System.Drawing.Size(200, 20);
            this.textBox_class_name.TabIndex = 4;
            // 
            // label_class_teacher
            // 
            this.label_class_teacher.AutoSize = true;
            this.label_class_teacher.Location = new System.Drawing.Point(282, 178);
            this.label_class_teacher.Name = "label_class_teacher";
            this.label_class_teacher.Size = new System.Drawing.Size(47, 13);
            this.label_class_teacher.TabIndex = 3;
            this.label_class_teacher.Text = "Teacher";
            // 
            // label_class_name
            // 
            this.label_class_name.AutoSize = true;
            this.label_class_name.Location = new System.Drawing.Point(291, 152);
            this.label_class_name.Name = "label_class_name";
            this.label_class_name.Size = new System.Drawing.Size(38, 13);
            this.label_class_name.TabIndex = 2;
            this.label_class_name.Text = "Name:";
            // 
            // button_class_new
            // 
            this.button_class_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_class_new.Location = new System.Drawing.Point(45, 440);
            this.button_class_new.Name = "button_class_new";
            this.button_class_new.Size = new System.Drawing.Size(100, 40);
            this.button_class_new.TabIndex = 1;
            this.button_class_new.Text = "New";
            this.button_class_new.UseVisualStyleBackColor = true;
            this.button_class_new.Click += new System.EventHandler(this.button_class_new_Click);
            // 
            // listBox_class
            // 
            this.listBox_class.FormattingEnabled = true;
            this.listBox_class.Location = new System.Drawing.Point(7, 49);
            this.listBox_class.Name = "listBox_class";
            this.listBox_class.Size = new System.Drawing.Size(179, 355);
            this.listBox_class.TabIndex = 0;
            this.listBox_class.SelectedIndexChanged += new System.EventHandler(this.listBox_class_SelectedIndexChanged);
            // 
            // panel_teacher
            // 
            this.panel_teacher.Controls.Add(this.button_teacher_new);
            this.panel_teacher.Controls.Add(this.button_teacher_save);
            this.panel_teacher.Controls.Add(this.button_teacher_delete);
            this.panel_teacher.Controls.Add(this.button_teacher_reset);
            this.panel_teacher.Controls.Add(this.textbox_teacher_password);
            this.panel_teacher.Controls.Add(this.textbox_teacher_username);
            this.panel_teacher.Controls.Add(this.textbox_teacher_lName);
            this.panel_teacher.Controls.Add(this.textbox_teacher_fName);
            this.panel_teacher.Controls.Add(this.label_teacher_password);
            this.panel_teacher.Controls.Add(this.label_teacher_username);
            this.panel_teacher.Controls.Add(this.label_teacher_lName);
            this.panel_teacher.Controls.Add(this.label_teacher_fName);
            this.panel_teacher.Controls.Add(this.label_teacher_menu);
            this.panel_teacher.Controls.Add(this.listBox_teacher);
            this.panel_teacher.Location = new System.Drawing.Point(155, 5);
            this.panel_teacher.Name = "panel_teacher";
            this.panel_teacher.Size = new System.Drawing.Size(650, 500);
            this.panel_teacher.TabIndex = 9;
            this.panel_teacher.Visible = false;
            this.panel_teacher.VisibleChanged += new System.EventHandler(this.panel_teacher_VisibleChanged);
            // 
            // button_teacher_new
            // 
            this.button_teacher_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_teacher_new.Location = new System.Drawing.Point(45, 440);
            this.button_teacher_new.Name = "button_teacher_new";
            this.button_teacher_new.Size = new System.Drawing.Size(100, 40);
            this.button_teacher_new.TabIndex = 13;
            this.button_teacher_new.Text = "New";
            this.button_teacher_new.UseVisualStyleBackColor = true;
            this.button_teacher_new.Click += new System.EventHandler(this.button_teacher_new_Click);
            // 
            // button_teacher_save
            // 
            this.button_teacher_save.Location = new System.Drawing.Point(488, 276);
            this.button_teacher_save.Name = "button_teacher_save";
            this.button_teacher_save.Size = new System.Drawing.Size(75, 23);
            this.button_teacher_save.TabIndex = 12;
            this.button_teacher_save.Text = "Save";
            this.button_teacher_save.UseVisualStyleBackColor = true;
            this.button_teacher_save.Click += new System.EventHandler(this.button_teacher_save_Click);
            // 
            // button_teacher_delete
            // 
            this.button_teacher_delete.Location = new System.Drawing.Point(367, 276);
            this.button_teacher_delete.Name = "button_teacher_delete";
            this.button_teacher_delete.Size = new System.Drawing.Size(75, 23);
            this.button_teacher_delete.TabIndex = 11;
            this.button_teacher_delete.Text = "Delete";
            this.button_teacher_delete.UseVisualStyleBackColor = true;
            this.button_teacher_delete.Click += new System.EventHandler(this.button_teacher_delete_Click);
            // 
            // button_teacher_reset
            // 
            this.button_teacher_reset.Location = new System.Drawing.Point(251, 276);
            this.button_teacher_reset.Name = "button_teacher_reset";
            this.button_teacher_reset.Size = new System.Drawing.Size(75, 23);
            this.button_teacher_reset.TabIndex = 10;
            this.button_teacher_reset.Text = "Reset";
            this.button_teacher_reset.UseVisualStyleBackColor = true;
            this.button_teacher_reset.Click += new System.EventHandler(this.button_teacher_reset_Click);
            // 
            // textbox_teacher_password
            // 
            this.textbox_teacher_password.Location = new System.Drawing.Point(338, 235);
            this.textbox_teacher_password.Name = "textbox_teacher_password";
            this.textbox_teacher_password.Size = new System.Drawing.Size(191, 20);
            this.textbox_teacher_password.TabIndex = 9;
            // 
            // textbox_teacher_username
            // 
            this.textbox_teacher_username.Location = new System.Drawing.Point(338, 209);
            this.textbox_teacher_username.Name = "textbox_teacher_username";
            this.textbox_teacher_username.Size = new System.Drawing.Size(191, 20);
            this.textbox_teacher_username.TabIndex = 8;
            // 
            // textbox_teacher_lName
            // 
            this.textbox_teacher_lName.Location = new System.Drawing.Point(338, 183);
            this.textbox_teacher_lName.Name = "textbox_teacher_lName";
            this.textbox_teacher_lName.Size = new System.Drawing.Size(191, 20);
            this.textbox_teacher_lName.TabIndex = 7;
            // 
            // textbox_teacher_fName
            // 
            this.textbox_teacher_fName.Location = new System.Drawing.Point(338, 159);
            this.textbox_teacher_fName.Name = "textbox_teacher_fName";
            this.textbox_teacher_fName.Size = new System.Drawing.Size(191, 20);
            this.textbox_teacher_fName.TabIndex = 6;
            // 
            // label_teacher_password
            // 
            this.label_teacher_password.AutoSize = true;
            this.label_teacher_password.Location = new System.Drawing.Point(277, 238);
            this.label_teacher_password.Name = "label_teacher_password";
            this.label_teacher_password.Size = new System.Drawing.Size(56, 13);
            this.label_teacher_password.TabIndex = 5;
            this.label_teacher_password.Text = "Password:";
            // 
            // label_teacher_username
            // 
            this.label_teacher_username.AutoSize = true;
            this.label_teacher_username.Location = new System.Drawing.Point(274, 212);
            this.label_teacher_username.Name = "label_teacher_username";
            this.label_teacher_username.Size = new System.Drawing.Size(58, 13);
            this.label_teacher_username.TabIndex = 4;
            this.label_teacher_username.Text = "Username:";
            // 
            // label_teacher_lName
            // 
            this.label_teacher_lName.AutoSize = true;
            this.label_teacher_lName.Location = new System.Drawing.Point(272, 186);
            this.label_teacher_lName.Name = "label_teacher_lName";
            this.label_teacher_lName.Size = new System.Drawing.Size(61, 13);
            this.label_teacher_lName.TabIndex = 3;
            this.label_teacher_lName.Text = "Last Name:";
            // 
            // label_teacher_fName
            // 
            this.label_teacher_fName.AutoSize = true;
            this.label_teacher_fName.Location = new System.Drawing.Point(272, 162);
            this.label_teacher_fName.Name = "label_teacher_fName";
            this.label_teacher_fName.Size = new System.Drawing.Size(60, 13);
            this.label_teacher_fName.TabIndex = 2;
            this.label_teacher_fName.Text = "First Name:";
            // 
            // label_teacher_menu
            // 
            this.label_teacher_menu.AutoSize = true;
            this.label_teacher_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_teacher_menu.Location = new System.Drawing.Point(45, 15);
            this.label_teacher_menu.Name = "label_teacher_menu";
            this.label_teacher_menu.Size = new System.Drawing.Size(102, 25);
            this.label_teacher_menu.TabIndex = 1;
            this.label_teacher_menu.Text = "Teachers";
            // 
            // listBox_teacher
            // 
            this.listBox_teacher.FormattingEnabled = true;
            this.listBox_teacher.Location = new System.Drawing.Point(7, 49);
            this.listBox_teacher.Name = "listBox_teacher";
            this.listBox_teacher.Size = new System.Drawing.Size(179, 355);
            this.listBox_teacher.TabIndex = 0;
            this.listBox_teacher.SelectedIndexChanged += new System.EventHandler(this.listBox_teacher_SelectedIndexChanged);
            // 
            // panel_dba
            // 
            this.panel_dba.Controls.Add(this.button_dba_new);
            this.panel_dba.Controls.Add(this.button_dba_save);
            this.panel_dba.Controls.Add(this.button_dba_delete);
            this.panel_dba.Controls.Add(this.button_dba_reset);
            this.panel_dba.Controls.Add(this.textBox_dba_password);
            this.panel_dba.Controls.Add(this.textBox_dba_username);
            this.panel_dba.Controls.Add(this.textBox_dba_lName);
            this.panel_dba.Controls.Add(this.textBox_dba_fName);
            this.panel_dba.Controls.Add(this.label_dba_password);
            this.panel_dba.Controls.Add(this.label_dba_username);
            this.panel_dba.Controls.Add(this.label_dba_lName);
            this.panel_dba.Controls.Add(this.label_dba_fName);
            this.panel_dba.Controls.Add(this.label_dba_name);
            this.panel_dba.Controls.Add(this.listBox_dba);
            this.panel_dba.Location = new System.Drawing.Point(155, 5);
            this.panel_dba.Name = "panel_dba";
            this.panel_dba.Size = new System.Drawing.Size(650, 500);
            this.panel_dba.TabIndex = 14;
            this.panel_dba.Visible = false;
            this.panel_dba.VisibleChanged += new System.EventHandler(this.panel_dba_VisibleChanged);
            // 
            // button_dba_new
            // 
            this.button_dba_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dba_new.Location = new System.Drawing.Point(45, 440);
            this.button_dba_new.Name = "button_dba_new";
            this.button_dba_new.Size = new System.Drawing.Size(100, 40);
            this.button_dba_new.TabIndex = 27;
            this.button_dba_new.Text = "New";
            this.button_dba_new.UseVisualStyleBackColor = true;
            this.button_dba_new.Click += new System.EventHandler(this.button_dba_new_Click);
            // 
            // button_dba_save
            // 
            this.button_dba_save.Location = new System.Drawing.Point(488, 276);
            this.button_dba_save.Name = "button_dba_save";
            this.button_dba_save.Size = new System.Drawing.Size(75, 23);
            this.button_dba_save.TabIndex = 26;
            this.button_dba_save.Text = "Save";
            this.button_dba_save.UseVisualStyleBackColor = true;
            this.button_dba_save.Click += new System.EventHandler(this.button_dba_save_Click);
            // 
            // button_dba_delete
            // 
            this.button_dba_delete.Location = new System.Drawing.Point(367, 276);
            this.button_dba_delete.Name = "button_dba_delete";
            this.button_dba_delete.Size = new System.Drawing.Size(75, 23);
            this.button_dba_delete.TabIndex = 25;
            this.button_dba_delete.Text = "Delete";
            this.button_dba_delete.UseVisualStyleBackColor = true;
            this.button_dba_delete.Click += new System.EventHandler(this.button_dba_delete_Click);
            // 
            // button_dba_reset
            // 
            this.button_dba_reset.Location = new System.Drawing.Point(251, 276);
            this.button_dba_reset.Name = "button_dba_reset";
            this.button_dba_reset.Size = new System.Drawing.Size(75, 23);
            this.button_dba_reset.TabIndex = 24;
            this.button_dba_reset.Text = "Reset";
            this.button_dba_reset.UseVisualStyleBackColor = true;
            this.button_dba_reset.Click += new System.EventHandler(this.button_dba_reset_Click);
            // 
            // textBox_dba_password
            // 
            this.textBox_dba_password.Location = new System.Drawing.Point(338, 235);
            this.textBox_dba_password.Name = "textBox_dba_password";
            this.textBox_dba_password.Size = new System.Drawing.Size(191, 20);
            this.textBox_dba_password.TabIndex = 23;
            // 
            // textBox_dba_username
            // 
            this.textBox_dba_username.Location = new System.Drawing.Point(338, 209);
            this.textBox_dba_username.Name = "textBox_dba_username";
            this.textBox_dba_username.Size = new System.Drawing.Size(191, 20);
            this.textBox_dba_username.TabIndex = 22;
            // 
            // textBox_dba_lName
            // 
            this.textBox_dba_lName.Location = new System.Drawing.Point(338, 183);
            this.textBox_dba_lName.Name = "textBox_dba_lName";
            this.textBox_dba_lName.Size = new System.Drawing.Size(191, 20);
            this.textBox_dba_lName.TabIndex = 21;
            // 
            // textBox_dba_fName
            // 
            this.textBox_dba_fName.Location = new System.Drawing.Point(338, 159);
            this.textBox_dba_fName.Name = "textBox_dba_fName";
            this.textBox_dba_fName.Size = new System.Drawing.Size(191, 20);
            this.textBox_dba_fName.TabIndex = 20;
            // 
            // label_dba_password
            // 
            this.label_dba_password.AutoSize = true;
            this.label_dba_password.Location = new System.Drawing.Point(277, 238);
            this.label_dba_password.Name = "label_dba_password";
            this.label_dba_password.Size = new System.Drawing.Size(56, 13);
            this.label_dba_password.TabIndex = 19;
            this.label_dba_password.Text = "Password:";
            // 
            // label_dba_username
            // 
            this.label_dba_username.AutoSize = true;
            this.label_dba_username.Location = new System.Drawing.Point(274, 212);
            this.label_dba_username.Name = "label_dba_username";
            this.label_dba_username.Size = new System.Drawing.Size(58, 13);
            this.label_dba_username.TabIndex = 18;
            this.label_dba_username.Text = "Username:";
            // 
            // label_dba_lName
            // 
            this.label_dba_lName.AutoSize = true;
            this.label_dba_lName.Location = new System.Drawing.Point(272, 186);
            this.label_dba_lName.Name = "label_dba_lName";
            this.label_dba_lName.Size = new System.Drawing.Size(61, 13);
            this.label_dba_lName.TabIndex = 17;
            this.label_dba_lName.Text = "Last Name:";
            // 
            // label_dba_fName
            // 
            this.label_dba_fName.AutoSize = true;
            this.label_dba_fName.Location = new System.Drawing.Point(272, 162);
            this.label_dba_fName.Name = "label_dba_fName";
            this.label_dba_fName.Size = new System.Drawing.Size(60, 13);
            this.label_dba_fName.TabIndex = 16;
            this.label_dba_fName.Text = "First Name:";
            // 
            // label_dba_name
            // 
            this.label_dba_name.AutoSize = true;
            this.label_dba_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dba_name.Location = new System.Drawing.Point(6, 15);
            this.label_dba_name.Name = "label_dba_name";
            this.label_dba_name.Size = new System.Drawing.Size(181, 25);
            this.label_dba_name.TabIndex = 15;
            this.label_dba_name.Text = "Database Admins";
            // 
            // listBox_dba
            // 
            this.listBox_dba.FormattingEnabled = true;
            this.listBox_dba.Location = new System.Drawing.Point(7, 49);
            this.listBox_dba.Name = "listBox_dba";
            this.listBox_dba.Size = new System.Drawing.Size(179, 355);
            this.listBox_dba.TabIndex = 14;
            this.listBox_dba.SelectedIndexChanged += new System.EventHandler(this.listBox_dba_SelectedIndexChanged);
            // 
            // panel_account
            // 
            this.panel_account.Controls.Add(this.label_account_error);
            this.panel_account.Controls.Add(this.button_account_save);
            this.panel_account.Controls.Add(this.button_account_reset);
            this.panel_account.Controls.Add(this.label11);
            this.panel_account.Controls.Add(this.label10);
            this.panel_account.Controls.Add(this.label9);
            this.panel_account.Controls.Add(this.label8);
            this.panel_account.Controls.Add(this.textBox_account_confirmPassword);
            this.panel_account.Controls.Add(this.textBox_account_password);
            this.panel_account.Controls.Add(this.textBox_account_lName);
            this.panel_account.Controls.Add(this.textBox_account_fName);
            this.panel_account.Location = new System.Drawing.Point(155, 5);
            this.panel_account.Name = "panel_account";
            this.panel_account.Size = new System.Drawing.Size(650, 500);
            this.panel_account.TabIndex = 28;
            this.panel_account.Visible = false;
            this.panel_account.VisibleChanged += new System.EventHandler(this.panel_account_VisibleChanged);
            // 
            // label_account_error
            // 
            this.label_account_error.AutoSize = true;
            this.label_account_error.ForeColor = System.Drawing.Color.Red;
            this.label_account_error.Location = new System.Drawing.Point(143, 294);
            this.label_account_error.Name = "label_account_error";
            this.label_account_error.Size = new System.Drawing.Size(0, 13);
            this.label_account_error.TabIndex = 10;
            // 
            // button_account_save
            // 
            this.button_account_save.Location = new System.Drawing.Point(386, 254);
            this.button_account_save.Name = "button_account_save";
            this.button_account_save.Size = new System.Drawing.Size(75, 23);
            this.button_account_save.TabIndex = 9;
            this.button_account_save.Text = "Save";
            this.button_account_save.UseVisualStyleBackColor = true;
            this.button_account_save.Click += new System.EventHandler(this.button_account_save_Click);
            // 
            // button_account_reset
            // 
            this.button_account_reset.Location = new System.Drawing.Point(240, 255);
            this.button_account_reset.Name = "button_account_reset";
            this.button_account_reset.Size = new System.Drawing.Size(75, 23);
            this.button_account_reset.TabIndex = 8;
            this.button_account_reset.Text = "Reset";
            this.button_account_reset.UseVisualStyleBackColor = true;
            this.button_account_reset.Click += new System.EventHandler(this.button_account_reset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Confirm Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(173, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Last Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "First Name:";
            // 
            // textBox_account_confirmPassword
            // 
            this.textBox_account_confirmPassword.Location = new System.Drawing.Point(240, 229);
            this.textBox_account_confirmPassword.Name = "textBox_account_confirmPassword";
            this.textBox_account_confirmPassword.PasswordChar = '*';
            this.textBox_account_confirmPassword.Size = new System.Drawing.Size(221, 20);
            this.textBox_account_confirmPassword.TabIndex = 3;
            this.textBox_account_confirmPassword.UseSystemPasswordChar = true;
            // 
            // textBox_account_password
            // 
            this.textBox_account_password.Location = new System.Drawing.Point(240, 203);
            this.textBox_account_password.Name = "textBox_account_password";
            this.textBox_account_password.PasswordChar = '*';
            this.textBox_account_password.Size = new System.Drawing.Size(221, 20);
            this.textBox_account_password.TabIndex = 2;
            this.textBox_account_password.UseSystemPasswordChar = true;
            // 
            // textBox_account_lName
            // 
            this.textBox_account_lName.Location = new System.Drawing.Point(240, 177);
            this.textBox_account_lName.Name = "textBox_account_lName";
            this.textBox_account_lName.Size = new System.Drawing.Size(221, 20);
            this.textBox_account_lName.TabIndex = 1;
            // 
            // textBox_account_fName
            // 
            this.textBox_account_fName.Location = new System.Drawing.Point(240, 151);
            this.textBox_account_fName.Name = "textBox_account_fName";
            this.textBox_account_fName.Size = new System.Drawing.Size(221, 20);
            this.textBox_account_fName.TabIndex = 0;
            // 
            // DbaInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 531);
            this.Controls.Add(this.panel_dba);
            this.Controls.Add(this.panel_teacher);
            this.Controls.Add(this.panel_class);
            this.Controls.Add(this.panel_account);
            this.Controls.Add(this.panel_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DbaInterface";
            this.Text = "Database Administrator";
            this.panel_menu.ResumeLayout(false);
            this.panel_class.ResumeLayout(false);
            this.panel_class.PerformLayout();
            this.panel_teacher.ResumeLayout(false);
            this.panel_teacher.PerformLayout();
            this.panel_dba.ResumeLayout(false);
            this.panel_dba.PerformLayout();
            this.panel_account.ResumeLayout(false);
            this.panel_account.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button button_menu_dba;
        private System.Windows.Forms.Button button_menu_teacher;
        private System.Windows.Forms.Button button_menu_class;
        private System.Windows.Forms.Button button_menu_logout;
        private System.Windows.Forms.Button button_menu_account;
        private System.Windows.Forms.Panel panel_class;
        private System.Windows.Forms.Button button_class_save;
        private System.Windows.Forms.Button button_class_delete;
        private System.Windows.Forms.Button button_class_reset;
        private System.Windows.Forms.TextBox textBox_class_name;
        private System.Windows.Forms.Label label_class_teacher;
        private System.Windows.Forms.Label label_class_name;
        private System.Windows.Forms.Button button_class_new;
        private System.Windows.Forms.ListBox listBox_class;
        private System.Windows.Forms.Label label_class_menu;
        private System.Windows.Forms.Panel panel_teacher;
        private System.Windows.Forms.ListBox listBox_teacher;
        private System.Windows.Forms.ComboBox comboBox_class_teacher;
        private System.Windows.Forms.Label label_teacher_menu;
        private System.Windows.Forms.TextBox textbox_teacher_password;
        private System.Windows.Forms.TextBox textbox_teacher_lName;
        private System.Windows.Forms.TextBox textbox_teacher_fName;
        private System.Windows.Forms.Label label_teacher_password;
        private System.Windows.Forms.Label label_teacher_lName;
        private System.Windows.Forms.Label label_teacher_fName;
        private System.Windows.Forms.Button button_teacher_save;
        private System.Windows.Forms.Button button_teacher_delete;
        private System.Windows.Forms.Button button_teacher_reset;
        private System.Windows.Forms.Button button_teacher_new;
        private System.Windows.Forms.TextBox textbox_teacher_username;
        private System.Windows.Forms.Label label_teacher_username;
        private System.Windows.Forms.Panel panel_dba;
        private System.Windows.Forms.Button button_dba_new;
        private System.Windows.Forms.Button button_dba_save;
        private System.Windows.Forms.Button button_dba_delete;
        private System.Windows.Forms.Button button_dba_reset;
        private System.Windows.Forms.TextBox textBox_dba_password;
        private System.Windows.Forms.TextBox textBox_dba_username;
        private System.Windows.Forms.TextBox textBox_dba_lName;
        private System.Windows.Forms.TextBox textBox_dba_fName;
        private System.Windows.Forms.Label label_dba_password;
        private System.Windows.Forms.Label label_dba_username;
        private System.Windows.Forms.Label label_dba_lName;
        private System.Windows.Forms.Label label_dba_fName;
        private System.Windows.Forms.Label label_dba_name;
        private System.Windows.Forms.ListBox listBox_dba;
        private System.Windows.Forms.Panel panel_account;
        private System.Windows.Forms.Label label_account_error;
        private System.Windows.Forms.Button button_account_save;
        private System.Windows.Forms.Button button_account_reset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_account_confirmPassword;
        private System.Windows.Forms.TextBox textBox_account_password;
        private System.Windows.Forms.TextBox textBox_account_lName;
        private System.Windows.Forms.TextBox textBox_account_fName;

    }
}