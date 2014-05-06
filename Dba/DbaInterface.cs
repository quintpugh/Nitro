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
    /// <summary>
    /// The logic of the DBA interface, houses all of the event-driven commands of the system
    /// </summary>
    public partial class DbaInterface : Form
    {
        private List<Teacher> teachers;
        private List<Class> classes;
        public DbaUser dba;
        private List<Dba> dbas;

        /// <summary>
        /// Constructor method for the DBA Interface. Creates a new instance of the DBA user.
        /// </summary>
        /// <param name="uName"></param> the username of the DBA user (passed from Login)
        public DbaInterface(String uName)
        {
            InitializeComponent();

            dba = new DbaUser(uName);

            PopulateTeacherList();
            PopulateClassList();
        }

        /// <summary>
        /// Callback that occurs when a new item is selected in the Class Listbox. Upon change, it populates the data fields
        /// with the respective Class' information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Quick method to generate a full list of all of the Classes within the system
        /// </summary>
        private void PopulateClassList()
        {
            classes = Class.Generate();
        }

        /// <summary>
        /// Quick method to generate a full list of all of the Teachers within the system
        /// </summary>
        private void PopulateTeacherList()
        {
            teachers = Teacher.Generate();
        }

        /// <summary>
        /// Callback for when the "Reset" button is clicked in the Class panel. This method reverts the information in the data fields to their original state.
        /// The original state varies based off of whether the user has anything currently selected. If they do, it repopulates the fields with that Class'
        /// original information. If they do not, it empties all of the fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "New" button is clicked in the Class panel. This method is used to start creating a new Class in the system.
        /// To do this, the method unselects the item from the Listbox and empties all of the data fields in the current panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_class_new_Click(object sender, EventArgs e)
        {
            textBox_class_name.Text = "";
            comboBox_class_teacher.SelectedValue = "";
            listBox_class.SelectedIndex = -1;
            button_class_save.Text = "Add";
            button_class_delete.Enabled = false;
        }

        /// <summary>
        /// Callback for when the "Delete" button is clicked in the Class panel. This method is used to trigger the deletion of the Class in the system.
        /// If no item is selected, nothing happens. However, if a class still has students or teachers associated with it, the deletion function will
        /// not work and display an error message for the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Save" or "Add" button is clicked in the Class panel. The button has the text "Save" when updating an already existing Class
        /// and the text "Add" when creating a new Class to the system. This is determined by checking to see if an element is selected before proceding with
        /// the operation. Error messages display if the operation is uncessful
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Classes" button is clicked in the menu. It makes the Classes panel visible and the other panels not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_class_Click(object sender, EventArgs e)
        {
            panel_class.Visible = true;
            panel_teacher.Visible = false;
            panel_dba.Visible = false;
            panel_account.Visible = false;
        }

        /// <summary>
        /// Callback for when the "Teacher" button is clicked in the menu. It makes the Teacher panel visible and the other panels not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_teacher_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = true;
            panel_dba.Visible = false;
            panel_account.Visible = false;
        }

        /// <summary>
        /// Callback for when the Teacher panel is made visible after clicking the "Teacher" menu button. This method repopulates the Teacher List
        /// and adds the data to the teacher listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_teacher_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTeacherList();
            listBox_teacher.DataSource = teachers;
            listBox_teacher.DisplayMember = "fullName";
        }

        /// <summary>
        /// Callback for when the Class panel is made visible after clicking the "Classes" menu button. This method repopulates both the Teacher and Class
        /// lists. The teacher list populates the combobox and the class list populates the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback that occurs when a new item is selected in the Teacher Listbox. Upon change, it populates the data fields
        /// with the respective Teacher's information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }

        /// <summary>
        /// Callback for when the "New" button is clicked in the Teacher panel. This method is used to start creating a new Teacher in the system.
        /// To do this, the method unselects the item from the Listbox and empties all of the data fields in the current panel. This method also disables
        /// the deletion button and renables the username textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_teacher_new_Click(object sender, EventArgs e)
        {
            listBox_teacher.SelectedIndex = -1;
            textbox_teacher_fName.Text = "";
            textbox_teacher_lName.Text = "";
            textbox_teacher_username.Text = "";
            textbox_teacher_password.Text = "";
            button_teacher_save.Text = "Add";
            button_teacher_delete.Enabled = false;
            textbox_teacher_username.Enabled = true;
        }

        /// <summary>
        /// Callback for when the "Reset" button is clicked in the Teacher menu. This method reverts the information in the data fields to their original state.
        /// The original state varies based off of whether the user has anything currently selected. If they do, it repopulates the fields with that Teacher's
        /// original information. If they do not, it empties all of the fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Delete" button is clicked in the Teacher panel. This method is used to trigger the deletion of the Teacher in the system.
        /// If no item is selected, nothing happens. An error message displays if the operation was uncessful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Save" or "Add" button is clicked in the Teacher panel. The button has the text "Save" when updating an already existing Teacher
        /// and the text "Add" when creating a new Teacher to the system. This is determined by checking to see if an element is selected before proceding with
        /// the operation. If any of the fields are left empty an error message is displayed for the user. The password must also meet the specified requirements.
        /// If the operation was uncessful, another error message is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback that occurs when a new item is selected in the DBA Listbox. Upon change, it populates the data fields
        /// with the respective DBA's information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_dba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_dba.SelectedIndex > -1)
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


        /// <summary>
        /// Callback for when the DBA panel is made visible after clicking the "DBA" menu button. This method repopulates the DBA List
        /// and adds the data to the DBA listbox. The listbox contains all of the DBAs in the system, except for the DBA user. This is done
        /// to prevent the case where a DBA can delete from themselves from the system (and potentially have 0 DBAs for the system)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "DBA" button is clicked in the menu. It makes the DBA panel visible and the other panels not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_dba_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = false;
            panel_dba.Visible = true;
            panel_account.Visible = false;
        }

        /// <summary>
        /// Callback for when the "New" button is clicked in the DBA panel. This method is used to start creating a new DBA in the system.
        /// To do this, the method unselects the item from the Listbox and empties all of the data fields in the current panel. This method also disables
        /// the deletion button and renables the username textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_dba_new_Click(object sender, EventArgs e)
        {
            textBox_dba_fName.Text = "";
            textBox_dba_lName.Text = "";
            textBox_dba_username.Text = "";
            textBox_dba_password.Text = "";
            button_dba_delete.Enabled = false;
            textBox_dba_username.Enabled = true;
            button_dba_save.Text = "Add";
            listBox_dba.SelectedIndex = -1;
        }

        /// <summary>
        /// Callback for when the "Save" or "Add" button is clicked in the DBA panel. The button has the text "Save" when updating an already existing DBA
        /// and the text "Add" when creating a new DBA to the system. This is determined by checking to see if an element is selected before proceding with
        /// the operation. If any of the fields are left empty an error message is displayed for the user. The password must also meet the specified requirements.
        /// If the operation was uncessful, another error message is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Reset" button is clicked in the DBA panel. This method reverts the information in the data fields to their original state.
        /// The original state varies based off of whether the user has anything currently selected. If they do, it repopulates the fields with that DBA's
        /// original information. If they do not, it empties all of the fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Delete" button is clicked in the DBA panel. This method is used to trigger the deletion of the DBA in the system.
        /// If no item is selected, nothing happens. An error message displays if the operation was uncessful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Account" button is clicked in the menu. It makes the Account panel visible and the other panels not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_account_Click(object sender, EventArgs e)
        {
            panel_class.Visible = false;
            panel_teacher.Visible = false;
            panel_dba.Visible = false;
            panel_account.Visible = true;
        }

        /// <summary>
        /// Callback for when the Account panel is made visible after clicking the "Account" menu button. This method fills in the textboxes
        /// with the Users account information that was determined upon initlization of the DBA Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_account_VisibleChanged(object sender, EventArgs e)
        {
            textBox_account_fName.Text = dba.fName;
            textBox_account_lName.Text = dba.lName;
            textBox_account_password.Text = "";
            textBox_account_confirmPassword.Text = "";
            label_account_error.Text = "";
        }

        /// <summary>
        /// Callback for when the "Reset" butotn is clicked in the Account panel. This method reverts all of the fields back to the original user's data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_account_reset_Click(object sender, EventArgs e)
        {
            textBox_account_fName.Text = dba.fName;
            textBox_account_lName.Text = dba.lName;
            textBox_account_password.Text = "";
            textBox_account_confirmPassword.Text = "";
            label_account_error.Text = "";
        }

        /// <summary>
        /// Callback for when the "Save" or is clicked in the Account panel and is used to update the user's account information. If any of the fields are
        /// left empty an error message is displayed for the user. The password must also meet the specified requirements. If the operation was uncessful,
        /// another error message is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Callback for when the "Logout" menu button is clicked. This button ends the DBA user's session with the system and returns to the Login screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_logout_Click(object sender, EventArgs e)
        {
            this.RemoveOwnedForm(this.OwnedForms.ElementAt(0));
            this.Close();
        }

        /// <summary>
        /// Method that is used to determine if the password is valid with the system's restrictions. The password must contain atleast 1 lower case letter,
        /// 1 upper case letter, and 1 number. It also must be longer than 8 characters. 
        /// </summary>
        /// <param name="pWord"></param> the password that needs to be tested for validity
        /// <returns></returns> returns 'true' if the password meets the requiremetns and 'false' otherwise
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
