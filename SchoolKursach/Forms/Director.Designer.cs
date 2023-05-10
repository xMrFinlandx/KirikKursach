
namespace SchoolKursach.Forms
{
    partial class Director
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
            this.NextTableButton = new System.Windows.Forms.Button();
            this.PreviousTableButton = new System.Windows.Forms.Button();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchComboBox = new System.Windows.Forms.ComboBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.LetterComboBox = new System.Windows.Forms.ComboBox();
            this.NumberComboBox = new System.Windows.Forms.ComboBox();
            this.ClassSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubjectSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectNameTextBox = new System.Windows.Forms.TextBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddChangesButton = new System.Windows.Forms.Button();
            this.TableNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.SearchGroupBox.SuspendLayout();
            this.ClassSearchGroupBox.SuspendLayout();
            this.SubjectSearchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextTableButton
            // 
            this.NextTableButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.NextTableButton.Location = new System.Drawing.Point(829, 415);
            this.NextTableButton.Name = "NextTableButton";
            this.NextTableButton.Size = new System.Drawing.Size(157, 23);
            this.NextTableButton.TabIndex = 0;
            this.NextTableButton.Text = "Следующая таблица";
            this.NextTableButton.UseVisualStyleBackColor = false;
            this.NextTableButton.Click += new System.EventHandler(this.NextTableButton_Click);
            // 
            // PreviousTableButton
            // 
            this.PreviousTableButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.PreviousTableButton.Location = new System.Drawing.Point(249, 415);
            this.PreviousTableButton.Name = "PreviousTableButton";
            this.PreviousTableButton.Size = new System.Drawing.Size(157, 23);
            this.PreviousTableButton.TabIndex = 1;
            this.PreviousTableButton.Text = "Предыдущая таблица";
            this.PreviousTableButton.UseVisualStyleBackColor = false;
            this.PreviousTableButton.Click += new System.EventHandler(this.PreviousTableButton_Click);
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
            this.DataTableView.Location = new System.Drawing.Point(249, 32);
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataTableView.RowHeadersVisible = false;
            this.DataTableView.Size = new System.Drawing.Size(737, 366);
            this.DataTableView.TabIndex = 2;
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.SearchComboBox);
            this.SearchGroupBox.Location = new System.Drawing.Point(23, 42);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(204, 65);
            this.SearchGroupBox.TabIndex = 3;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "Поиск";
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchComboBox.FormattingEnabled = true;
            this.SearchComboBox.Location = new System.Drawing.Point(10, 32);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(184, 21);
            this.SearchComboBox.TabIndex = 2;
            this.SearchComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox_SelectedIndexChanged);
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClearFilterButton.Location = new System.Drawing.Point(47, 116);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(157, 23);
            this.ClearFilterButton.TabIndex = 4;
            this.ClearFilterButton.Text = "Очистить фильтры";
            this.ClearFilterButton.UseVisualStyleBackColor = false;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
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
            // ClassSearchGroupBox
            // 
            this.ClassSearchGroupBox.Controls.Add(this.label2);
            this.ClassSearchGroupBox.Controls.Add(this.NumberComboBox);
            this.ClassSearchGroupBox.Controls.Add(this.label1);
            this.ClassSearchGroupBox.Controls.Add(this.LetterComboBox);
            this.ClassSearchGroupBox.Location = new System.Drawing.Point(23, 42);
            this.ClassSearchGroupBox.Name = "ClassSearchGroupBox";
            this.ClassSearchGroupBox.Size = new System.Drawing.Size(204, 68);
            this.ClassSearchGroupBox.TabIndex = 5;
            this.ClassSearchGroupBox.TabStop = false;
            this.ClassSearchGroupBox.Text = "Поиск по классу";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Буква";
            // 
            // SubjectSearchGroupBox
            // 
            this.SubjectSearchGroupBox.Controls.Add(this.label3);
            this.SubjectSearchGroupBox.Controls.Add(this.SubjectNameTextBox);
            this.SubjectSearchGroupBox.Location = new System.Drawing.Point(23, 42);
            this.SubjectSearchGroupBox.Name = "SubjectSearchGroupBox";
            this.SubjectSearchGroupBox.Size = new System.Drawing.Size(204, 68);
            this.SubjectSearchGroupBox.TabIndex = 8;
            this.SubjectSearchGroupBox.TabStop = false;
            this.SubjectSearchGroupBox.Text = "Поиск по названию";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название предмета";
            // 
            // SubjectNameTextBox
            // 
            this.SubjectNameTextBox.Location = new System.Drawing.Point(10, 32);
            this.SubjectNameTextBox.MaxLength = 100;
            this.SubjectNameTextBox.Name = "SubjectNameTextBox";
            this.SubjectNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.SubjectNameTextBox.TabIndex = 0;
            this.SubjectNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SubjectNameTextBox_KeyPress);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(20, 9);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.WelcomeLabel.TabIndex = 9;
            this.WelcomeLabel.Text = "label4";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ExitButton.Location = new System.Drawing.Point(23, 415);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddChangesButton
            // 
            this.AddChangesButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.AddChangesButton.Location = new System.Drawing.Point(47, 175);
            this.AddChangesButton.Name = "AddChangesButton";
            this.AddChangesButton.Size = new System.Drawing.Size(157, 35);
            this.AddChangesButton.TabIndex = 11;
            this.AddChangesButton.Text = "Внести изменения";
            this.AddChangesButton.UseVisualStyleBackColor = false;
            this.AddChangesButton.Click += new System.EventHandler(this.AddChangesButton_Click);
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Location = new System.Drawing.Point(246, 16);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(35, 13);
            this.TableNameLabel.TabIndex = 12;
            this.TableNameLabel.Text = "label4";
            // 
            // Director
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.AddChangesButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.SubjectSearchGroupBox);
            this.Controls.Add(this.ClearFilterButton);
            this.Controls.Add(this.ClassSearchGroupBox);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.DataTableView);
            this.Controls.Add(this.PreviousTableButton);
            this.Controls.Add(this.NextTableButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Director";
            this.Text = "Директор";
            this.Load += new System.EventHandler(this.Director_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.SearchGroupBox.ResumeLayout(false);
            this.ClassSearchGroupBox.ResumeLayout(false);
            this.ClassSearchGroupBox.PerformLayout();
            this.SubjectSearchGroupBox.ResumeLayout(false);
            this.SubjectSearchGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NextTableButton;
        private System.Windows.Forms.Button PreviousTableButton;
        private System.Windows.Forms.DataGridView DataTableView;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.ComboBox SearchComboBox;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.ComboBox LetterComboBox;
        private System.Windows.Forms.ComboBox NumberComboBox;
        private System.Windows.Forms.GroupBox ClassSearchGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox SubjectSearchGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SubjectNameTextBox;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddChangesButton;
        private System.Windows.Forms.Label TableNameLabel;
    }
}