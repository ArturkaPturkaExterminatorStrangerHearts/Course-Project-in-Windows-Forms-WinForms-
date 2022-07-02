
namespace WindowsFormsApp1
{
    partial class Staff_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff_Add));
            this.Add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new WindowsFormsApp1.ADatePicker();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(240)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add.Location = new System.Drawing.Point(159, 452);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(228, 41);
            this.Add.TabIndex = 319;
            this.Add.TabStop = false;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(5, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 315;
            this.label6.Text = "Дата рождения";
            // 
            // textBox6
            // 
            this.textBox6.AnimateReadOnly = true;
            this.textBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.Depth = 0;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox6.HideSelection = true;
            this.textBox6.LeadingIcon = null;
            this.textBox6.Location = new System.Drawing.Point(292, 312);
            this.textBox6.MaxLength = 3000;
            this.textBox6.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.PrefixSuffixText = null;
            this.textBox6.ReadOnly = false;
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox6.SelectedText = "";
            this.textBox6.SelectionLength = 0;
            this.textBox6.SelectionStart = 0;
            this.textBox6.ShortcutsEnabled = true;
            this.textBox6.Size = new System.Drawing.Size(238, 48);
            this.textBox6.TabIndex = 314;
            this.textBox6.TabStop = false;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox6.TrailingIcon = null;
            this.textBox6.UseSystemPasswordChar = false;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(5, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 20);
            this.label3.TabIndex = 313;
            this.label3.Text = "Контактный телефон";
            // 
            // textBox5
            // 
            this.textBox5.AnimateReadOnly = true;
            this.textBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.Depth = 0;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox5.HideSelection = true;
            this.textBox5.LeadingIcon = null;
            this.textBox5.Location = new System.Drawing.Point(292, 253);
            this.textBox5.MaxLength = 3000;
            this.textBox5.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.PrefixSuffixText = null;
            this.textBox5.ReadOnly = false;
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox5.SelectedText = "";
            this.textBox5.SelectionLength = 0;
            this.textBox5.SelectionStart = 0;
            this.textBox5.ShortcutsEnabled = true;
            this.textBox5.Size = new System.Drawing.Size(238, 48);
            this.textBox5.TabIndex = 312;
            this.textBox5.TabStop = false;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox5.TrailingIcon = null;
            this.textBox5.UseSystemPasswordChar = false;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(5, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 311;
            this.label4.Text = "Зарплата";
            // 
            // textBox4
            // 
            this.textBox4.AnimateReadOnly = true;
            this.textBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.Depth = 0;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox4.HideSelection = true;
            this.textBox4.LeadingIcon = null;
            this.textBox4.Location = new System.Drawing.Point(292, 194);
            this.textBox4.MaxLength = 3000;
            this.textBox4.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.PrefixSuffixText = null;
            this.textBox4.ReadOnly = false;
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(238, 48);
            this.textBox4.TabIndex = 310;
            this.textBox4.TabStop = false;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox4.TrailingIcon = null;
            this.textBox4.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(5, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 309;
            this.label5.Text = "Город";
            // 
            // textBox3
            // 
            this.textBox3.AnimateReadOnly = true;
            this.textBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.Depth = 0;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox3.HideSelection = true;
            this.textBox3.LeadingIcon = null;
            this.textBox3.Location = new System.Drawing.Point(292, 135);
            this.textBox3.MaxLength = 3000;
            this.textBox3.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.PrefixSuffixText = null;
            this.textBox3.ReadOnly = false;
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(238, 48);
            this.textBox3.TabIndex = 308;
            this.textBox3.TabStop = false;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox3.TrailingIcon = null;
            this.textBox3.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(5, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 307;
            this.label2.Text = "Должность";
            // 
            // textBox1
            // 
            this.textBox1.AnimateReadOnly = true;
            this.textBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.HideSelection = true;
            this.textBox1.LeadingIcon = null;
            this.textBox1.Location = new System.Drawing.Point(292, 76);
            this.textBox1.MaxLength = 3000;
            this.textBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PrefixSuffixText = null;
            this.textBox1.ReadOnly = false;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(238, 48);
            this.textBox1.TabIndex = 306;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TrailingIcon = null;
            this.textBox1.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(5, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 305;
            this.label1.Text = "ФИО";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dateTimePicker1.BorderSize = 0;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTimePicker1.Location = new System.Drawing.Point(292, 376);
            this.dateTimePicker1.MinDate = new System.DateTime(1945, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 35);
            this.dateTimePicker1.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.dateTimePicker1.TabIndex = 320;
            this.dateTimePicker1.TextColor = System.Drawing.Color.White;
            // 
            // Staff_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 518);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Staff_Add";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить запись";
            this.Load += new System.EventHandler(this.Staff_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialTextBox2 textBox6;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialTextBox2 textBox5;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 textBox4;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialTextBox2 textBox3;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 textBox1;
        private System.Windows.Forms.Label label1;
        private ADatePicker dateTimePicker1;
    }
}