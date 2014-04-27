using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher
{
    public partial class TeacherInterface : Form
    {
        Teacher teacher;
        public TeacherInterface(String username)
        {
            teacher = new Teacher(username);
            InitializeComponent();
            CustomInit();
            panel_classes.Visible = true;
        }

        private void CustomInit()
        {
            this.panel_account.VisibleChanged += new System.EventHandler(this.panel_account_VisibleChanged);
            this.panel_classes.VisibleChanged += new System.EventHandler(this.panel_classes_VisibleChanged);
            this.panel_exercises.VisibleChanged += new System.EventHandler(this.panel_exercises_VisibleChanged);
            this.panel_students.VisibleChanged += new System.EventHandler(this.panel_students_VisibleChanged);
            this.listBox_classes.SelectedIndexChanged += new System.EventHandler(this.listBox_classes_SelectedIndexChanged);
            this.tabs_classes.SelectedIndexChanged += new System.EventHandler(this.tabs_classes_SelectedIndexChanged);
            this.listBox_classes_students.SelectedIndexChanged += new System.EventHandler(this.listBox_classes_students_SelectedIndexChanged);
            this.listBox_exercises.SelectedIndexChanged += new System.EventHandler(this.listBox_exercise_SelectedIndexChanged);
            this.listBox_students.SelectedIndexChanged += new System.EventHandler(this.listBox_students_SelectedIndexChanged);
            
            listBox_classes.DisplayMember = "name";
            listBox_classes.ValueMember = "id";
            listBox_classes_students.DisplayMember = "FullName";
            listBox_classes_students.ValueMember = "username";
            listBox_classes_studentsEnrolled.DisplayMember = "FullName";
            listBox_classes_studentsEnrolled.ValueMember = "username";
            listBox_classes_studentsNotEnrolled.DisplayMember = "FullName";
            listBox_classes_studentsNotEnrolled.ValueMember = "username";
            listBox_classes_exercisesIn.DisplayMember = "name";
            listBox_classes_exercisesIn.ValueMember = "id";
            listBox_classes_exercisesNotIn.DisplayMember = "name";
            listBox_classes_exercisesNotIn.ValueMember = "id";
            listBox_exercises.DisplayMember = "name";
            listBox_exercises.ValueMember = "id";
            listBox_students.DisplayMember = "FullName";
            listBox_students.ValueMember = "username";
            comboBox_students_classes.DisplayMember = "name";
            comboBox_students_classes.ValueMember = "id";
        }
        #region Menu Button Clicks
        private void button_menu_classes_Click(object sender, EventArgs e)
        {
            if(!panel_classes.Visible)
            {
                panel_classes.Visible = true;
            }
            panel_exercises.Visible = false;
            panel_students.Visible = false;
            panel_account.Visible = false;
        }

        private void button_menu_exercises_Click(object sender, EventArgs e)
        {
            if (!panel_exercises.Visible)
            {
                panel_exercises.Visible = true;
            }
            panel_classes.Visible = false;
            panel_students.Visible = false;
            panel_account.Visible = false;
        }

        private void button_menu_students_Click(object sender, EventArgs e)
        {
            if (!panel_students.Visible)
            {
                panel_students.Visible = true;
            }
            panel_classes.Visible = false;
            panel_exercises.Visible = false;
            panel_account.Visible = false;
        }

        private void button_menu_account_Click(object sender, EventArgs e)
        {
            if (!panel_account.Visible)
            {
                panel_account.Visible = true;
            }
            panel_classes.Visible = false;
            panel_exercises.Visible = false;
            panel_students.Visible = false;
        }

        private void button_menu_logout_Click(object sender, EventArgs e)
        {
            this.RemoveOwnedForm(this.OwnedForms.ElementAt(0));
            this.Close();
        }
        #endregion

        #region Classes
        private void panel_classes_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_classes.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("classes panel visible changed");
            teacher.classes = Class.Generate(teacher);
            listBox_classes.DataSource = teacher.classes;
        }

        private void listBox_classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("selected index changed to: " + listBox_classes.SelectedIndex);
            if(tabs_classes.SelectedTab == tab_classes_students)
            {
                PopulateClassesStudentsTab();
            }
            else if (tabs_classes.SelectedTab == tab_classes_enrollment)
            {
                PopulateClassesEnrollmentTab();
            }
            else
            {
                PopulateClassesExercisesTab();
            }
        }

        private void tabs_classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabs_classes.SelectedTab == tab_classes_students)
            {
                PopulateClassesStudentsTab();
            }
            else if (tabs_classes.SelectedTab == tab_classes_enrollment)
            {
                PopulateClassesEnrollmentTab();
            }
            else if (tabs_classes.SelectedTab == tab_classes_exercises)
            {
                PopulateClassesExercisesTab();
            }
        }
        
        private void PopulateClassesStudentsTab()
        {
            System.Diagnostics.Debug.WriteLine("populating students tab");
            int c = listBox_classes.SelectedIndex;
            teacher.classes[c].students = Student.GenerateIn(teacher.classes[c]);
            listBox_classes_students.DataSource = teacher.classes[c].students;
            listView_classes_students_results.Items.Clear();
        }

        private void listBox_classes_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_classes_students_results.Items.Clear();
            int c = listBox_classes.SelectedIndex;
            int s = listBox_classes_students.SelectedIndex;
            teacher.classes[c].students[s].results = ExerciseResult.Generate(teacher.classes[c].students[s]);

            foreach(ExerciseResult er in teacher.classes[c].students[s].results)
            {
                ListViewItem item = new ListViewItem(Exercise.GetName(er.exId));
                item.SubItems.Add(er.errorCount.ToString());
                item.SubItems.Add(er.time.ToString());
                listView_classes_students_results.Items.Add(item);
            }
        }

        private void PopulateClassesEnrollmentTab()
        {
            System.Diagnostics.Debug.WriteLine("populating enrollment tab");
            int c = listBox_classes.SelectedIndex;
            List<Student> notEnrolled = Student.GenerateNotEnrolled();
            listBox_classes_studentsNotEnrolled.DataSource = notEnrolled;
            List<Student> enrolled = Student.GenerateIn(teacher.classes[c]);
            listBox_classes_studentsEnrolled.DataSource = enrolled;
        }

        private void button_classes_enrollmentLeft_Click(object sender, EventArgs e)
        {
            if (listBox_classes_studentsEnrolled.SelectedIndices.Count == 0)
            {
                return;
            }
            ListBox.SelectedObjectCollection col = listBox_classes_studentsEnrolled.SelectedItems;
            foreach(Student student in col)
            {
                student.RemoveFromClass();
            }
            PopulateClassesEnrollmentTab();
        }

        private void button_classes_enrollmentRight_Click(object sender, EventArgs e)
        {
            if (listBox_classes_studentsNotEnrolled.SelectedIndices.Count == 0)
            {
                return;
            }
            ListBox.SelectedObjectCollection col = listBox_classes_studentsNotEnrolled.SelectedItems;
            foreach (Student student in col)
            {
                student.AddToClass(teacher.classes[listBox_classes.SelectedIndex]);
            }
            PopulateClassesEnrollmentTab();
        }

        private void button_classes_enrollmentRemoveAll_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection col = listBox_classes_studentsEnrolled.Items;
            foreach (Student student in col)
            {
                student.RemoveFromClass();
            }
            PopulateClassesEnrollmentTab();
        }

        private void PopulateClassesExercisesTab()
        {
            System.Diagnostics.Debug.WriteLine("populating exercises tab");
            Class c = (Class)listBox_classes.SelectedItem;
            List<Exercise> notInClass = Exercise.GenerateNotInClass(c);
            listBox_classes_exercisesNotIn.DataSource = notInClass;
            List<Exercise> inClass = Exercise.GenerateInClass(c);
            listBox_classes_exercisesIn.DataSource = inClass;
        }

        private void button_classes_exercisesLeft_Click(object sender, EventArgs e)
        {
            if (listBox_classes_exercisesIn.SelectedIndices.Count == 0)
            {
                return;
            }
            ListBox.SelectedObjectCollection col = listBox_classes_exercisesIn.SelectedItems;
            Class c = (Class)listBox_classes.SelectedItem;
            foreach (Exercise ex in col)
            {
                ex.RemoveFromClass(c);
            }
            PopulateClassesExercisesTab();
        }

        private void button_classes_exercisesRight_Click(object sender, EventArgs e)
        {
            if(listBox_classes_exercisesNotIn.SelectedItems.Count == 0)
            {
                return;
            }
            ListBox.SelectedObjectCollection col = listBox_classes_exercisesNotIn.SelectedItems;
            Class c = (Class)listBox_classes.SelectedItem;
            foreach(Exercise ex in col)
            {
                ex.AddToClass(c);
            }
            PopulateClassesExercisesTab();
        }

        private void button_classes_exercisesRemoveAll_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection col = listBox_classes_exercisesIn.Items;
            Class c = (Class)listBox_classes.SelectedItem;
            foreach(Exercise ex in col)
            {
                ex.RemoveFromClass(c);
            }
            PopulateClassesExercisesTab();
        }
        #endregion

        #region Exercises
        private void panel_exercises_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_exercises.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("exercises panel visible changed");
            PopulateExerciseList();
        }
        
        private void listBox_exercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("selected index changed to: " + listBox_classes.SelectedIndex);
            Exercise ex = (Exercise)listBox_exercises.SelectedItem;
            if (ex == null) return;
            textBox_exercises_name.Text = ex.name;
            textBox_exercises_text.Text = ex.text;
            button_exercises_save.Text = "Save";
            button_exercises_delete.Enabled = true;
        }

        private void PopulateExerciseList()
        {
            teacher.exercises = Exercise.Generate(teacher);
            listBox_exercises.DataSource = teacher.exercises;
        }

        private void button_exercises_new_Click(object sender, EventArgs e)
        {
            textBox_exercises_name.Text = String.Empty;
            textBox_exercises_text.Text = String.Empty;
            listBox_exercises.ClearSelected();
            button_exercises_save.Text = "Add";
            button_exercises_delete.Enabled = false;
        }

        private void button_exercises_reset_Click(object sender, EventArgs e)
        {
            if (listBox_exercises.SelectedItem != null)
            {
                Exercise ex = (Exercise)listBox_exercises.SelectedItem;
                textBox_exercises_name.Text = ex.name;
                textBox_exercises_text.Text = ex.text;
            }
            else
            {
                textBox_exercises_name.Text = String.Empty;
                textBox_exercises_text.Text = String.Empty;
            }
        }

        private void button_exercises_delete_Click(object sender, EventArgs e)
        {
            Exercise ex = (Exercise)listBox_exercises.SelectedItem;
            ex.Delete();
            PopulateExerciseList();
        }

        private void button_exercises_save_Click(object sender, EventArgs e)
        {
            if(textBox_exercises_name.Text.Length == 0 || textBox_exercises_text.Text.Length == 0)
            {
                MessageBox.Show("Both fields required!");
                return;
            }
            if (listBox_exercises.SelectedItem != null)
            {
                Exercise ex = (Exercise)listBox_exercises.SelectedItem;
                ex.Update(textBox_exercises_name.Text, textBox_exercises_text.Text);
            }
            else
            {
                Exercise newEx = new Exercise(textBox_exercises_name.Text, textBox_exercises_text.Text, teacher);
                newEx.Add();
            }
            PopulateExerciseList();
        }
        #endregion

        #region Students
        private void panel_students_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_students.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("students panel visible changed");
            PopulateStudentPanel();
        }

        private void listBox_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("listBox_students_SelectedIndexChanged");
            Student st = (Student)listBox_students.SelectedItem;
            if (st == null) return;
            textBox_students_fName.Text = st.fName;
            textBox_students_lName.Text = st.lName;
            textBox_students_password.Text = String.Empty;
            textBox_students_username.Text = st.username;
            if (st.studentClass != null)
            {
                comboBox_students_classes.SelectedValue = st.studentClass.id;
            }
            else
            {
                comboBox_students_classes.SelectedValue = -1;
            }
            button_students_save.Text = "Save";
            button_students_delete.Enabled = true;
            textBox_students_username.Enabled = false;
        }

        private void PopulateStudentPanel()
        {
            System.Diagnostics.Debug.WriteLine("PopulateStudentPanel");
            PopulateStudentClassDropDown();
            PopulateStudentList();
        }

        private void PopulateStudentList()
        {
            System.Diagnostics.Debug.WriteLine("PopulateStudentList");
            List<Student> studentList = new List<Student>();
            studentList.AddRange(Student.GenerateNotEnrolled());
            studentList.AddRange(Student.GenerateIn(teacher.classes));
            listBox_students.DataSource = studentList;
        }

        private void PopulateStudentClassDropDown()
        {
            System.Diagnostics.Debug.WriteLine("PopulateStudentClassDropDown");
            teacher.classes = Class.Generate(teacher);
            List<Class> classList = teacher.classes;
            classList.Insert(0, Class.Empty);
            comboBox_students_classes.DataSource = classList;
        }

        private void button_students_new_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button_students_new_Click");
            listBox_students.ClearSelected();
            textBox_students_fName.Text = String.Empty;
            textBox_students_lName.Text = String.Empty;
            textBox_students_password.Text = String.Empty;
            textBox_students_username.Text = String.Empty;
            button_students_save.Text = "Add";
            button_students_delete.Enabled = false;
            textBox_students_username.Enabled = true;
            comboBox_students_classes.SelectedValue = -1;

        }

        private void button_students_reset_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button_students_reset_Click");
            if (listBox_students.SelectedItem != null)
            {
                Student st = (Student)listBox_students.SelectedItem;
                textBox_students_fName.Text = st.fName;
                textBox_students_lName.Text = st.lName;
                textBox_students_password.Text = String.Empty;
                textBox_students_username.Text = st.username;
                comboBox_students_classes.SelectedValue = (st.studentClass == null) ? -1 : st.studentClass.id;
            }
            else
            {
                textBox_students_fName.Text = String.Empty;
                textBox_students_lName.Text = String.Empty;
                textBox_students_password.Text = String.Empty;
                textBox_students_username.Text = String.Empty;
                comboBox_students_classes.SelectedValue = -1;
            }
        }

        private void button_students_delete_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button_students_delete_Click");
            Student st = (Student)listBox_students.SelectedItem;
            st.Delete();
            PopulateStudentList();
        }

        private void button_students_save_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button_students_save_Click");
            
            if(textBox_students_fName.Text.Length == 0 || textBox_students_lName.Text.Length == 0 || textBox_students_username.Text.Length == 0)
            {
                MessageBox.Show("First Name, Last Name, Username, and Password fields are required.");
                return;
            }

            if(!PasswordMeetsRequirements(textBox_students_password.Text))
            {
                MessageBox.Show("Entered password do not meet minimum requirements: 1 upper case letter, 1 lower case letter, 1 digit, and length of at least 8.");
                return;
            }
            Class c = (Class)comboBox_students_classes.SelectedItem;
            if (c.id == -1)
            {
                c = null;
            }
            if (listBox_students.SelectedItem == null)
            {
                Student st = new Student(textBox_students_username.Text, textBox_students_password.Text, textBox_students_fName.Text, textBox_students_lName.Text, c);
                if(!st.Add())
                {
                    MessageBox.Show("Error adding student.  Check that the username supplied is not already in use.");
                }
            }
            else
            {
                Student st = (Student)listBox_students.SelectedItem;
                if (!st.Update(textBox_students_password.Text, textBox_students_fName.Text, textBox_students_lName.Text, c))
                {
                    MessageBox.Show("Error updating student.");
                }
            }
            PopulateStudentList();
        }

        #endregion

        #region Account
        private void panel_account_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_account.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("account panel visible changed");
            textBox_account_fName.Text = teacher.fName;
            textBox_account_lName.Text = teacher.lName;
        }

        private void button_account_reset_Click(object sender, EventArgs e)
        {
            textBox_account_fName.Text = teacher.fName;
            textBox_account_lName.Text = teacher.lName;
            textBox_account_password.Text = String.Empty;
            textBox_account_confirmPassword.Text = String.Empty;
        }

        private void button_account_save_Click(object sender, EventArgs e)
        {
            if (textBox_account_fName.Text.Length == 0 || textBox_account_lName.Text.Length == 0)
            {
                MessageBox.Show("First Name, Last Name, and Passwords are required fields.");
                return;
            }

            if(textBox_account_password.Text.Equals(textBox_account_confirmPassword.Text, StringComparison.Ordinal))
            {
                if (PasswordMeetsRequirements(textBox_account_password.Text))
                {
                    teacher.Update(textBox_account_password.Text, textBox_account_fName.Text, textBox_account_lName.Text);
                    textBox_account_password.Text = String.Empty;
                    textBox_account_confirmPassword.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Entered passwords do not meet minimum requirements: 1 upper case letter, 1 lower case letter, 1 digit, and length of at least 8.");
                    textBox_account_password.Text = String.Empty;
                    textBox_account_confirmPassword.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Entered passwords do not match.");
                textBox_account_password.Text = String.Empty;
                textBox_account_confirmPassword.Text = String.Empty;
            }
        }

        #endregion

        private bool PasswordMeetsRequirements(String pWord)
        {
            bool upper = false;
            bool lower = false;
            bool digit = false;
            if(pWord.Length >= 8)
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
