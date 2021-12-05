namespace NoteAppUI
{
    partial class AboutForm
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
            this.ApplicationTitleTextBox = new System.Windows.Forms.TextBox();
            this.VersionTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.GithubTextBox = new System.Windows.Forms.TextBox();
            this.FinalInfoTextBox = new System.Windows.Forms.TextBox();
            this.EmailLinkLable = new System.Windows.Forms.LinkLabel();
            this.GithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ApplicationTitleTextBox
            // 
            this.ApplicationTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ApplicationTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplicationTitleTextBox.Location = new System.Drawing.Point(13, 21);
            this.ApplicationTitleTextBox.Name = "ApplicationTitleTextBox";
            this.ApplicationTitleTextBox.ReadOnly = true;
            this.ApplicationTitleTextBox.Size = new System.Drawing.Size(134, 27);
            this.ApplicationTitleTextBox.TabIndex = 2;
            this.ApplicationTitleTextBox.Text = "NoteApp";
            this.ApplicationTitleTextBox.TextChanged += new System.EventHandler(this.ApplicationTitleTextBox_TextChanged);
            // 
            // VersionTextBox
            // 
            this.VersionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionTextBox.Location = new System.Drawing.Point(13, 54);
            this.VersionTextBox.Name = "VersionTextBox";
            this.VersionTextBox.ReadOnly = true;
            this.VersionTextBox.Size = new System.Drawing.Size(100, 15);
            this.VersionTextBox.TabIndex = 3;
            this.VersionTextBox.Text = "v. 1.0.0";
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AuthorTextBox.Location = new System.Drawing.Point(13, 101);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.ReadOnly = true;
            this.AuthorTextBox.Size = new System.Drawing.Size(169, 15);
            this.AuthorTextBox.TabIndex = 4;
            this.AuthorTextBox.Text = "Author: Nasonov Artem";
            this.AuthorTextBox.TextChanged += new System.EventHandler(this.AuthorTextBox_TextChanged);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextBox.Location = new System.Drawing.Point(13, 146);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.ReadOnly = true;
            this.EmailTextBox.Size = new System.Drawing.Size(134, 15);
            this.EmailTextBox.TabIndex = 5;
            this.EmailTextBox.Text = "e-mail for feedback:";
            // 
            // GithubTextBox
            // 
            this.GithubTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GithubTextBox.Location = new System.Drawing.Point(13, 167);
            this.GithubTextBox.Name = "GithubTextBox";
            this.GithubTextBox.ReadOnly = true;
            this.GithubTextBox.Size = new System.Drawing.Size(57, 15);
            this.GithubTextBox.TabIndex = 6;
            this.GithubTextBox.Text = "Github:";
            // 
            // FinalInfoTextBox
            // 
            this.FinalInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FinalInfoTextBox.Location = new System.Drawing.Point(12, 299);
            this.FinalInfoTextBox.Name = "FinalInfoTextBox";
            this.FinalInfoTextBox.ReadOnly = true;
            this.FinalInfoTextBox.Size = new System.Drawing.Size(169, 15);
            this.FinalInfoTextBox.TabIndex = 7;
            this.FinalInfoTextBox.Text = "2021 Nasonov Artem ";
            // 
            // EmailLinkLable
            // 
            this.EmailLinkLable.AutoSize = true;
            this.EmailLinkLable.Location = new System.Drawing.Point(62, 167);
            this.EmailLinkLable.Name = "EmailLinkLable";
            this.EmailLinkLable.Size = new System.Drawing.Size(168, 17);
            this.EmailLinkLable.TabIndex = 8;
            this.EmailLinkLable.TabStop = true;
            this.EmailLinkLable.Text = "NasonovArtem \\ NoteApp";
            // 
            // GithubLinkLabel
            // 
            this.GithubLinkLabel.AutoSize = true;
            this.GithubLinkLabel.Location = new System.Drawing.Point(137, 146);
            this.GithubLinkLabel.Name = "GithubLinkLabel";
            this.GithubLinkLabel.Size = new System.Drawing.Size(180, 17);
            this.GithubLinkLabel.TabIndex = 9;
            this.GithubLinkLabel.TabStop = true;
            this.GithubLinkLabel.Text = "artem-nasonov-00@mail.ru";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 317);
            this.Controls.Add(this.GithubLinkLabel);
            this.Controls.Add(this.EmailLinkLable);
            this.Controls.Add(this.FinalInfoTextBox);
            this.Controls.Add(this.GithubTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.VersionTextBox);
            this.Controls.Add(this.ApplicationTitleTextBox);
            this.MaximumSize = new System.Drawing.Size(529, 364);
            this.MinimumSize = new System.Drawing.Size(529, 363);
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ApplicationTitleTextBox;
        private System.Windows.Forms.TextBox VersionTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox GithubTextBox;
        private System.Windows.Forms.TextBox FinalInfoTextBox;
        private System.Windows.Forms.LinkLabel EmailLinkLable;
        private System.Windows.Forms.LinkLabel GithubLinkLabel;
    }
}