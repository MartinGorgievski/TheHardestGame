namespace TheHardestGame
{
    partial class Form1
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
            this.Level1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Level1
            // 
            this.Level1.Location = new System.Drawing.Point(219, 115);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(75, 23);
            this.Level1.TabIndex = 0;
            this.Level1.Text = "START";
            this.Level1.UseVisualStyleBackColor = true;
            this.Level1.Click += new System.EventHandler(this.Level1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 301);
            this.Controls.Add(this.Level1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "The Hardest Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Level1;
    }
}

