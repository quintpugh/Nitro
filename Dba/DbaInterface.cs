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

        private void Listbox_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listbox_Class.SelectedIndex > -1)
            {
                Class c = classes.ElementAt(Listbox_Class.SelectedIndex);
                Textbox_Class_Name.Text = c.name;

                if (c.teacher != null)
                {
                    Combo_Class_Teacher.SelectedValue = c.teacher;
                }
                else
                {
                    Combo_Class_Teacher.SelectedValue = "";
                }
                Button_Class_Save.Text = "Save";
                Button_Class_Delete.Enabled = true;
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

        private void Button_Class_Reset_Click(object sender, EventArgs e)
        {
            if (Listbox_Class.SelectedIndex < 0)
            {
                Textbox_Class_Name.Text = "";
                Combo_Class_Teacher.SelectedValue = "";
            }
            else
            {
                Textbox_Class_Name.Text = classes.ElementAt(Listbox_Class.SelectedIndex).name;
                Combo_Class_Teacher.SelectedValue = classes.ElementAt(Listbox_Class.SelectedIndex).teacher;
            }
        }

        private void Button_Class_New_Click(object sender, EventArgs e)
        {
            Textbox_Class_Name.Text = "";
            Combo_Class_Teacher.SelectedValue = "";
            Listbox_Class.SelectedIndex = -1;
            Button_Class_Save.Text = "Add";
            Button_Class_Delete.Enabled = false;
        }

        private void Button_Class_Delete_Click(object sender, EventArgs e)
        {
            if (Listbox_Class.SelectedIndex > -1)
            {
                if (classes.ElementAt(Listbox_Class.SelectedIndex).Delete())
                {
                    classes.RemoveAt(Listbox_Class.SelectedIndex);
                    Listbox_Class.SelectedIndex = -1;
                    Listbox_Class.DataSource = null;
                    Listbox_Class.DataSource = classes;
                    Listbox_Class.DisplayMember = "name";
                }
                else
                {
                    MessageBox.Show("There are still students enrolled! Or there is still a teacher associated");
                }
            }
        }

        private void Button_Class_Save_Click(object sender, EventArgs e)
        {
            if (Listbox_Class.SelectedIndex < 0)
            {
                Class c = new Class(-1, Textbox_Class_Name.Text, Combo_Class_Teacher.SelectedValue.ToString());
                if (!c.Add())
                {
                    MessageBox.Show("Woah! Class was not able to added.");
                }
                else
                {
                    Listbox_Class.DataSource = null;
                    PopulateClassList();
                }
            }
            else
            {
                Class c = classes.ElementAt(Listbox_Class.SelectedIndex);

                if(!c.Update(c.id, Textbox_Class_Name.Text, Combo_Class_Teacher.SelectedValue.ToString()))
                {
                    MessageBox.Show("Woah! Could not update class.");
                }
                else
                {
                    Listbox_Class.DataSource = null;
                    PopulateClassList();
                }
            }
        }

        private void Button_Menu_Class_Click(object sender, EventArgs e)
        {
            Panel_Class.Visible = true;
            Panel_Teacher.Visible = false;
            Panel_Dba.Visible = false;
            Panel_Dba_Account.Visible = false;
        }

        private void Button_Menu_Teacher_Click(object sender, EventArgs e)
        {
            Panel_Class.Visible = false;
            Panel_Teacher.Visible = true;
            Panel_Dba.Visible = false;
            Panel_Dba_Account.Visible = false;
        }

        private void Panel_Teacher_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTeacherList();
            ListBox_Teacher_Name.DataSource = teachers;
            ListBox_Teacher_Name.DisplayMember = "fullName";
        }

        private void Panel_Class_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTeacherList();
            teachers.Insert(0, Teacher.Empty);
            Combo_Class_Teacher.DataSource = teachers;
            Combo_Class_Teacher.DisplayMember = "fullName";
            Combo_Class_Teacher.ValueMember = "username";

            PopulateClassList();
            Listbox_Class.DataSource = classes;
            Listbox_Class.DisplayMember = "name";
        }

        private void ListBox_Teacher_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_Teacher_Name.SelectedIndex > -1)
            {
                Teacher t = teachers.ElementAt(ListBox_Teacher_Name.SelectedIndex);
                Textbox_Teacher_fName.Text = t.fName;
                Textbox_Teacher_lName.Text = t.lName;
                Textbox_Teacher_Username.Text = t.username;
                Textbox_Teacher_Password.Text = t.password;
                Button_Teacher_Save.Text = "Save";
                Button_Teacher_Delete.Enabled = true;
                Textbox_Teacher_Username.Enabled = false;
            }
            else
            {
                Textbox_Teacher_fName.Text = "";
                Textbox_Teacher_lName.Text = "";
                Textbox_Teacher_Username.Text = "";
                Textbox_Teacher_Password.Text = "";
                Button_Teacher_Save.Text = "Add";
                Button_Teacher_Delete.Enabled = false;
                Textbox_Teacher_Username.Enabled = true;
            }
        }

        private void Button_Teacher_New_Click(object sender, EventArgs e)
        {
            ListBox_Teacher_Name.SelectedIndex = -1;
        }

        private void Button_Teacher_Reset_Click(object sender, EventArgs e)
        {
            if (ListBox_Teacher_Name.SelectedIndex < 0)
            {
                Textbox_Teacher_fName.Text = "";
                Textbox_Teacher_lName.Text = "";
                Textbox_Teacher_Username.Text = "";
                Textbox_Teacher_Password.Text = "";
            }
            else
            {
                Teacher t = teachers.ElementAt(ListBox_Teacher_Name.SelectedIndex);
                Textbox_Teacher_fName.Text = t.fName;
                Textbox_Teacher_lName.Text = t.lName;
                Textbox_Teacher_Username.Text = t.username;
                Textbox_Teacher_Password.Text = t.password;
            }
        }

        private void Button_Teacher_Delete_Click(object sender, EventArgs e)
        {
            if (ListBox_Teacher_Name.SelectedIndex > -1)
            {
                if (teachers.ElementAt(ListBox_Teacher_Name.SelectedIndex).Delete())
                {
                    ListBox_Teacher_Name.SelectedIndex = -1;
                    PopulateTeacherList();
                    ListBox_Teacher_Name.DataSource = teachers;
                    ListBox_Teacher_Name.DisplayMember = "fullName";
                }
                else
                {
                    MessageBox.Show("Woah! This teacher still has classes.");
                }
            }
        }

        private void Button_Teacher_Save_Click(object sender, EventArgs e)
        {
            if (Textbox_Teacher_fName.Text.Equals("") || Textbox_Teacher_lName.Text.Equals("") || Textbox_Teacher_Username.Text.Equals("") || Textbox_Teacher_Password.Text.Equals(""))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                if (!PasswordMeetsRequirements(Textbox_Teacher_Password.Text))
                {
                    MessageBox.Show("Entered passwords do not meet minimum requirements\n1 upper case letter, 1 lower case letter, 1 digit, and legth of at least 8.");
                }
                else
                {
                    if (ListBox_Teacher_Name.SelectedIndex < 0)
                    {
                        Teacher t = new Teacher(Textbox_Teacher_Username.Text, Textbox_Teacher_Password.Text, Textbox_Teacher_fName.Text, Textbox_Teacher_lName.Text);
                        if (!t.Add())
                        {
                            MessageBox.Show("Woah! This teacher could not be added.");
                        }
                        else
                        {
                            PopulateTeacherList();
                            ListBox_Teacher_Name.DataSource = teachers;
                            ListBox_Teacher_Name.DisplayMember = "fullName";
                        }
                    }
                    else
                    {
                        Teacher t = teachers.ElementAt(ListBox_Teacher_Name.SelectedIndex);

                        if (!t.Update(Textbox_Teacher_Password.Text, Textbox_Teacher_fName.Text, Textbox_Teacher_lName.Text))
                        {
                            MessageBox.Show("Woah! Could not update teacher information.");
                        }
                        else
                        {
                            PopulateTeacherList();
                            ListBox_Teacher_Name.DataSource = teachers;
                            ListBox_Teacher_Name.DisplayMember = "fullName";
                        }
                    }
                }
            }
            Textbox_Teacher_Password.Text = "";
        }

        private void Listbox_Dba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listbox_Dba.SelectedIndex < 0)
            {
                Textbox_Dba_Fname.Text = "";
                Textbox_Dba_Lname.Text = "";
                Textbox_Dba_Username.Text = "";
                Textbox_Dba_Password.Text = "";
                Button_Dba_Delete.Enabled = false;
                Textbox_Dba_Username.Enabled = true;
                Button_Dba_Save.Text = "Add";
            }
            else
            {
                Dba d = dbas.ElementAt(Listbox_Dba.SelectedIndex);

                Textbox_Dba_Fname.Text = d.fName;
                Textbox_Dba_Lname.Text = d.lName;
                Textbox_Dba_Username.Text = d.username;
                Textbox_Dba_Password.Text = d.password;
                Button_Dba_Delete.Enabled = true;
                Textbox_Dba_Username.Enabled = false;
                Button_Dba_Save.Text = "Save";
            }
        }

        private void Panel_Dba_VisibleChanged(object sender, EventArgs e)
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
            Listbox_Dba.DataSource = dbas;
            Listbox_Dba.DisplayMember = "fullName";
        }

        private void Button_Menu_Dba_Click(object sender, EventArgs e)
        {
            Panel_Class.Visible = false;
            Panel_Teacher.Visible = false;
            Panel_Dba.Visible = true;
            Panel_Dba_Account.Visible = false;
        }

        private void Button_Dba_New_Click(object sender, EventArgs e)
        {
            Listbox_Dba.SelectedIndex = -1;
        }

        private void Button_Dba_Save_Click(object sender, EventArgs e)
        {
            if (Textbox_Dba_Fname.Text.Equals("") || textBox_account_lName.Text.Equals("") || Textbox_Dba_Username.Text.Equals("") || Textbox_Dba_Password.Text.Equals(""))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                if (!PasswordMeetsRequirements(Textbox_Dba_Password.Text))
                {
                    MessageBox.Show("Entered passwords do not meet minimum requirements\n1 upper case letter, 1 lower case letter, 1 digit, and legth of at least 8.");
                }
                else
                {
                    if (Listbox_Dba.SelectedIndex < 0)
                    {
                        Dba d = new Dba(Textbox_Dba_Username.Text, Textbox_Dba_Password.Text, Textbox_Dba_Fname.Text, Textbox_Dba_Lname.Text);

                        if (!d.Add())
                        {
                            MessageBox.Show("Woah! Could not add this DBA.");
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
                            Listbox_Dba.DataSource = dbas;
                            Listbox_Dba.DisplayMember = "fullName";
                        }
                    }
                    else
                    {
                        Dba d = dbas.ElementAt(Listbox_Dba.SelectedIndex);

                        if (!d.Update(Textbox_Dba_Password.Text, Textbox_Dba_Fname.Text, Textbox_Dba_Lname.Text))
                        {
                            MessageBox.Show("Woah! Could not update this DBA.");
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
                            Listbox_Dba.DataSource = dbas;
                            Listbox_Dba.DisplayMember = "fullName";
                        }
                    }
                }
            }
            Textbox_Dba_Password.Text = "";
        }

        private void Button_Dba_Reset_Click(object sender, EventArgs e)
        {
            if (Listbox_Dba.SelectedIndex < 0)
            {
                Textbox_Dba_Fname.Text = "";
                Textbox_Dba_Lname.Text = "";
                Textbox_Dba_Username.Text = "";
                Textbox_Dba_Password.Text = "";
            }
            else
            {
                Dba d = dbas.ElementAt(Listbox_Dba.SelectedIndex);

                Textbox_Dba_Fname.Text = d.fName;
                Textbox_Dba_Lname.Text = d.lName;
                Textbox_Dba_Password.Text = d.password;
            }
        }

        private void Button_Dba_Delete_Click(object sender, EventArgs e)
        {
            if (Listbox_Dba.SelectedIndex > -1)
            {
                dbas.ElementAt(Listbox_Dba.SelectedIndex).Delete();

                Listbox_Dba.SelectedIndex = -1;
                dbas = Dba.Generate();
                for (int i = 0; i < dbas.Count; i++)
                {
                    if (dbas.ElementAt(i).username.Equals(dba.username))
                    {
                        dbas.RemoveAt(i);
                        break;
                    }
                }
                Listbox_Dba.DataSource = dbas;
                Listbox_Dba.DisplayMember = "fullName";
            }
        }

        private void button_menu_account_Click(object sender, EventArgs e)
        {
            Panel_Class.Visible = false;
            Panel_Teacher.Visible = false;
            Panel_Dba.Visible = false;
            Panel_Dba_Account.Visible = true;
        }

        private void Panel_Dba_Account_VisibleChanged(object sender, EventArgs e)
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
                            MessageBox.Show("Woah! Could not update account information.");
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
