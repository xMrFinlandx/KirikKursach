
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.SubjectComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LetterComboBox = new System.Windows.Forms.ComboBox();
            this.ExamsCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.ClassSearchGroupBox.SuspendLayout();
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
            this.DataTableView.Location = new System.Drawing.Point(237, 13);
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.RowHeadersVisible = false;
            this.DataTableView.Size = new System.Drawing.Size(769, 424);
            this.DataTableView.TabIndex = 2;
            // 
            // ClassSearchGroupBox
            // 
            this.ClassSearchGroupBox.Controls.Add(this.ExamsCheckBox);
            this.ClassSearchGroupBox.Controls.Add(this.label4);
            this.ClassSearchGroupBox.Controls.Add(this.label3);
            this.ClassSearchGroupBox.Controls.Add(this.StudentComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.SubjectComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.label2);
            this.ClassSearchGroupBox.Controls.Add(this.NumberComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.label1);
            this.ClassSearchGroupBox.Controls.Add(this.LetterComboBox);
            this.ClassSearchGroupBox.Location = new System.Drawing.Point(16, 53);
            this.ClassSearchGroupBox.Name = "ClassSearchGroupBox";
            this.ClassSearchGroupBox.Size = new System.Drawing.Size(205, 224);
            this.ClassSearchGroupBox.TabIndex = 6;
            this.ClassSearchGroupBox.TabStop = false;
            this.ClassSearchGroupBox.Text = "Поиск и добавление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ученик";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Предмет";
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(10, 143);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(184, 21);
            this.StudentComboBox.TabIndex = 9;
            this.StudentComboBox.SelectedIndexChanged += new System.EventHandler(this.StudentComboBox_SelectedIndexChanged);
            // 
            // SubjectComboBox
            // 
            this.SubjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectComboBox.FormattingEnabled = true;
            this.SubjectComboBox.Location = new System.Drawing.Point(10, 89);
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
            // ExamsCheckBox
            // 
            this.ExamsCheckBox.AutoSize = true;
            this.ExamsCheckBox.Location = new System.Drawing.Point(10, 191);
            this.ExamsCheckBox.Name = "ExamsCheckBox";
            this.ExamsCheckBox.Size = new System.Drawing.Size(130, 17);
            this.ExamsCheckBox.TabIndex = 12;
            this.ExamsCheckBox.Text = "Показать экзамены";
            this.ExamsCheckBox.UseVisualStyleBackColor = true;
            this.ExamsCheckBox.Click += new System.EventHandler(this.ExamsCheckBox_Click);
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Location = new System.Drawing.Point(36, 293);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(157, 23);
            this.ClearFilterButton.TabIndex = 13;
            this.ClearFilterButton.Text = "Очистить фильтры";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 449);
            this.Controls.Add(this.ClearFilterButton);
            this.Controls.Add(this.ClassSearchGroupBox);
            this.Controls.Add(this.DataTableView);
            this.Controls.Add(this.WelcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Teacher";
            this.Text = "Teacher";
            this.Load += new System.EventHandler(this.Teacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.ClassSearchGroupBox.ResumeLayout(false);
            this.ClassSearchGroupBox.PerformLayout();
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
    }
}