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
            

            listBox_classes.DisplayMember = "name";
            listBox_classes.ValueMember = "id";
            listBox_classes_students.DisplayMember = "FullName";
            listBox_classes_students.ValueMember = "username";
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

        }
        #endregion
        
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
        }

        private void PopulateClassesExercisesTab()
        {
            System.Diagnostics.Debug.WriteLine("populating exercises tab");
        }

        private void panel_exercises_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_exercises.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("exercises panel visible changed");
        }

        private void panel_students_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_students.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("students panel visible changed");
        }

        private void panel_account_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel_account.Visible)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("account panel visible changed");
        }
    }
}
