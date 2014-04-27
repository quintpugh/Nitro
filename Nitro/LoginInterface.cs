using System;
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
            cmbBox_userType.SelectedIndex = 0;
            loginHandler = new LoginHandler();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            lbl_loginError.Text = String.Empty;
            if (loginHandler.IsValidUser(tb_username.Text, tb_password.Text, cmbBox_userType.Text))
            {
                switch (cmbBox_userType.Text)
                {
                    case ("Student"):
                        Student.StudentInterface studentInterface = new Student.StudentInterface(tb_username.Text);
                        this.Hide();
                        studentInterface.FormClosing += FormClosing;
                        studentInterface.Show();
                        break;
                    case ("Teacher"):
                        Teacher.TeacherInterface teacherInterface = new Teacher.TeacherInterface(tb_username.Text);
                        teacherInterface.Show();
                        break;
                    case ("Database Administrator"):
                        //DbaInterface dbaInterface = new DbaInterface(tb_username.Text);
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

        private void FormClosing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("closing!");
            this.Show();
        }
    }
}
