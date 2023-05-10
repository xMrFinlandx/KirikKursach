
namespace SchoolKursach.Forms
{
    partial class Teacher
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.ClassSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.QuarterComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.AssessmentTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExamsCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.SubjectComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LetterComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NewAssessmentTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.ClassSearchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(13, 13);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "label1";
            // 
            // DataTableView
            // 
            this.DataTableView.AllowUserToAddRows = false;
            this.DataTableView.AllowUserToDeleteRows = false;
            this.DataTableView.AllowUserToResizeRows = false;
            this.DataTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTableView.Location = new System.Drawing.Point(237, 38);
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.RowHeadersVisible = false;
            this.DataTableView.Size = new System.Drawing.Size(769, 488);
            this.DataTableView.TabIndex = 2;
            // 
            // ClassSearchGroupBox
            // 
            this.ClassSearchGroupBox.Controls.Add(this.label6);
            this.ClassSearchGroupBox.Controls.Add(this.ClearFilterButton);
            this.ClassSearchGroupBox.Controls.Add(this.QuarterComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.groupBox1);
            this.ClassSearchGroupBox.Controls.Add(this.ExamsCheckBox);
            this.ClassSearchGroupBox.Controls.Add(this.label4);
            this.ClassSearchGroupBox.Controls.Add(this.label3);
            this.ClassSearchGroupBox.Controls.Add(this.StudentComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.SubjectComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.label2);
            this.ClassSearchGroupBox.Controls.Add(this.NumberComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.label1);
            this.ClassSearchGroupBox.Controls.Add(this.LetterComboBox);
            this.ClassSearchGroupBox.Location = new System.Drawing.Point(16, 38);
            this.ClassSearchGroupBox.Name = "ClassSearchGroupBox";
            this.ClassSearchGroupBox.Size = new System.Drawing.Size(205, 308);
            this.ClassSearchGroupBox.TabIndex = 6;
            this.ClassSearchGroupBox.TabStop = false;
            this.ClassSearchGroupBox.Text = "Поиск";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Четверть";
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClearFilterButton.Location = new System.Drawing.Point(18, 265);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(157, 35);
            this.ClearFilterButton.TabIndex = 13;
            this.ClearFilterButton.Text = "Очистить фильтры";
            this.ClearFilterButton.UseVisualStyleBackColor = false;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // QuarterComboBox
            // 
            this.QuarterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuarterComboBox.FormattingEnabled = true;
            this.QuarterComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.QuarterComboBox.Location = new System.Drawing.Point(9, 170);
            this.QuarterComboBox.Name = "QuarterComboBox";
            this.QuarterComboBox.Size = new System.Drawing.Size(49, 21);
            this.QuarterComboBox.TabIndex = 16;
            this.QuarterComboBox.SelectedIndexChanged += new System.EventHandler(this.QuarterComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.AssessmentTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 62);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.AddButton.Location = new System.Drawing.Point(119, 30);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(69, 23);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AssessmentTextBox
            // 
            this.AssessmentTextBox.Location = new System.Drawing.Point(63, 32);
            this.AssessmentTextBox.Name = "AssessmentTextBox";
            this.AssessmentTextBox.Size = new System.Drawing.Size(50, 20);
            this.AssessmentTextBox.TabIndex = 13;
            this.AssessmentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AssessmentTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Оценка:";
            // 
            // ExamsCheckBox
            // 
            this.ExamsCheckBox.AutoSize = true;
            this.ExamsCheckBox.Location = new System.Drawing.Point(67, 172);
            this.ExamsCheckBox.Name = "ExamsCheckBox";
            this.ExamsCheckBox.Size = new System.Drawing.Size(130, 17);
            this.ExamsCheckBox.TabIndex = 12;
            this.ExamsCheckBox.Text = "Показать экзамены";
            this.ExamsCheckBox.UseVisualStyleBackColor = true;
            this.ExamsCheckBox.Click += new System.EventHandler(this.ExamsCheckBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ученик";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Предмет";
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(9, 124);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(184, 21);
            this.StudentComboBox.TabIndex = 9;
            this.StudentComboBox.SelectedIndexChanged += new System.EventHandler(this.StudentComboBox_SelectedIndexChanged);
            // 
            // SubjectComboBox
            // 
            this.SubjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectComboBox.FormattingEnabled = true;
            this.SubjectComboBox.Location = new System.Drawing.Point(10, 78);
            this.SubjectComboBox.Name = "SubjectComboBox";
            this.SubjectComboBox.Size = new System.Drawing.Size(184, 21);
            this.SubjectComboBox.TabIndex = 8;
            this.SubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.SubjectComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Номер";
            // 
            // NumberComboBox
            // 
            this.NumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberComboBox.FormattingEnabled = true;
            this.NumberComboBox.Location = new System.Drawing.Point(123, 33);
            this.NumberComboBox.Name = "NumberComboBox";
            this.NumberComboBox.Size = new System.Drawing.Size(71, 21);
            this.NumberComboBox.TabIndex = 6;
            this.NumberComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Буква";
            // 
            // LetterComboBox
            // 
            this.LetterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LetterComboBox.FormattingEnabled = true;
            this.LetterComboBox.Location = new System.Drawing.Point(10, 33);
            this.LetterComboBox.Name = "LetterComboBox";
            this.LetterComboBox.Size = new System.Drawing.Size(71, 21);
            this.LetterComboBox.TabIndex = 5;
            this.LetterComboBox.SelectedIndexChanged += new System.EventHandler(this.LetterComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteButton);
            this.groupBox2.Controls.Add(this.ChangeButton);
            this.groupBox2.Controls.Add(this.IDTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.NewAssessmentTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(16, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 120);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изменение / Удаление";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.DeleteButton.Location = new System.Drawing.Point(108, 87);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(86, 23);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ChangeButton.Location = new System.Drawing.Point(5, 87);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(87, 23);
            this.ChangeButton.TabIndex = 15;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(108, 26);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(86, 20);
            this.IDTextBox.TabIndex = 15;
            this.IDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "ID записи:";
            // 
            // NewAssessmentTextBox
            // 
            this.NewAssessmentTextBox.Location = new System.Drawing.Point(108, 52);
            this.NewAssessmentTextBox.Name = "NewAssessmentTextBox";
            this.NewAssessmentTextBox.Size = new System.Drawing.Size(86, 20);
            this.NewAssessmentTextBox.TabIndex = 13;
            this.NewAssessmentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewAssessmentTextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Новая оценка:";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ExitButton.Location = new System.Drawing.Point(21, 503);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(189, 23);
            this.ExitButton.TabIndex = 18;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1018, 535);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ClassSearchGroupBox);
            this.Controls.Add(this.DataTableView);
            this.Controls.Add(this.WelcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Teacher";
            this.Text = "Учитель";
            this.Load += new System.EventHandler(this.Teacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.ClassSearchGroupBox.ResumeLayout(false);
            this.ClassSearchGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.DataGridView DataTableView;
        private System.Windows.Forms.GroupBox ClassSearchGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NumberComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LetterComboBox;
        private System.Windows.Forms.ComboBox StudentComboBox;
        private System.Windows.Forms.ComboBox SubjectComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ExamsCheckBox;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox AssessmentTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox QuarterComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NewAssessmentTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ExitButton;
    }
}