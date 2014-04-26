using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class StudentInterface : Form
    {
        private DateTime startTime;
        private int prevTextLength;
        private Exercise exercisePerforming;
        private List<Exercise> exercises;
        private Student student;

        public StudentInterface(String uName)
        {
            InitializeComponent();
            this.student = new Student(uName);
            PopulateExerciseList();
        }

        private void PopulateExerciseList()
        {

            exercises = Exercise.ToBePerformed(student);
            ListBox_ExerciseList.DataSource = exercises;
            ListBox_ExerciseList.DisplayMember = "name";
            ListBox_ExerciseList.ValueMember = "text";
            Label_Exercises.Text = exercises.Count().ToString();
            ListBox_ExerciseList.SetSelected(0, true);

            // use exercises to populate ExerciseList

        } 

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            prevTextLength = 0;
            Panel_PerformExercise.Visible = true;
            Panel_StartExercise.Visible = false;
            ListBox_ExerciseList.Enabled = false;
            Textbox_InputText.Enabled = true;
            Textbox_InputText.ResetText();
            Textbox_InputText.Focus();
            this.AcceptButton = null;
        }

        private void Textbox_InputText_TextChanged(object sender, EventArgs e)
        {
            int start = Textbox_InputText.TextLength - 1;

            if (Textbox_InputText.TextLength > 0)
            {

                if (Textbox_InputText.Text.ElementAtOrDefault(start) != Textbox_ExerciseText.Text.ElementAtOrDefault(start))
                {
                    Textbox_InputText.Select(start, 1);
                    Textbox_InputText.SelectionColor = Color.Red;
                    Textbox_InputText.Select(start + 1, 0);
                }
                else
                {
                    Textbox_InputText.Select(start, 1);
                    Textbox_InputText.SelectionColor = Color.Green;
                    Textbox_InputText.Select(start + 1, 0);
                }

                //If the current word should be done, add a space and move cursor
                if (Textbox_ExerciseText.Text.ElementAtOrDefault(start + 1) == ' ' && Textbox_InputText.TextLength >= prevTextLength)
                {
                    Textbox_InputText.AppendText(" ");
                    Textbox_InputText.Select(start + 2, 0);
                }
                else if (Textbox_ExerciseText.Text.ElementAtOrDefault(start + 1) == '\n' && Textbox_InputText.TextLength >= prevTextLength)
                {
                    Textbox_InputText.AppendText("\n");
                    Textbox_InputText.Select(start + 2, 0);
                }
                prevTextLength = Textbox_InputText.TextLength;

                Button_PerformExerciseSubmit.Enabled = (Textbox_InputText.TextLength / (float)Textbox_ExerciseText.TextLength >= .9);
                this.AcceptButton = Button_PerformExerciseSubmit.Enabled ? Button_PerformExerciseSubmit : null;

            }
        }

        private void Button_PerformExerciseSubmit_Click(object sender, EventArgs e)
        {
            int errCount = 0;
            double compTime = (DateTime.Now - startTime).TotalSeconds;

            for (int i = 0; i < Textbox_InputText.TextLength; i++)
            {
                Textbox_InputText.Select(i, 1);
                if (Textbox_InputText.SelectionColor == Color.Red && !Textbox_InputText.SelectedText.Equals(" "))
                {
                    errCount++;
                }
            }
            errCount += Math.Abs(Textbox_ExerciseText.TextLength - Textbox_InputText.TextLength);

            Textbox_InputText.Select(0, 0);
            Panel_PerformExercise.Visible = false;

            Label_ExerciseErrorCount.Text = "Error Count: " + errCount;
            Label_ExerciseNameResults.Text = "Exercise Name: " + ListBox_ExerciseList.Text;
            Label_ExerciseTimeToComplete.Text = String.Format("Time to Complete: {0:f1} seconds", compTime);

            Panel_ExerciseResult.Visible = true;
            Button_PerformExerciseSubmit.Enabled = false;
            this.AcceptButton = Button_ExcerciseResultsNextExercise;
        }

        private void Button_ExcerciseResultsNextExercise_Click(object sender, EventArgs e)
        {
            int prevIndex = ListBox_ExerciseList.SelectedIndex;

            //exercises.RemoveAt(prevIndex);
            ListBox_ExerciseList.SelectedIndex = -1;
            /*ListBox_ExerciseList.DataSource = null;
            ListBox_ExerciseList.DataSource = exercises;
            ListBox_ExerciseList.SelectedIndex = prevIndex < exercises.Count ? prevIndex : prevIndex - 1;
            ListBox_ExerciseList.DisplayMember = "name";
            ListBox_ExerciseList.ValueMember = "text";*/
            ListBox_ExerciseList.Enabled = true;
            this.AcceptButton = Button_Start;
        }

        private void ListBox_ExerciseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_ExerciseList.SelectedIndex >= 0)
            {
                Textbox_ExerciseText.Text = ListBox_ExerciseList.SelectedValue.ToString();
                Textbox_InputText.ResetText();
                Textbox_InputText.Enabled = false;
                Panel_ExerciseResult.Visible = false;
                Panel_StartExercise.Visible = true;
            }
        }

        private void Textbox_InputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                //Check if the last character typed was a space, then find where the next word should be in the exercise
                //and go fill in spaces until we get there.
                if (Textbox_InputText.Text.ElementAtOrDefault(Textbox_InputText.TextLength - 1) != ' ')
                {
                    int start = Textbox_ExerciseText.Text.IndexOf(' ', Textbox_InputText.TextLength);
                    int diff = start - Textbox_InputText.TextLength;
                    Textbox_InputText.AppendText(new String(' ', diff));
                }
            }
            else if (e.KeyCode == Keys.Back)
            {

                if (Textbox_InputText.Text.ElementAtOrDefault(Textbox_InputText.TextLength - 1) == ' ' ||
                    Textbox_InputText.Text.ElementAtOrDefault(Textbox_InputText.TextLength - 1) == '\n')
                {
                    SendKeys.Send("{BS}"); //Send the backspace key again because it's easier
                }
            }
        }
    }
}
