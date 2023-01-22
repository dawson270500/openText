namespace OpenText
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.WordWarp = new System.Windows.Forms.CheckBox();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.keepOpen_CheckBox = new System.Windows.Forms.CheckBox();
            this.newWindow_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(93, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(174, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(12, 41);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(760, 508);
            this.inputBox.TabIndex = 2;
            this.inputBox.Text = "";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(12, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // WordWarp
            // 
            this.WordWarp.AutoSize = true;
            this.WordWarp.Checked = true;
            this.WordWarp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordWarp.Location = new System.Drawing.Point(336, 15);
            this.WordWarp.Name = "WordWarp";
            this.WordWarp.Size = new System.Drawing.Size(86, 19);
            this.WordWarp.TabIndex = 4;
            this.WordWarp.Text = "Word Warp";
            this.WordWarp.UseVisualStyleBackColor = true;
            this.WordWarp.Click += new System.EventHandler(this.WordWarp_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(255, 12);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 5;
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // keepOpen_CheckBox
            // 
            this.keepOpen_CheckBox.AutoSize = true;
            this.keepOpen_CheckBox.Location = new System.Drawing.Point(689, 15);
            this.keepOpen_CheckBox.Name = "keepOpen_CheckBox";
            this.keepOpen_CheckBox.Size = new System.Drawing.Size(84, 19);
            this.keepOpen_CheckBox.TabIndex = 6;
            this.keepOpen_CheckBox.Text = "Keep Open";
            this.keepOpen_CheckBox.UseVisualStyleBackColor = true;
            // 
            // newWindow_button
            // 
            this.newWindow_button.Location = new System.Drawing.Point(593, 12);
            this.newWindow_button.Name = "newWindow_button";
            this.newWindow_button.Size = new System.Drawing.Size(90, 23);
            this.newWindow_button.TabIndex = 7;
            this.newWindow_button.Text = "New Window";
            this.newWindow_button.UseVisualStyleBackColor = true;
            this.newWindow_button.Click += new System.EventHandler(this.newWindow_button_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.newWindow_button);
            this.Controls.Add(this.keepOpen_CheckBox);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.WordWarp);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.Text = "OpenText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button openButton;
        private Button saveButton;
        private RichTextBox inputBox;
        private Button newButton;
        private CheckBox WordWarp;
        private Button saveAsButton;
        private CheckBox keepOpen_CheckBox;
        private Button newWindow_button;
    }
}