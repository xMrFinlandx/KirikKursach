
namespace SchoolKursach.Forms
{
    partial class AddChanges
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
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.PreviousTableButton = new System.Windows.Forms.Button();
            this.NextTableButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DeleteIdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddUserGroupBox = new System.Windows.Forms.GroupBox();
            this.ClassGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LetterComboBox = new System.Windows.Forms.ComboBox();
            this.NumberComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FIOTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddSubjectGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.HoursTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.AddPlanGroupBox = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SubjectComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TeacherComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PlanLetterComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PlanNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TableNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AddUserGroupBox.SuspendLayout();
            this.ClassGroupBox.SuspendLayout();
            this.AddSubjectGroupBox.SuspendLayout();
            this.AddPlanGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTableView
            // 
            this.DataTableView.AllowUserToAddRows = false;
            this.DataTableView.AllowUserToDeleteRows = false;
            this.DataTableView.AllowUserToOrderColumns = true;
            this.DataTableView.AllowUserToResizeRows = false;
            this.DataTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTableView.Location = new System.Drawing.Point(300, 20);
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataTableView.RowHeadersVisible = false;
            this.DataTableView.Size = new System.Drawing.Size(737, 385);
            this.DataTableView.TabIndex = 3;
            // 
            // PreviousTableButton
            // 
            this.PreviousTableButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.PreviousTableButton.Location = new System.Drawing.Point(300, 411);
            this.PreviousTableButton.Name = "PreviousTableButton";
            this.PreviousTableButton.Size = new System.Drawing.Size(157, 23);
            this.PreviousTableButton.TabIndex = 5;
            this.PreviousTableButton.Text = "Предыдущая таблица";
            this.PreviousTableButton.UseVisualStyleBackColor = false;
            this.PreviousTableButton.Click += new System.EventHandler(this.PreviousTableButton_Click);
            // 
            // NextTableButton
            // 
            this.NextTableButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.NextTableButton.Location = new System.Drawing.Point(880, 411);
            this.NextTableButton.Name = "NextTableButton";
            this.NextTableButton.Size = new System.Drawing.Size(157, 23);
            this.NextTableButton.TabIndex = 4;
            this.NextTableButton.Text = "Следующая таблица";
            this.NextTableButton.UseVisualStyleBackColor = false;
            this.NextTableButton.Click += new System.EventHandler(this.NextTableButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.BackButton.Location = new System.Drawing.Point(12, 411);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(80, 23);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.DeleteIdTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 52);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Удаление";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.DeleteButton.Location = new System.Drawing.Point(181, 17);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(86, 23);
            this.DeleteButton.TabIndex = 19;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DeleteIdTextBox
            // 
            this.DeleteIdTextBox.Location = new System.Drawing.Point(72, 19);
            this.DeleteIdTextBox.Name = "DeleteIdTextBox";
            this.DeleteIdTextBox.Size = new System.Drawing.Size(86, 20);
            this.DeleteIdTextBox.TabIndex = 17;
            this.DeleteIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DeleteIdTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "ID записи:";
            // 
            // AddUserGroupBox
            // 
            this.AddUserGroupBox.Controls.Add(this.ClassGroupBox);
            this.AddUserGroupBox.Controls.Add(this.label4);
            this.AddUserGroupBox.Controls.Add(this.label3);
            this.AddUserGroupBox.Controls.Add(this.PassTextBox);
            this.AddUserGroupBox.Controls.Add(this.LoginTextBox);
            this.AddUserGroupBox.Controls.Add(this.label2);
            this.AddUserGroupBox.Controls.Add(this.FIOTextBox);
            this.AddUserGroupBox.Controls.Add(this.label1);
            this.AddUserGroupBox.Controls.Add(this.RoleComboBox);
            this.AddUserGroupBox.Location = new System.Drawing.Point(12, 87);
            this.AddUserGroupBox.Name = "AddUserGroupBox";
            this.AddUserGroupBox.Size = new System.Drawing.Size(273, 274);
            this.AddUserGroupBox.TabIndex = 8;
            this.AddUserGroupBox.TabStop = false;
            this.AddUserGroupBox.Text = "Добавление";
            // 
            // ClassGroupBox
            // 
            this.ClassGroupBox.Controls.Add(this.label5);
            this.ClassGroupBox.Controls.Add(this.LetterComboBox);
            this.ClassGroupBox.Controls.Add(this.NumberComboBox);
            this.ClassGroupBox.Controls.Add(this.label6);
            this.ClassGroupBox.Location = new System.Drawing.Point(19, 195);
            this.ClassGroupBox.Name = "ClassGroupBox";
            this.ClassGroupBox.Size = new System.Drawing.Size(235, 73);
            this.ClassGroupBox.TabIndex = 12;
            this.ClassGroupBox.TabStop = false;
            this.ClassGroupBox.Text = "Класс";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Номер";
            // 
            // LetterComboBox
            // 
            this.LetterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LetterComboBox.FormattingEnabled = true;
            this.LetterComboBox.Location = new System.Drawing.Point(6, 46);
            this.LetterComboBox.Name = "LetterComboBox";
            this.LetterComboBox.Size = new System.Drawing.Size(71, 21);
            this.LetterComboBox.TabIndex = 9;
            // 
            // NumberComboBox
            // 
            this.NumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberComboBox.FormattingEnabled = true;
            this.NumberComboBox.Location = new System.Drawing.Point(158, 46);
            this.NumberComboBox.Name = "NumberComboBox";
            this.NumberComboBox.Size = new System.Drawing.Size(71, 21);
            this.NumberComboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Буква";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Логин";
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(19, 169);
            this.PassTextBox.MaxLength = 100;
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(235, 20);
            this.PassTextBox.TabIndex = 5;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(19, 128);
            this.LoginTextBox.MaxLength = 100;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(235, 20);
            this.LoginTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ФИО";
            // 
            // FIOTextBox
            // 
            this.FIOTextBox.Location = new System.Drawing.Point(19, 46);
            this.FIOTextBox.MaxLength = 100;
            this.FIOTextBox.Name = "FIOTextBox";
            this.FIOTextBox.Size = new System.Drawing.Size(235, 20);
            this.FIOTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Должность";
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Location = new System.Drawing.Point(19, 86);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(235, 21);
            this.RoleComboBox.TabIndex = 0;
            this.RoleComboBox.SelectedIndexChanged += new System.EventHandler(this.RoleComboBox_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.AddButton.Location = new System.Drawing.Point(109, 367);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(82, 23);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddSubjectGroupBox
            // 
            this.AddSubjectGroupBox.Controls.Add(this.label7);
            this.AddSubjectGroupBox.Controls.Add(this.HoursTextBox);
            this.AddSubjectGroupBox.Controls.Add(this.label12);
            this.AddSubjectGroupBox.Controls.Add(this.SubjectTextBox);
            this.AddSubjectGroupBox.Location = new System.Drawing.Point(12, 173);
            this.AddSubjectGroupBox.Name = "AddSubjectGroupBox";
            this.AddSubjectGroupBox.Size = new System.Drawing.Size(273, 133);
            this.AddSubjectGroupBox.TabIndex = 13;
            this.AddSubjectGroupBox.TabStop = false;
            this.AddSubjectGroupBox.Text = "Добавление";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Часы";
            // 
            // HoursTextBox
            // 
            this.HoursTextBox.Location = new System.Drawing.Point(19, 93);
            this.HoursTextBox.MaxLength = 100;
            this.HoursTextBox.Name = "HoursTextBox";
            this.HoursTextBox.Size = new System.Drawing.Size(62, 20);
            this.HoursTextBox.TabIndex = 4;
            this.HoursTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HoursTextBox_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Предмет";
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(19, 46);
            this.SubjectTextBox.MaxLength = 100;
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(235, 20);
            this.SubjectTextBox.TabIndex = 2;
            // 
            // AddPlanGroupBox
            // 
            this.AddPlanGroupBox.Controls.Add(this.label13);
            this.AddPlanGroupBox.Controls.Add(this.SubjectComboBox);
            this.AddPlanGroupBox.Controls.Add(this.label11);
            this.AddPlanGroupBox.Controls.Add(this.TeacherComboBox);
            this.AddPlanGroupBox.Controls.Add(this.groupBox2);
            this.AddPlanGroupBox.Location = new System.Drawing.Point(12, 103);
            this.AddPlanGroupBox.Name = "AddPlanGroupBox";
            this.AddPlanGroupBox.Size = new System.Drawing.Size(273, 222);
            this.AddPlanGroupBox.TabIndex = 14;
            this.AddPlanGroupBox.TabStop = false;
            this.AddPlanGroupBox.Text = "Добавление";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Предмет";
            // 
            // SubjectComboBox
            // 
            this.SubjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectComboBox.FormattingEnabled = true;
            this.SubjectComboBox.Location = new System.Drawing.Point(24, 180);
            this.SubjectComboBox.Name = "SubjectComboBox";
            this.SubjectComboBox.Size = new System.Drawing.Size(223, 21);
            this.SubjectComboBox.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Учитель";
            // 
            // TeacherComboBox
            // 
            this.TeacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeacherComboBox.FormattingEnabled = true;
            this.TeacherComboBox.Location = new System.Drawing.Point(24, 113);
            this.TeacherComboBox.Name = "TeacherComboBox";
            this.TeacherComboBox.Size = new System.Drawing.Size(223, 21);
            this.TeacherComboBox.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PlanLetterComboBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.PlanNumberComboBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 73);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Класс";
            // 
            // PlanLetterComboBox
            // 
            this.PlanLetterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanLetterComboBox.FormattingEnabled = true;
            this.PlanLetterComboBox.Location = new System.Drawing.Point(18, 36);
            this.PlanLetterComboBox.Name = "PlanLetterComboBox";
            this.PlanLetterComboBox.Size = new System.Drawing.Size(71, 21);
            this.PlanLetterComboBox.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Номер";
            // 
            // PlanNumberComboBox
            // 
            this.PlanNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanNumberComboBox.FormattingEnabled = true;
            this.PlanNumberComboBox.Location = new System.Drawing.Point(170, 36);
            this.PlanNumberComboBox.Name = "PlanNumberComboBox";
            this.PlanNumberComboBox.Size = new System.Drawing.Size(71, 21);
            this.PlanNumberComboBox.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Буква";
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Location = new System.Drawing.Point(300, 4);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(41, 13);
            this.TableNameLabel.TabIndex = 15;
            this.TableNameLabel.Text = "label14";
            // 
            // AddChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1049, 450);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.AddPlanGroupBox);
            this.Controls.Add(this.AddSubjectGroupBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddUserGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PreviousTableButton);
            this.Controls.Add(this.NextTableButton);
            this.Controls.Add(this.DataTableView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddChanges";
            this.Text = "Внести изменения";
            this.Load += new System.EventHandler(this.AddChanges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AddUserGroupBox.ResumeLayout(false);
            this.AddUserGroupBox.PerformLayout();
            this.ClassGroupBox.ResumeLayout(false);
            this.ClassGroupBox.PerformLayout();
            this.AddSubjectGroupBox.ResumeLayout(false);
            this.AddSubjectGroupBox.PerformLayout();
            this.AddPlanGroupBox.ResumeLayout(false);
            this.AddPlanGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTableView;
        private System.Windows.Forms.Button PreviousTableButton;
        private System.Windows.Forms.Button NextTableButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DeleteIdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.GroupBox AddUserGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.TextBox FIOTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox ClassGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox LetterComboBox;
        private System.Windows.Forms.ComboBox NumberComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox AddSubjectGroupBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SubjectTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox HoursTextBox;
        private System.Windows.Forms.GroupBox AddPlanGroupBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox PlanLetterComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox PlanNumberComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox TeacherComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox SubjectComboBox;
        private System.Windows.Forms.Label TableNameLabel;
    }
}