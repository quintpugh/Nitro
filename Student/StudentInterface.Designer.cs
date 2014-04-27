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
            this.listBox_exercisesList = new System.Windows.Forms.ListBox();
            this.label_exercisesList = new System.Windows.Forms.Label();
            this.panel_startExercise = new System.Windows.Forms.Panel();
            this.button_startExercise_start = new System.Windows.Forms.Button();
            this.panel_performExercise = new System.Windows.Forms.Panel();
            this.button_performExercise_submit = new System.Windows.Forms.Button();
            this.textBox_performExercise_inputText = new System.Windows.Forms.RichTextBox();
            this.textBox_performExercise_exerciseText = new System.Windows.Forms.RichTextBox();
            this.panel_exerciseResult = new System.Windows.Forms.Panel();
            this.button_exerciseResults_nextExercise = new System.Windows.Forms.Button();
            this.label_exceriseResults_timeToComplete = new System.Windows.Forms.Label();
            this.label_exerciseResults_errorCount = new System.Windows.Forms.Label();
            this.label_exerciseResults_exerciseName = new System.Windows.Forms.Label();
            this.panel_noExercise = new System.Windows.Forms.Panel();
            this.label_noExercises = new System.Windows.Forms.Label();
            this.button_menu_logout = new System.Windows.Forms.Button();
            this.label_welcome = new System.Windows.Forms.Label();
            this.panel_startExercise.SuspendLayout();
            this.panel_performExercise.SuspendLayout();
            this.panel_exerciseResult.SuspendLayout();
            this.panel_noExercise.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_exercisesList
            // 
            this.listBox_exercisesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_exercisesList.FormattingEnabled = true;
            this.listBox_exercisesList.ItemHeight = 25;
            this.listBox_exercisesList.Location = new System.Drawing.Point(12, 80);
            this.listBox_exercisesList.Name = "listBox_exercisesList";
            this.listBox_exercisesList.Size = new System.Drawing.Size(165, 204);
            this.listBox_exercisesList.TabIndex = 0;
            this.listBox_exercisesList.SelectedIndexChanged += new System.EventHandler(this.listBox_exercisesList_SelectedIndexChanged);
            // 
            // label_exercisesList
            // 
            this.label_exercisesList.AutoSize = true;
            this.label_exercisesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exercisesList.Location = new System.Drawing.Point(12, 52);
            this.label_exercisesList.Name = "label_exercisesList";
            this.label_exercisesList.Size = new System.Drawing.Size(106, 25);
            this.label_exercisesList.TabIndex = 1;
            this.label_exercisesList.Text = "Exercises";
            // 
            // panel_startExercise
            // 
            this.panel_startExercise.Controls.Add(this.button_startExercise_start);
            this.panel_startExercise.Location = new System.Drawing.Point(183, 80);
            this.panel_startExercise.Name = "panel_startExercise";
            this.panel_startExercise.Size = new System.Drawing.Size(637, 450);
            this.panel_startExercise.TabIndex = 2;
            // 
            // button_startExercise_start
            // 
            this.button_startExercise_start.BackColor = System.Drawing.Color.LawnGreen;
            this.button_startExercise_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_startExercise_start.Location = new System.Drawing.Point(163, 138);
            this.button_startExercise_start.Name = "button_startExercise_start";
            this.button_startExercise_start.Size = new System.Drawing.Size(318, 166);
            this.button_startExercise_start.TabIndex = 0;
            this.button_startExercise_start.Text = "Start";
            this.button_startExercise_start.UseVisualStyleBackColor = false;
            this.button_startExercise_start.Click += new System.EventHandler(this.button_startExercise_start_Click);
            // 
            // panel_performExercise
            // 
            this.panel_performExercise.Controls.Add(this.button_performExercise_submit);
            this.panel_performExercise.Controls.Add(this.textBox_performExercise_inputText);
            this.panel_performExercise.Controls.Add(this.textBox_performExercise_exerciseText);
            this.panel_performExercise.Location = new System.Drawing.Point(183, 80);
            this.panel_performExercise.Name = "panel_performExercise";
            this.panel_performExercise.Size = new System.Drawing.Size(637, 450);
            this.panel_performExercise.TabIndex = 1;
            this.panel_performExercise.Visible = false;
            // 
            // button_performExercise_submit
            // 
            this.button_performExercise_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_performExercise_submit.Location = new System.Drawing.Point(264, 382);
            this.button_performExercise_submit.Name = "button_performExercise_submit";
            this.button_performExercise_submit.Size = new System.Drawing.Size(108, 49);
            this.button_performExercise_submit.TabIndex = 2;
            this.button_performExercise_submit.Text = "Submit";
            this.button_performExercise_submit.UseVisualStyleBackColor = true;
            this.button_performExercise_submit.Click += new System.EventHandler(this.button_performExercise_submit_Click);
            // 
            // textBox_performExercise_inputText
            // 
            this.textBox_performExercise_inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_performExercise_inputText.Location = new System.Drawing.Point(3, 201);
            this.textBox_performExercise_inputText.Name = "textBox_performExercise_inputText";
            this.textBox_performExercise_inputText.ShortcutsEnabled = false;
            this.textBox_performExercise_inputText.Size = new System.Drawing.Size(631, 165);
            this.textBox_performExercise_inputText.TabIndex = 1;
            this.textBox_performExercise_inputText.Text = "";
            this.textBox_performExercise_inputText.TextChanged += new System.EventHandler(this.textBox_performExercise_inputText_TextChanged);
            this.textBox_performExercise_inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_performExercise_inputText_KeyDown);
            // 
            // textBox_performExercise_exerciseText
            // 
            this.textBox_performExercise_exerciseText.Enabled = false;
            this.textBox_performExercise_exerciseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_performExercise_exerciseText.Location = new System.Drawing.Point(3, 3);
            this.textBox_performExercise_exerciseText.Name = "textBox_performExercise_exerciseText";
            this.textBox_performExercise_exerciseText.Size = new System.Drawing.Size(631, 175);
            this.textBox_performExercise_exerciseText.TabIndex = 0;
            this.textBox_performExercise_exerciseText.Text = "";
            // 
            // panel_exerciseResult
            // 
            this.panel_exerciseResult.Controls.Add(this.button_exerciseResults_nextExercise);
            this.panel_exerciseResult.Controls.Add(this.label_exceriseResults_timeToComplete);
            this.panel_exerciseResult.Controls.Add(this.label_exerciseResults_errorCount);
            this.panel_exerciseResult.Controls.Add(this.label_exerciseResults_exerciseName);
            this.panel_exerciseResult.Location = new System.Drawing.Point(183, 80);
            this.panel_exerciseResult.Name = "panel_exerciseResult";
            this.panel_exerciseResult.Size = new System.Drawing.Size(637, 450);
            this.panel_exerciseResult.TabIndex = 3;
            this.panel_exerciseResult.Visible = false;
            // 
            // button_exerciseResults_nextExercise
            // 
            this.button_exerciseResults_nextExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exerciseResults_nextExercise.Location = new System.Drawing.Point(204, 250);
            this.button_exerciseResults_nextExercise.Name = "button_exerciseResults_nextExercise";
            this.button_exerciseResults_nextExercise.Size = new System.Drawing.Size(217, 72);
            this.button_exerciseResults_nextExercise.TabIndex = 3;
            this.button_exerciseResults_nextExercise.Text = "Next Exercise";
            this.button_exerciseResults_nextExercise.UseVisualStyleBackColor = true;
            this.button_exerciseResults_nextExercise.Click += new System.EventHandler(this.button_exerciseResults_nextExercise_Click);
            // 
            // label_exceriseResults_timeToComplete
            // 
            this.label_exceriseResults_timeToComplete.AutoSize = true;
            this.label_exceriseResults_timeToComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exceriseResults_timeToComplete.Location = new System.Drawing.Point(63, 110);
            this.label_exceriseResults_timeToComplete.Name = "label_exceriseResults_timeToComplete";
            this.label_exceriseResults_timeToComplete.Size = new System.Drawing.Size(186, 25);
            this.label_exceriseResults_timeToComplete.TabIndex = 2;
            this.label_exceriseResults_timeToComplete.Text = "Time to Complete:";
            // 
            // label_exerciseResults_errorCount
            // 
            this.label_exerciseResults_errorCount.AutoSize = true;
            this.label_exerciseResults_errorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exerciseResults_errorCount.Location = new System.Drawing.Point(121, 73);
            this.label_exerciseResults_errorCount.Name = "label_exerciseResults_errorCount";
            this.label_exerciseResults_errorCount.Size = new System.Drawing.Size(128, 25);
            this.label_exerciseResults_errorCount.TabIndex = 1;
            this.label_exerciseResults_errorCount.Text = "Error Count:";
            // 
            // label_exerciseResults_exerciseName
            // 
            this.label_exerciseResults_exerciseName.AutoSize = true;
            this.label_exerciseResults_exerciseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exerciseResults_exerciseName.Location = new System.Drawing.Point(86, 37);
            this.label_exerciseResults_exerciseName.Name = "label_exerciseResults_exerciseName";
            this.label_exerciseResults_exerciseName.Size = new System.Drawing.Size(163, 25);
            this.label_exerciseResults_exerciseName.TabIndex = 0;
            this.label_exerciseResults_exerciseName.Text = "Exercise Name:";
            // 
            // panel_noExercise
            // 
            this.panel_noExercise.Controls.Add(this.label_noExercises);
            this.panel_noExercise.Location = new System.Drawing.Point(183, 80);
            this.panel_noExercise.Name = "panel_noExercise";
            this.panel_noExercise.Size = new System.Drawing.Size(637, 450);
            this.panel_noExercise.TabIndex = 4;
            this.panel_noExercise.Visible = false;
            // 
            // label_noExercises
            // 
            this.label_noExercises.AutoSize = true;
            this.label_noExercises.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_noExercises.Location = new System.Drawing.Point(181, 173);
            this.label_noExercises.Name = "label_noExercises";
            this.label_noExercises.Size = new System.Drawing.Size(288, 74);
            this.label_noExercises.TabIndex = 0;
            this.label_noExercises.Text = "You have no more \r\n      exercises!";
            // 
            // button_menu_logout
            // 
            this.button_menu_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_menu_logout.Location = new System.Drawing.Point(12, 483);
            this.button_menu_logout.Name = "button_menu_logout";
            this.button_menu_logout.Size = new System.Drawing.Size(121, 47);
            this.button_menu_logout.TabIndex = 5;
            this.button_menu_logout.Text = "Logout";
            this.button_menu_logout.UseVisualStyleBackColor = true;
            this.button_menu_logout.Click += new System.EventHandler(this.button_menu_logout_Click);
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_welcome.Location = new System.Drawing.Point(445, 20);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(159, 37);
            this.label_welcome.TabIndex = 6;
            this.label_welcome.Text = "Welcome!";
            // 
            // StudentInterface
            // 
            this.AcceptButton = this.button_startExercise_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 542);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.button_menu_logout);
            this.Controls.Add(this.panel_noExercise);
            this.Controls.Add(this.panel_exerciseResult);
            this.Controls.Add(this.panel_performExercise);
            this.Controls.Add(this.panel_startExercise);
            this.Controls.Add(this.label_exercisesList);
            this.Controls.Add(this.listBox_exercisesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentInterface";
            this.Text = "Student";
            this.panel_startExercise.ResumeLayout(false);
            this.panel_performExercise.ResumeLayout(false);
            this.panel_exerciseResult.ResumeLayout(false);
            this.panel_exerciseResult.PerformLayout();
            this.panel_noExercise.ResumeLayout(false);
            this.panel_noExercise.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_exercisesList;
        private System.Windows.Forms.Label label_exercisesList;
        private System.Windows.Forms.Panel panel_startExercise;
        private System.Windows.Forms.Button button_startExercise_start;
        private System.Windows.Forms.Panel panel_performExercise;
        private System.Windows.Forms.Button button_performExercise_submit;
        private System.Windows.Forms.RichTextBox textBox_performExercise_inputText;
        private System.Windows.Forms.RichTextBox textBox_performExercise_exerciseText;
        private System.Windows.Forms.Panel panel_exerciseResult;
        private System.Windows.Forms.Label label_exceriseResults_timeToComplete;
        private System.Windows.Forms.Label label_exerciseResults_errorCount;
        private System.Windows.Forms.Label label_exerciseResults_exerciseName;
        private System.Windows.Forms.Button button_exerciseResults_nextExercise;
        private System.Windows.Forms.Panel panel_noExercise;
        private System.Windows.Forms.Label label_noExercises;
        private System.Windows.Forms.Button button_menu_logout;
        private System.Windows.Forms.Label label_welcome;
    }
}