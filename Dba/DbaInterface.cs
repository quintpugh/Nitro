using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dba
{
    public partial class DbaInterface : Form
    {
        private List<Teacher> teachers;
        private List<Class> classes;
        public DbaUser dba;
        private List<Dba> dbas;

        public DbaInterface(String uName)
        {
            InitializeComponent();

            dba = new DbaUser(uName);

            PopulateTeacherList();
            PopulateClassList();
        }

        private void listBox_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_class.SelectedIndex > -1)
            {
                Class c = classes.ElementAt(listBox_class.SelectedIndex);
                textBox_class_name.Text = c.name;

                if (c.teacher != null)
                {
                    comboBox_class_teacher.SelectedValue = c.teacher;
                }
                else
                {
                    comboBox_class_teacher.SelectedValue = "";
                }
                button_class_save.Text = "Save";
                button_class_delete.Enabled = true;
            }
        }

        private void PopulateClassList()
        {
            classes = Class.Generate();
        }

        private void PopulateTeacherList()
        {
            teachers = Teacher.Generate();
        }

        private void button_class_reset_Click(object sender, EventArgs e)
        {
            if (listBox_class.SelectedIndex < 0)
            {
                textBox_class_name.Text = "";
                comboBox_class_teacher.SelectedValue = "";
            }
            else
            {
                textBox_class_name.Text = classes.ElementAt(listBox_class.SelectedIndex).name;
                comboBox_class_teacher.SelectedValue = classes.ElementAt(listBox_class.SelectedIndex).teacher;
            }
        }

        private void button_class_new_Click(object sender, EventArgs e)
        {
            textBox_class_name.Text = "";
            comboBox_class_teacher.SelectedValue = "";
            listBox_class.SelectedIndex = -1;
            button_class_save.Text = "Add";
            button_class_delete.Enabled = false;
        }

        private void button_class_delete_Click(object sender, EventArgs e)
        {
            if (listBox_class.SelectedIndex > -1)
            {
                if (classes.ElementAt(listBox_class.SelectedIndex).Delete())
                {
                    classes.RemoveAt(listBox_class.SelectedIndex);
                    listBox_class.SelectedIndex = -1;
                    listBox_class.DataSource = null;
                    listBox_class.DataSource = classes;
                    listBox_class.DisplayMember = "name";
                }
                else
                {
                    MessageBox.Show("You cannot delete a class that still has a teacher or students in it.");
                }
            }
        }

        private void button_class_save_Click(object sender, EventArgs e)
        {
            if (listBox_class.SelectedIndex < 0)
            {
                Class c = new Class(-1, textBox_class_name.Text, null);
                if (!c.Add())
                {
                    MessageBox.Show("Class was not able to be added.");
                }
                else
                {
                    PopulateClassList();
                    listBox_class.DataSource = classes;
                }
            }
            else
            {
                Class c = classes.ElementAt(listBox_class.SelectedIndex);

                if(!c.Update(c.id, textBox_class_name.Text, comboBox_class_teacher.SelectedValue.ToString()))
                {
                    MessageBox.Show("Class was not able to be updated.");
                }
                else
                {
                    PopulateClassList();
                    listBox_class.DataSource = classes;
                }
            }
        }

        private void button_menu_class_Click(object sender, EventArgs e)
        {
            panel_class.Visible = true;
            panel_teacher.Visible = false;
            panel_dba.Visible = false;
            panel_account.Visible = false;
        }

        private void button_menu_teacher_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = true;
            panel_dba.Visible = false;
            panel_account.Visible = false;
        }

        private void panel_teacher_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTeacherList();
            listBox_teacher.DataSource = teachers;
            listBox_teacher.DisplayMember = "fullName";
        }

        private void panel_class_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTeacherList();
            teachers.Insert(0, Teacher.Empty);
            comboBox_class_teacher.DataSource = teachers;
            comboBox_class_teacher.DisplayMember = "fullName";
            comboBox_class_teacher.ValueMember = "username";

            PopulateClassList();
            listBox_class.DataSource = classes;
            listBox_class.DisplayMember = "name";
        }

        private void listBox_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_teacher.SelectedIndex > -1)
            {
                Teacher t = teachers.ElementAt(listBox_teacher.SelectedIndex);
                textbox_teacher_fName.Text = t.fName;
                textbox_teacher_lName.Text = t.lName;
                textbox_teacher_username.Text = t.username;
                textbox_teacher_password.Text = t.password;
                button_teacher_save.Text = "Save";
                button_teacher_delete.Enabled = true;
                textbox_teacher_username.Enabled = false;
            }
            else
            {
                textbox_teacher_fName.Text = "";
                textbox_teacher_lName.Text = "";
                textbox_teacher_username.Text = "";
                textbox_teacher_password.Text = "";
                button_teacher_save.Text = "Add";
                button_teacher_delete.Enabled = false;
                textbox_teacher_username.Enabled = true;
            }
        }

        private void button_teacher_new_Click(object sender, EventArgs e)
        {
            listBox_teacher.SelectedIndex = -1;
        }

        private void button_teacher_reset_Click(object sender, EventArgs e)
        {
            if (listBox_teacher.SelectedIndex < 0)
            {
                textbox_teacher_fName.Text = "";
                textbox_teacher_lName.Text = "";
                textbox_teacher_username.Text = "";
                textbox_teacher_password.Text = "";
            }
            else
            {
                Teacher t = teachers.ElementAt(listBox_teacher.SelectedIndex);
                textbox_teacher_fName.Text = t.fName;
                textbox_teacher_lName.Text = t.lName;
                textbox_teacher_username.Text = t.username;
                textbox_teacher_password.Text = t.password;
            }
        }

        private void button_teacher_delete_Click(object sender, EventArgs e)
        {
            if (listBox_teacher.SelectedIndex > -1)
            {
                if (teachers.ElementAt(listBox_teacher.SelectedIndex).Delete())
                {
                    listBox_teacher.SelectedIndex = -1;
                    PopulateTeacherList();
                    listBox_teacher.DataSource = teachers;
                    listBox_teacher.DisplayMember = "fullName";
                }
                else
                {
                    MessageBox.Show("Teacher was not able to be deleted.");
                }
            }
        }

        private void button_teacher_save_Click(object sender, EventArgs e)
        {
            if (textbox_teacher_fName.Text.Equals("") || textbox_teacher_lName.Text.Equals("") || textbox_teacher_username.Text.Equals("") || textbox_teacher_password.Text.Equals(""))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                if (!PasswordMeetsRequirements(textbox_teacher_password.Text))
                {
                    MessageBox.Show("Entered passwords do not meet minimum requirements\n1 upper case letter, 1 lower case letter, 1 digit, and legth of at least 8.");
                }
                else
                {
                    if (listBox_teacher.SelectedIndex < 0)
                    {
                        Teacher t = new Teacher(textbox_teacher_username.Text, textbox_teacher_password.Text, textbox_teacher_fName.Text, textbox_teacher_lName.Text);
                        if (!t.Add())
                        {
                            MessageBox.Show("Teacher was unable to be added.");
                        }
                        else
                        {
                            PopulateTeacherList();
                            listBox_teacher.DataSource = teachers;
                            listBox_teacher.DisplayMember = "fullName";
                        }
                    }
                    else
                    {
                        Teacher t = teachers.ElementAt(listBox_teacher.SelectedIndex);

                        if (!t.Update(textbox_teacher_password.Text, textbox_teacher_fName.Text, textbox_teacher_lName.Text))
                        {
                            MessageBox.Show("Teacher was unable to be updated.");
                        }
                        else
                        {
                            PopulateTeacherList();
                            listBox_teacher.DataSource = teachers;
                            listBox_teacher.DisplayMember = "fullName";
                        }
                    }
                }
            }
        }

        private void listBox_dba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_dba.SelectedIndex < 0)
            {
                textBox_dba_fName.Text = "";
                textBox_dba_lName.Text = "";
                textBox_dba_username.Text = "";
                textBox_dba_password.Text = "";
                button_dba_delete.Enabled = false;
                textBox_dba_username.Enabled = true;
                button_dba_save.Text = "Add";
            }
            else
            {
                Dba d = dbas.ElementAt(listBox_dba.SelectedIndex);

                textBox_dba_fName.Text = d.fName;
                textBox_dba_lName.Text = d.lName;
                textBox_dba_username.Text = d.username;
                textBox_dba_password.Text = d.password;
                button_dba_delete.Enabled = true;
                textBox_dba_username.Enabled = false;
                button_dba_save.Text = "Save";
            }
        }

        private void panel_dba_VisibleChanged(object sender, EventArgs e)
        {
            dbas = Dba.Generate();
            for (int i = 0; i < dbas.Count;i++)
            {
                if (dbas.ElementAt(i).username.Equals(dba.username))
                {
                    dbas.RemoveAt(i);
                    break;
                }
            }
            listBox_dba.DataSource = dbas;
            listBox_dba.DisplayMember = "fullName";
        }

        private void button_menu_dba_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = false;
            panel_dba.Visible = true;
            panel_account.Visible = false;
        }

        private void button_dba_new_Click(object sender, EventArgs e)
        {
            listBox_dba.SelectedIndex = -1;
        }

        private void button_dba_save_Click(object sender, EventArgs e)
        {
            if (textBox_dba_fName.Text.Equals("") || textBox_dba_lName.Text.Equals("") || textBox_dba_username.Text.Equals("") || textBox_dba_password.Text.Equals(""))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                if (!PasswordMeetsRequirements(textBox_dba_password.Text))
                {
                    MessageBox.Show("Entered passwords do not meet minimum requirements\n1 upper case letter, 1 lower case letter, 1 digit, and legth of at least 8.");
                }
                else
                {
                    if (listBox_dba.SelectedIndex < 0)
                    {
                        Dba d = new Dba(textBox_dba_username.Text, textBox_dba_password.Text, textBox_dba_fName.Text, textBox_dba_lName.Text);

                        if (!d.Add())
                        {
                            MessageBox.Show("Database administrator could not be added.");
                        }
                        else
                        {
                            dbas = Dba.Generate();
                            for (int i = 0; i < dbas.Count; i++)
                            {
                                if (dbas.ElementAt(i).username.Equals(dba.username))
                                {
                                    dbas.RemoveAt(i);
                                    break;
                                }
                            }
                            listBox_dba.DataSource = dbas;
                            listBox_dba.DisplayMember = "fullName";
                        }
                    }
                    else
                    {
                        Dba d = dbas.ElementAt(listBox_dba.SelectedIndex);

                        if (!d.Update(textBox_dba_password.Text, textBox_dba_fName.Text, textBox_dba_lName.Text))
                        {
                            MessageBox.Show("Database administrator could not be updated.");
                        }
                        else
                        {
                            dbas = Dba.Generate();
                            for (int i = 0; i < dbas.Count; i++)
                            {
                                if (dbas.ElementAt(i).username.Equals(dba.username))
                                {
                                    dbas.RemoveAt(i);
                                    break;
                                }
                            }
                            listBox_dba.DataSource = dbas;
                            listBox_dba.DisplayMember = "fullName";
                        }
                    }
                }
            }
        }

        private void button_dba_reset_Click(object sender, EventArgs e)
        {
            if (listBox_dba.SelectedIndex < 0)
            {
                textBox_dba_fName.Text = "";
                textBox_dba_lName.Text = "";
                textBox_dba_username.Text = "";
                textBox_dba_password.Text = "";
            }
            else
            {
                Dba d = dbas.ElementAt(listBox_dba.SelectedIndex);

                textBox_dba_fName.Text = d.fName;
                textBox_dba_lName.Text = d.lName;
                textBox_dba_password.Text = d.password;
            }
        }

        private void button_dba_delete_Click(object sender, EventArgs e)
        {
            if (listBox_dba.SelectedIndex > -1)
            {
                dbas.ElementAt(listBox_dba.SelectedIndex).Delete();

                listBox_dba.SelectedIndex = -1;
                dbas = Dba.Generate();
                for (int i = 0; i < dbas.Count; i++)
                {
                    if (dbas.ElementAt(i).username.Equals(dba.username))
                    {
                        dbas.RemoveAt(i);
                        break;
                    }
                }
                listBox_dba.DataSource = dbas;
                listBox_dba.DisplayMember = "fullName";
            }
        }

        private void button_menu_account_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = false;
            panel_dba.Visible = false;
            panel_account.Visible = true;
        }

        private void panel_account_VisibleChanged(object sender, EventArgs e)
        {
            textBox_account_fName.Text = dba.fName;
            textBox_account_lName.Text = dba.lName;
            textBox_account_password.Text = "";
            label_account_error.Text = "";
        }

        private void button_account_reset_Click(object sender, EventArgs e)
        {
            textBox_account_fName.Text = dba.fName;
            textBox_account_lName.Text = dba.lName;
            textBox_account_password.Text = "";
            label_account_error.Text = "";
        }

        private void button_account_save_Click(object sender, EventArgs e)
        {
            if (PasswordMeetsRequirements(textBox_account_password.Text))
            {
                if (textBox_account_password.Text.Equals(textBox_account_confirmPassword.Text))
                {
                    if (textBox_account_fName.Text.Equals("") || textBox_account_lName.Text.Equals(""))
                    {
                        label_account_error.Text = "Please fill in all fields.";
                    }
                    else
                    {
                        if (!dba.Update(textBox_account_password.Text, textBox_account_fName.Text, textBox_account_lName.Text))
                        {
                            MessageBox.Show("Account information could not be updated.");
                        }
                    }
                }
                else
                {
                    label_account_error.Text = "Passwords do not match.";
                }
            }
            else
            {
                label_account_error.Text = "Entered passwords do not meet minimum requirements\n1 upper case letter, 1 lower case letter, 1 digit, and legth of at least 8.";
            }
            textBox_account_password.Text = "";
            textBox_account_confirmPassword.Text = "";
        }

        private void button_menu_logout_Click(object sender, EventArgs e)
        {
            this.RemoveOwnedForm(this.OwnedForms.ElementAt(0));
            this.Close();
        }

        private bool PasswordMeetsRequirements(String pWord)
        {
            bool upper = false;
            bool lower = false;
            bool digit = false;
            if (pWord.Length >= 8)
            {
                for (int i = 0; i < pWord.Length; i++)
                {
                    if (Char.IsUpper(pWord[i])) upper = true;
                    else if (Char.IsLower(pWord[i])) lower = true;
                    else if (Char.IsDigit(pWord[i])) digit = true;
                }
            }
            return upper && lower && digit;
        }
    }
}
