﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginInterface : Form
    {
        private LoginHandler loginHandler;
        public LoginInterface()
        {
            InitializeComponent();
            loginHandler = new LoginHandler();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            lbl_loginError.Text = String.Empty;
            if (loginHandler.IsValidUser(tb_username.Text, tb_password.Text, cmbBox_userType.Text))
            {
                switch (cmbBox_userType.Text)
                {
                    case ("Student"):
                        //StudentInterface studentInterface = new StudentInterface(usernameText.text);
                        //studentinterface.show();
                        break;
                    case ("Teacher"):
                        //TeacherInterface teacherInterface = new TeacherInterface(usernameText.text);
                        //teacherInterface.Show();
                        break;
                    case ("Database Administrator"):
                        //DbaInterface dbaInterface = new DbaInterface(usernameText.text);
                        //dbaInterface.Show();
                        break;
                    default:
                        throw new Exception("How did you get a user that doesn't exist?");
                }
            }
            else
            {
                lbl_loginError.Text = "Invalid Username or Password.";
            }
        }
    }
}
