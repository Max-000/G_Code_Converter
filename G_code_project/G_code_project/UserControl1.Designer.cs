namespace G_code_project
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Convert_to_g91_button = new System.Windows.Forms.Button();
            this.G_code_in = new System.Windows.Forms.RichTextBox();
            this.G_code_out = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Help_button = new System.Windows.Forms.Button();
            this.Convert_to_g90_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Convert_to_g91_button
            // 
            this.Convert_to_g91_button.Location = new System.Drawing.Point(42, 35);
            this.Convert_to_g91_button.Name = "Convert_to_g91_button";
            this.Convert_to_g91_button.Size = new System.Drawing.Size(125, 58);
            this.Convert_to_g91_button.TabIndex = 0;
            this.Convert_to_g91_button.Text = "Convert";
            this.Convert_to_g91_button.UseVisualStyleBackColor = true;
            this.Convert_to_g91_button.Click += new System.EventHandler(this.Convert_to_g91_button_click);
            // 
            // G_code_in
            // 
            this.G_code_in.Location = new System.Drawing.Point(207, 39);
            this.G_code_in.Name = "G_code_in";
            this.G_code_in.Size = new System.Drawing.Size(211, 382);
            this.G_code_in.TabIndex = 1;
            this.G_code_in.Text = "x10 y10 z10\nx20 y20 z20\nx30 y30 z30\nx40 y40 z40";
            // 
            // G_code_out
            // 
            this.G_code_out.Location = new System.Drawing.Point(449, 39);
            this.G_code_out.Name = "G_code_out";
            this.G_code_out.Size = new System.Drawing.Size(211, 382);
            this.G_code_out.TabIndex = 2;
            this.G_code_out.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(210, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Global Coordinates";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(449, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 13);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Relative Coordinates";
            // 
            // Help_button
            // 
            this.Help_button.Location = new System.Drawing.Point(42, 99);
            this.Help_button.Name = "Help_button";
            this.Help_button.Size = new System.Drawing.Size(125, 58);
            this.Help_button.TabIndex = 5;
            this.Help_button.Text = "Help";
            this.Help_button.UseVisualStyleBackColor = true;
            this.Help_button.Click += new System.EventHandler(this.Help_button_Click);
            // 
            // Convert_to_g90_button
            // 
            this.Convert_to_g90_button.Location = new System.Drawing.Point(668, 39);
            this.Convert_to_g90_button.Name = "Convert_to_g90_button";
            this.Convert_to_g90_button.Size = new System.Drawing.Size(125, 58);
            this.Convert_to_g90_button.TabIndex = 6;
            this.Convert_to_g90_button.Text = "Convert";
            this.Convert_to_g90_button.UseVisualStyleBackColor = true;
            this.Convert_to_g90_button.Click += new System.EventHandler(this.Convert_to_g90_button_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.Convert_to_g90_button);
            this.Controls.Add(this.Help_button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.G_code_out);
            this.Controls.Add(this.G_code_in);
            this.Controls.Add(this.Convert_to_g91_button);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Convert_to_g91_button;
        private System.Windows.Forms.RichTextBox G_code_in;
        private System.Windows.Forms.RichTextBox G_code_out;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Help_button;
        private System.Windows.Forms.Button Convert_to_g90_button;
    }
}
