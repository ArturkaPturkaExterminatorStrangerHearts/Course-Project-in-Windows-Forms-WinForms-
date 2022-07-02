
namespace WindowsFormsApp1
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginField = new MaterialSkin.Controls.MaterialTextBox2();
            this.loginButton = new System.Windows.Forms.Button();
            this.passField = new MaterialSkin.Controls.MaterialTextBox2();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.loginField);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.passField);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.label1.Name = "label1";
            // 
            // loginField
            // 
            this.loginField.AnimateReadOnly = true;
            resources.ApplyResources(this.loginField, "loginField");
            this.loginField.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.loginField.Depth = 0;
            this.loginField.HideSelection = true;
            this.loginField.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("loginField.LeadingIcon")));
            this.loginField.MaxLength = 16;
            this.loginField.MouseState = MaterialSkin.MouseState.OUT;
            this.loginField.Name = "loginField";
            this.loginField.PasswordChar = '\0';
            this.loginField.ReadOnly = false;
            this.loginField.SelectedText = "";
            this.loginField.SelectionLength = 0;
            this.loginField.SelectionStart = 0;
            this.loginField.ShortcutsEnabled = true;
            this.loginField.ShowAssistiveText = true;
            this.loginField.TabStop = false;
            this.loginField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loginField.TrailingIcon = null;
            this.loginField.UseSystemPasswordChar = false;
            this.loginField.Enter += new System.EventHandler(this.loginField_Enter);
            this.loginField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginField_KeyUp);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(240)))));
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passField
            // 
            this.passField.AnimateReadOnly = true;
            resources.ApplyResources(this.passField, "passField");
            this.passField.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.passField.Depth = 0;
            this.passField.HideSelection = true;
            this.passField.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("passField.LeadingIcon")));
            this.passField.MaxLength = 16;
            this.passField.MouseState = MaterialSkin.MouseState.OUT;
            this.passField.Name = "passField";
            this.passField.PasswordChar = '\0';
            this.passField.ReadOnly = false;
            this.passField.SelectedText = "";
            this.passField.SelectionLength = 0;
            this.passField.SelectionStart = 0;
            this.passField.ShortcutsEnabled = true;
            this.passField.ShowAssistiveText = true;
            this.passField.TabStop = false;
            this.passField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passField.TrailingIcon = global::WindowsFormsApp1.Properties.Resources.visibility;
            this.passField.UseSystemPasswordChar = false;
            this.passField.TrailingIconClick += new System.EventHandler(this.passField_TrailingIconClick);
            this.passField.Enter += new System.EventHandler(this.passField_Enter);
            this.passField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passField_KeyUp);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Sizable = false;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button loginButton;
        private MaterialSkin.Controls.MaterialTextBox2 loginField;
        private MaterialSkin.Controls.MaterialTextBox2 passField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}