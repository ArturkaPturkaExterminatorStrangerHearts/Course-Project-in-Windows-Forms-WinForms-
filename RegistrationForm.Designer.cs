
namespace WindowsFormsApp1
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.panel1Reg = new System.Windows.Forms.Panel();
            this.repeatPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.label2 = new System.Windows.Forms.Label();
            this.passFieldReg = new MaterialSkin.Controls.MaterialTextBox2();
            this.loginFieldReg = new MaterialSkin.Controls.MaterialTextBox2();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.panel1Reg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1Reg
            // 
            this.panel1Reg.BackColor = System.Drawing.Color.White;
            this.panel1Reg.Controls.Add(this.repeatPassword);
            this.panel1Reg.Controls.Add(this.label2);
            this.panel1Reg.Controls.Add(this.passFieldReg);
            this.panel1Reg.Controls.Add(this.loginFieldReg);
            this.panel1Reg.Controls.Add(this.RegisterButton);
            this.panel1Reg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Reg.Location = new System.Drawing.Point(3, 64);
            this.panel1Reg.Name = "panel1Reg";
            this.panel1Reg.Size = new System.Drawing.Size(416, 388);
            this.panel1Reg.TabIndex = 1;
            // 
            // repeatPassword
            // 
            this.repeatPassword.AnimateReadOnly = true;
            this.repeatPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.repeatPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.repeatPassword.Depth = 0;
            this.repeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repeatPassword.HelperText = "Повторите пароль";
            this.repeatPassword.HideSelection = true;
            this.repeatPassword.Hint = "Подтвердите пароль *";
            this.repeatPassword.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("repeatPassword.LeadingIcon")));
            this.repeatPassword.Location = new System.Drawing.Point(53, 215);
            this.repeatPassword.MaxLength = 16;
            this.repeatPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.repeatPassword.Name = "repeatPassword";
            this.repeatPassword.PasswordChar = '\0';
            this.repeatPassword.PrefixSuffixText = null;
            this.repeatPassword.ReadOnly = false;
            this.repeatPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.repeatPassword.SelectedText = "";
            this.repeatPassword.SelectionLength = 0;
            this.repeatPassword.SelectionStart = 0;
            this.repeatPassword.ShortcutsEnabled = true;
            this.repeatPassword.ShowAssistiveText = true;
            this.repeatPassword.Size = new System.Drawing.Size(311, 64);
            this.repeatPassword.TabIndex = 196;
            this.repeatPassword.TabStop = false;
            this.repeatPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.repeatPassword.TrailingIcon = null;
            this.repeatPassword.UseSystemPasswordChar = false;
            this.repeatPassword.Enter += new System.EventHandler(this.repeatPassword_Enter);
            this.repeatPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repeatPassword_KeyDown);
            this.repeatPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.repeatPassword_KeyPress);
            this.repeatPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.repeatPassword_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(50, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 202;
            // 
            // passFieldReg
            // 
            this.passFieldReg.AnimateReadOnly = true;
            this.passFieldReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.passFieldReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.passFieldReg.Depth = 0;
            this.passFieldReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passFieldReg.HelperText = "Придумайте пароль";
            this.passFieldReg.HideSelection = true;
            this.passFieldReg.Hint = "Пароль *";
            this.passFieldReg.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("passFieldReg.LeadingIcon")));
            this.passFieldReg.Location = new System.Drawing.Point(53, 130);
            this.passFieldReg.MaxLength = 16;
            this.passFieldReg.MouseState = MaterialSkin.MouseState.OUT;
            this.passFieldReg.Name = "passFieldReg";
            this.passFieldReg.PasswordChar = '\0';
            this.passFieldReg.PrefixSuffixText = null;
            this.passFieldReg.ReadOnly = false;
            this.passFieldReg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passFieldReg.SelectedText = "";
            this.passFieldReg.SelectionLength = 0;
            this.passFieldReg.SelectionStart = 0;
            this.passFieldReg.ShortcutsEnabled = true;
            this.passFieldReg.ShowAssistiveText = true;
            this.passFieldReg.Size = new System.Drawing.Size(311, 64);
            this.passFieldReg.TabIndex = 195;
            this.passFieldReg.TabStop = false;
            this.passFieldReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passFieldReg.TrailingIcon = global::WindowsFormsApp1.Properties.Resources.visibility;
            this.passFieldReg.UseSystemPasswordChar = false;
            this.passFieldReg.TrailingIconClick += new System.EventHandler(this.passFieldReg_TrailingIconClick);
            this.passFieldReg.Enter += new System.EventHandler(this.passFieldReg_Enter);
            this.passFieldReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passFieldReg_KeyPress);
            this.passFieldReg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passFieldReg_KeyUp);
            // 
            // loginFieldReg
            // 
            this.loginFieldReg.AnimateReadOnly = true;
            this.loginFieldReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginFieldReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.loginFieldReg.Depth = 0;
            this.loginFieldReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.loginFieldReg.HelperText = "Придумайте логин";
            this.loginFieldReg.HideSelection = true;
            this.loginFieldReg.Hint = "Логин *";
            this.loginFieldReg.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("loginFieldReg.LeadingIcon")));
            this.loginFieldReg.Location = new System.Drawing.Point(53, 45);
            this.loginFieldReg.MaxLength = 16;
            this.loginFieldReg.MouseState = MaterialSkin.MouseState.OUT;
            this.loginFieldReg.Name = "loginFieldReg";
            this.loginFieldReg.PasswordChar = '\0';
            this.loginFieldReg.PrefixSuffixText = null;
            this.loginFieldReg.ReadOnly = false;
            this.loginFieldReg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginFieldReg.SelectedText = "";
            this.loginFieldReg.SelectionLength = 0;
            this.loginFieldReg.SelectionStart = 0;
            this.loginFieldReg.ShortcutsEnabled = true;
            this.loginFieldReg.ShowAssistiveText = true;
            this.loginFieldReg.Size = new System.Drawing.Size(311, 64);
            this.loginFieldReg.TabIndex = 194;
            this.loginFieldReg.TabStop = false;
            this.loginFieldReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loginFieldReg.TrailingIcon = null;
            this.loginFieldReg.UseSystemPasswordChar = false;
            this.loginFieldReg.Enter += new System.EventHandler(this.loginFieldReg_Enter);
            this.loginFieldReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginFieldReg_KeyPress);
            this.loginFieldReg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginFieldReg_KeyUp);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.RegisterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(240)))));
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RegisterButton.Location = new System.Drawing.Point(85, 297);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(244, 47);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Зарегистрировать";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 455);
            this.Controls.Add(this.panel1Reg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.panel1Reg.ResumeLayout(false);
            this.panel1Reg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1Reg;
        private System.Windows.Forms.Button RegisterButton;
        private MaterialSkin.Controls.MaterialTextBox2 loginFieldReg;
        private MaterialSkin.Controls.MaterialTextBox2 passFieldReg;
        private MaterialSkin.Controls.MaterialTextBox2 repeatPassword;
        private System.Windows.Forms.Label label2;
    }
}