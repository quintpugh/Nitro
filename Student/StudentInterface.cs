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
            label_welcome.Text = "Welcome, " + student.fName + "!";
            PopulateExerciseList();
        }

        private void PopulateExerciseList()
        {

            exercises = Exercise.ToBePerformed(student);
            listBox_exercisesList.DataSource = exercises;
            listBox_exercisesList.DisplayMember = "name";
            listBox_exercisesList.ValueMember = "text";

            if (exercises.Count() < 1)
            {
                panel_noExercise.Visible = true;
                panel_startExercise.Visible = false;
            }
            else
            {
                listBox_exercisesList.SetSelected(0, true);
            }
            // use exercises to populate ExerciseList

        }

        private void button_startExercise_start_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            prevTextLength = 0;
            panel_performExercise.Visible = true;
            panel_startExercise.Visible = false;
            listBox_exercisesList.Enabled = false;
            textBox_performExercise_inputText.Enabled = true;
            textBox_performExercise_inputText.ResetText();
            textBox_performExercise_inputText.Focus();
            exercisePerforming = exercises.ElementAt(listBox_exercisesList.SelectedIndex);
            this.AcceptButton = null;
        }

        private void textBox_performExercise_inputText_TextChanged(object sender, EventArgs e)
        {
            int start = textBox_performExercise_inputText.TextLength - 1;

            if (textBox_performExercise_inputText.TextLength > 0)
            {

                if (textBox_performExercise_inputText.Text.ElementAtOrDefault(start) != textBox_performExercise_exerciseText.Text.ElementAtOrDefault(start))
                {
                    textBox_performExercise_inputText.Select(start, 1);
                    textBox_performExercise_inputText.SelectionColor = Color.Red;
                    textBox_performExercise_inputText.Select(start + 1, 0);
                }
                else
                {
                    textBox_performExercise_inputText.Select(start, 1);
                    textBox_performExercise_inputText.SelectionColor = Color.Green;
                    textBox_performExercise_inputText.Select(start + 1, 0);
                }

                //If the current word should be done, add a space and move cursor
                int x = 1;
                if (textBox_performExercise_exerciseText.Text.ElementAtOrDefault(start + 1) == ' ' && textBox_performExercise_inputText.TextLength >= prevTextLength)
                {
                    while (textBox_performExercise_exerciseText.Text.ElementAtOrDefault(start + x) == ' ')
                    {
                        textBox_performExercise_inputText.AppendText(" ");
                        textBox_performExercise_inputText.Select(start + (x + 1), 0);
                        x++;
                    }
                }
                else if (textBox_performExercise_exerciseText.Text.ElementAtOrDefault(start + 1) == '\n' && textBox_performExercise_inputText.TextLength >= prevTextLength)
                {
                    while (textBox_performExercise_exerciseText.Text.ElementAtOrDefault(start + x) == '\n')
                    {
                        textBox_performExercise_inputText.AppendText("\n");
                        textBox_performExercise_inputText.Select(start + (x + 1), 0);
                    }
                }
                prevTextLength = textBox_performExercise_inputText.TextLength;

                button_performExercise_submit.Enabled = (textBox_performExercise_inputText.TextLength / (float)textBox_performExercise_exerciseText.TextLength >= .9);
                this.AcceptButton = button_performExercise_submit.Enabled ? button_performExercise_submit : null;

            }
        }

        private void button_performExercise_submit_Click(object sender, EventArgs e)
        {
            int errCount = 0;
            double compTime = (DateTime.Now - startTime).TotalSeconds;

            for (int i = 0; i < textBox_performExercise_inputText.TextLength; i++)
            {
                textBox_performExercise_inputText.Select(i, 1);
                if (textBox_performExercise_inputText.SelectionColor == Color.Red && !textBox_performExercise_inputText.SelectedText.Equals(" "))
                {
                    errCount++;
                }
            }
            errCount += Math.Abs(textBox_performExercise_exerciseText.TextLength - textBox_performExercise_inputText.TextLength);

            ExerciseResult result = new ExerciseResult(student, exercisePerforming.id, errCount, Convert.ToInt32(Math.Round(compTime)));
            result.Add();
            textBox_performExercise_inputText.Select(0, 0);
            panel_performExercise.Visible = false;

            label_exerciseResults_errorCount.Text = "Error Count: " + errCount;
            label_exerciseResults_exerciseName.Text = "Exercise Name: " + listBox_exercisesList.Text;
            label_exceriseResults_timeToComplete.Text = String.Format("Time to Complete: {0:f1} seconds", compTime);

            panel_exerciseResult.Visible = true;
            button_performExercise_submit.Enabled = false;
            this.AcceptButton = button_exerciseResults_nextExercise;
        }

        private void button_exerciseResults_nextExercise_Click(object sender, EventArgs e)
        {
            int prevIndex = listBox_exercisesList.SelectedIndex;
  
            if (exercises.Count > 0)
            {
                exercises.RemoveAt(prevIndex);
                listBox_exercisesList.SelectedIndex = -1;
                listBox_exercisesList.DataSource = null;
                listBox_exercisesList.DataSource = exercises;
                listBox_exercisesList.SelectedIndex = prevIndex < exercises.Count ? prevIndex : prevIndex - 1;
                listBox_exercisesList.DisplayMember = "name";
                listBox_exercisesList.ValueMember = "text";
                listBox_exercisesList.Enabled = true;
                this.AcceptButton = button_startExercise_start;
                button_startExercise_start.Focus();
            }

            if (exercises.Count < 1)
            {
                panel_noExercise.Visible = true;
                panel_exerciseResult.Visible = false;
            }
        }

        private void listBox_exercisesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_exercisesList.SelectedIndex >= 0)
            {
                textBox_performExercise_exerciseText.Text = listBox_exercisesList.SelectedValue.ToString();
                textBox_performExercise_inputText.ResetText();
                textBox_performExercise_inputText.Enabled = false;
                panel_exerciseResult.Visible = false;
                panel_startExercise.Visible = true;
                this.AcceptButton = button_startExercise_start;
            }
        }

        private void textBox_performExercise_inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                //Check if the last character typed was a space, then find where the next word should be in the exercise
                //and go fill in spaces until we get there.
                if (textBox_performExercise_inputText.Text.ElementAtOrDefault(textBox_performExercise_inputText.TextLength - 1) != ' ')
                {
                    //int start = Textbox_InputText.TextLength > Textbox_ExerciseText.TextLength ? -1 : Textbox_ExerciseText.Text.IndexOf(' ', Textbox_InputText.TextLength);
                    int start = textBox_performExercise_exerciseText.Text.LastIndexOf(' ') >= textBox_performExercise_inputText.TextLength - 1 ? textBox_performExercise_exerciseText.Text.IndexOf(' ', textBox_performExercise_inputText.TextLength) : textBox_performExercise_exerciseText.TextLength;
                    int diff = textBox_performExercise_inputText.TextLength > textBox_performExercise_exerciseText.TextLength ? 0 : start - textBox_performExercise_inputText.TextLength;
                     textBox_performExercise_inputText.AppendText(new String(' ', diff));
                }
            }
            else if (e.KeyCode == Keys.Back)
            {

                if (textBox_performExercise_inputText.Text.ElementAtOrDefault(textBox_performExercise_inputText.TextLength - 1) == ' ' ||
                    textBox_performExercise_inputText.Text.ElementAtOrDefault(textBox_performExercise_inputText.TextLength - 1) == '\n')
                {
                    SendKeys.Send("{BS}"); //Send the backspace key again because it's easier
                }
            }
        }

        private void button_menu_logout_Click(object sender, EventArgs e)
        {
            this.RemoveOwnedForm(this.OwnedForms.ElementAt(0));
            this.Close();
        }
    }
}
