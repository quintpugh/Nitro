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
    /// <summary>
    /// This is the user interface for the student module.
    /// It handles all interaction with the user.
    /// </summary>
    public partial class StudentInterface : Form
    {
        private DateTime startTime;
        private int prevTextLength;
        private Exercise exercisePerforming;
        private List<Exercise> exercises;
        private Student student;

        /// <summary>
        /// Creates the student interface, as well as ties the current user to the one in
        /// the database
        /// </summary>
        /// <param name="uName"> The username of the student who was authenticating</param>
        public StudentInterface(String uName)
        {
            InitializeComponent();
            this.student = new Student(uName);
            label_welcome.Text = "Welcome, " + student.fName + "!";
            PopulateExerciseList();
        }
        /// <summary>
        /// Generates a list of exercises that need to be completed by the current student and
        /// uses the list to populate the list box.  In the case of the exercise list being empty,
        /// it displays a message telling the user they have no exercises to complete.
        /// </summary>
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

        }

        /// <summary>
        /// Loads the currently selected exercise and logs the start time, so the
        /// user can begin performing the exercise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method detects the differences between what the user is typing and the exercise text as they are typing.
        /// When text is detected to be the same, input text color is changed to green.  It is otherwise changed to red.
        /// This method also detects where spaces should be located according to the exercise text.  Spaces will automatically be inserted when
        /// the user reaches the end of a word. Spacebar input is ignored after this is done until the user types another letter.
        /// The method handles newlines in the same fashion as spaces.  Length of input is checked in case the user pressed backspace after a space was inserted,
        /// so an infinite loop is not created.  Once the user has entered 90% of the exercise text, the submit button is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                //If the current word should be done, add the needed amount of spaces and move cursor
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
                //Same as above, but for newlines
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

        /// <summary>
        /// This method sets the user's completion time and error count. It calculates the total time from when start is clicked to when submit is clicked.
        /// It also goes through all of the text and counts the number of red characters.  Then the amount of missing or extra characters is added to the error count.
        /// An ExerciseResult object with this information, as well as the current student, is created and added to the database.
        /// Then the exercise is removed from the list of possible exercises, and the user is shown there results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method is called when the user clicks the Next Exercise button after they have completed an execise.  It will select the next exercise
        /// and display the start button.  If there are not any more exercises, a message saying so will be displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method shows the start button for the currently selected exercise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method detects which key is currently being pressed.  It handles the backspace and the spacebar specifically.
        /// When the spacebar is detected, it will suppress the key press and check where the next word is in the exercise text.
        /// Once the next word is found, the correct number of spaces are inserted until the input text has reached the correct position.
        /// The backspace key will detect if the previous character is a space or a newline. If that is the case, it will delete both the space
        /// and the letter before it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_performExercise_inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                //Check if the last character typed was a space, then find where the next word should be in the exercise
                //and go fill in spaces until we get there.
                if (textBox_performExercise_inputText.Text.ElementAtOrDefault(textBox_performExercise_inputText.TextLength - 1) != ' ')
                {
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

        /// <summary>
        /// This method revokes the ownership of the Login Interface from the current Student Interface and
        /// closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_menu_logout_Click(object sender, EventArgs e)
        {
            this.RemoveOwnedForm(this.OwnedForms.ElementAt(0));
            this.Close();
        }
    }
}
