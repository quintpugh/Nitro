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
    /// <summary>
    /// This class is associated with the Login Module and handles all interface interactions
    /// It contains various textboxes that a user must enter information to authenticate further into the system.
    /// Authenitication begins once the "Login" button has been clicked.
    /// </summary>
    public partial class LoginInterface : Form
    {
        private LoginHandler loginHandler;

        /// <summary>
        /// The constructor method of the interface, which initalizes the components needed for the system.
        /// Also sets the default index for the "User Type" combobox to Students.
        /// </summary>
        public LoginInterface()
        {
            InitializeComponent();
            comboBox_userType.SelectedIndex = 0;
            loginHandler = new LoginHandler();
        }

        /// <summary>
        /// This method handles the event when the Login button is clicked.
        /// After the event is activated, the method uses the LoginHandler class to determine if the login information is correctly 
        /// entered for the respective user type. It then loads the respective module and passes the username.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_login_Click(object sender, EventArgs e)
        {
            label_loginError.Text = String.Empty;
            if (loginHandler.IsValidUser(textBox_username.Text, textbox_password.Text, comboBox_userType.Text))
            {
                switch (comboBox_userType.Text)
                {
                    case ("Student"): // student authentication
                        Student.StudentInterface studentInterface = new Student.StudentInterface(textBox_username.Text);
                        textBox_username.Focus();
                        this.Hide();
                        this.Owner = studentInterface;
                        studentInterface.FormClosing += SubFormClosing;
                        studentInterface.Show();
                        break;
                    case ("Teacher"): // teacher authentication
                        Teacher.TeacherInterface teacherInterface = new Teacher.TeacherInterface(textBox_username.Text);
                        textBox_username.Focus();
                        this.Hide();
                        this.Owner = teacherInterface;
                        teacherInterface.FormClosing += SubFormClosing;
                        teacherInterface.Show();
                        break;
                    case ("Database Administrator"): // database administrator authentication
                        Dba.DbaInterface dbaInterface = new Dba.DbaInterface(textBox_username.Text);
                        textBox_username.Focus();
                        this.Hide();
                        this.Owner = dbaInterface;
                        dbaInterface.FormClosing += SubFormClosing;
                        dbaInterface.Show();
                        break;
                    default:
                        throw new Exception("How did you get a user that doesn't exist?");
                }
                textBox_username.ResetText();
                textbox_password.ResetText();
            }
            else
            {
                label_loginError.Text = "Invalid Username or Password.";
            }
        }

        /// <summary>
        /// This method handles the event when another module (Student, Teacher, DBA) is closed through a logout button. Once this event is encountered
        /// it reloads the Login Module and displays the Login Interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubFormClosing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("closing!");
            this.Show();
        }
    }
}
