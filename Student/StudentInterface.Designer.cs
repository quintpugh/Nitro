namespace Student
{
    partial class StudentInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBox_ExerciseList = new System.Windows.Forms.ListBox();
            this.Label_Exercises = new System.Windows.Forms.Label();
            this.Panel_StartExercise = new System.Windows.Forms.Panel();
            this.Button_Start = new System.Windows.Forms.Button();
            this.Panel_PerformExercise = new System.Windows.Forms.Panel();
            this.Button_PerformExerciseSubmit = new System.Windows.Forms.Button();
            this.Textbox_InputText = new System.Windows.Forms.RichTextBox();
            this.Textbox_ExerciseText = new System.Windows.Forms.RichTextBox();
            this.Panel_ExerciseResult = new System.Windows.Forms.Panel();
            this.Button_ExcerciseResultsNextExercise = new System.Windows.Forms.Button();
            this.Label_ExerciseTimeToComplete = new System.Windows.Forms.Label();
            this.Label_ExerciseErrorCount = new System.Windows.Forms.Label();
            this.Label_ExerciseNameResults = new System.Windows.Forms.Label();
            this.Panel_StartExercise.SuspendLayout();
            this.Panel_PerformExercise.SuspendLayout();
            this.Panel_ExerciseResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_ExerciseList
            // 
            this.ListBox_ExerciseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_ExerciseList.FormattingEnabled = true;
            this.ListBox_ExerciseList.ItemHeight = 25;
            this.ListBox_ExerciseList.Location = new System.Drawing.Point(12, 80);
            this.ListBox_ExerciseList.Name = "ListBox_ExerciseList";
            this.ListBox_ExerciseList.Size = new System.Drawing.Size(165, 204);
            this.ListBox_ExerciseList.TabIndex = 0;
            this.ListBox_ExerciseList.SelectedIndexChanged += new System.EventHandler(this.ListBox_ExerciseList_SelectedIndexChanged);
            // 
            // Label_Exercises
            // 
            this.Label_Exercises.AutoSize = true;
            this.Label_Exercises.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Exercises.Location = new System.Drawing.Point(12, 52);
            this.Label_Exercises.Name = "Label_Exercises";
            this.Label_Exercises.Size = new System.Drawing.Size(106, 25);
            this.Label_Exercises.TabIndex = 1;
            this.Label_Exercises.Text = "Exercises";
            // 
            // Panel_StartExercise
            // 
            this.Panel_StartExercise.Controls.Add(this.Button_Start);
            this.Panel_StartExercise.Location = new System.Drawing.Point(183, 80);
            this.Panel_StartExercise.Name = "Panel_StartExercise";
            this.Panel_StartExercise.Size = new System.Drawing.Size(637, 450);
            this.Panel_StartExercise.TabIndex = 2;
            // 
            // Button_Start
            // 
            this.Button_Start.BackColor = System.Drawing.Color.LawnGreen;
            this.Button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Start.Location = new System.Drawing.Point(163, 138);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(318, 166);
            this.Button_Start.TabIndex = 0;
            this.Button_Start.Text = "Start";
            this.Button_Start.UseVisualStyleBackColor = false;
            this.Button_Start.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // Panel_PerformExercise
            // 
            this.Panel_PerformExercise.Controls.Add(this.Button_PerformExerciseSubmit);
            this.Panel_PerformExercise.Controls.Add(this.Textbox_InputText);
            this.Panel_PerformExercise.Controls.Add(this.Textbox_ExerciseText);
            this.Panel_PerformExercise.Location = new System.Drawing.Point(183, 80);
            this.Panel_PerformExercise.Name = "Panel_PerformExercise";
            this.Panel_PerformExercise.Size = new System.Drawing.Size(637, 450);
            this.Panel_PerformExercise.TabIndex = 1;
            this.Panel_PerformExercise.Visible = false;
            // 
            // Button_PerformExerciseSubmit
            // 
            this.Button_PerformExerciseSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_PerformExerciseSubmit.Location = new System.Drawing.Point(264, 382);
            this.Button_PerformExerciseSubmit.Name = "Button_PerformExerciseSubmit";
            this.Button_PerformExerciseSubmit.Size = new System.Drawing.Size(108, 49);
            this.Button_PerformExerciseSubmit.TabIndex = 2;
            this.Button_PerformExerciseSubmit.Text = "Submit";
            this.Button_PerformExerciseSubmit.UseVisualStyleBackColor = true;
            this.Button_PerformExerciseSubmit.Click += new System.EventHandler(this.Button_PerformExerciseSubmit_Click);
            // 
            // Textbox_InputText
            // 
            this.Textbox_InputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox_InputText.Location = new System.Drawing.Point(3, 201);
            this.Textbox_InputText.Name = "Textbox_InputText";
            this.Textbox_InputText.Size = new System.Drawing.Size(631, 165);
            this.Textbox_InputText.TabIndex = 1;
            this.Textbox_InputText.Text = "";
            this.Textbox_InputText.TextChanged += new System.EventHandler(this.Textbox_InputText_TextChanged);
            this.Textbox_InputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_InputText_KeyDown);
            // 
            // Textbox_ExerciseText
            // 
            this.Textbox_ExerciseText.Enabled = false;
            this.Textbox_ExerciseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox_ExerciseText.Location = new System.Drawing.Point(3, 3);
            this.Textbox_ExerciseText.Name = "Textbox_ExerciseText";
            this.Textbox_ExerciseText.Size = new System.Drawing.Size(631, 175);
            this.Textbox_ExerciseText.TabIndex = 0;
            this.Textbox_ExerciseText.Text = "";
            // 
            // Panel_ExerciseResult
            // 
            this.Panel_ExerciseResult.Controls.Add(this.Button_ExcerciseResultsNextExercise);
            this.Panel_ExerciseResult.Controls.Add(this.Label_ExerciseTimeToComplete);
            this.Panel_ExerciseResult.Controls.Add(this.Label_ExerciseErrorCount);
            this.Panel_ExerciseResult.Controls.Add(this.Label_ExerciseNameResults);
            this.Panel_ExerciseResult.Location = new System.Drawing.Point(183, 80);
            this.Panel_ExerciseResult.Name = "Panel_ExerciseResult";
            this.Panel_ExerciseResult.Size = new System.Drawing.Size(637, 450);
            this.Panel_ExerciseResult.TabIndex = 3;
            this.Panel_ExerciseResult.Visible = false;
            // 
            // Button_ExcerciseResultsNextExercise
            // 
            this.Button_ExcerciseResultsNextExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ExcerciseResultsNextExercise.Location = new System.Drawing.Point(204, 250);
            this.Button_ExcerciseResultsNextExercise.Name = "Button_ExcerciseResultsNextExercise";
            this.Button_ExcerciseResultsNextExercise.Size = new System.Drawing.Size(217, 72);
            this.Button_ExcerciseResultsNextExercise.TabIndex = 3;
            this.Button_ExcerciseResultsNextExercise.Text = "Next Exercise";
            this.Button_ExcerciseResultsNextExercise.UseVisualStyleBackColor = true;
            this.Button_ExcerciseResultsNextExercise.Click += new System.EventHandler(this.Button_ExcerciseResultsNextExercise_Click);
            // 
            // Label_ExerciseTimeToComplete
            // 
            this.Label_ExerciseTimeToComplete.AutoSize = true;
            this.Label_ExerciseTimeToComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ExerciseTimeToComplete.Location = new System.Drawing.Point(63, 110);
            this.Label_ExerciseTimeToComplete.Name = "Label_ExerciseTimeToComplete";
            this.Label_ExerciseTimeToComplete.Size = new System.Drawing.Size(186, 25);
            this.Label_ExerciseTimeToComplete.TabIndex = 2;
            this.Label_ExerciseTimeToComplete.Text = "Time to Complete:";
            // 
            // Label_ExerciseErrorCount
            // 
            this.Label_ExerciseErrorCount.AutoSize = true;
            this.Label_ExerciseErrorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ExerciseErrorCount.Location = new System.Drawing.Point(121, 73);
            this.Label_ExerciseErrorCount.Name = "Label_ExerciseErrorCount";
            this.Label_ExerciseErrorCount.Size = new System.Drawing.Size(128, 25);
            this.Label_ExerciseErrorCount.TabIndex = 1;
            this.Label_ExerciseErrorCount.Text = "Error Count:";
            // 
            // Label_ExerciseNameResults
            // 
            this.Label_ExerciseNameResults.AutoSize = true;
            this.Label_ExerciseNameResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ExerciseNameResults.Location = new System.Drawing.Point(86, 37);
            this.Label_ExerciseNameResults.Name = "Label_ExerciseNameResults";
            this.Label_ExerciseNameResults.Size = new System.Drawing.Size(163, 25);
            this.Label_ExerciseNameResults.TabIndex = 0;
            this.Label_ExerciseNameResults.Text = "Exercise Name:";
            // 
            // StudentInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 542);
            this.Controls.Add(this.Panel_ExerciseResult);
            this.Controls.Add(this.Panel_PerformExercise);
            this.Controls.Add(this.Panel_StartExercise);
            this.Controls.Add(this.Label_Exercises);
            this.Controls.Add(this.ListBox_ExerciseList);
            this.Name = "StudentInterface";
            this.Text = "Student";
            this.Panel_StartExercise.ResumeLayout(false);
            this.Panel_PerformExercise.ResumeLayout(false);
            this.Panel_ExerciseResult.ResumeLayout(false);
            this.Panel_ExerciseResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_ExerciseList;
        private System.Windows.Forms.Label Label_Exercises;
        private System.Windows.Forms.Panel Panel_StartExercise;
        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Panel Panel_PerformExercise;
        private System.Windows.Forms.Button Button_PerformExerciseSubmit;
        private System.Windows.Forms.RichTextBox Textbox_InputText;
        private System.Windows.Forms.RichTextBox Textbox_ExerciseText;
        private System.Windows.Forms.Panel Panel_ExerciseResult;
        private System.Windows.Forms.Label Label_ExerciseTimeToComplete;
        private System.Windows.Forms.Label Label_ExerciseErrorCount;
        private System.Windows.Forms.Label Label_ExerciseNameResults;
        private System.Windows.Forms.Button Button_ExcerciseResultsNextExercise;
    }
}