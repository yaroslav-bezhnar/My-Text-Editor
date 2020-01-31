namespace TextEditor
{
    partial class SearchForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxWord = new System.Windows.Forms.CheckBox();
            this.checkBoxRegistry = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Знайти:";
            // 
            // checkBoxWord
            // 
            this.checkBoxWord.AutoSize = true;
            this.checkBoxWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBoxWord.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxWord.Location = new System.Drawing.Point(28, 55);
            this.checkBoxWord.Name = "checkBoxWord";
            this.checkBoxWord.Size = new System.Drawing.Size(83, 18);
            this.checkBoxWord.TabIndex = 4;
            this.checkBoxWord.Text = "Все слово";
            this.checkBoxWord.UseVisualStyleBackColor = false;
            // 
            // checkBoxRegistry
            // 
            this.checkBoxRegistry.AutoSize = true;
            this.checkBoxRegistry.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBoxRegistry.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRegistry.Location = new System.Drawing.Point(28, 78);
            this.checkBoxRegistry.Name = "checkBoxRegistry";
            this.checkBoxRegistry.Size = new System.Drawing.Size(140, 18);
            this.checkBoxRegistry.TabIndex = 5;
            this.checkBoxRegistry.Text = "Враховувати регістр";
            this.checkBoxRegistry.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(325, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Скасувати";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "Знайти далі";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 96);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxWord);
            this.Controls.Add(this.checkBoxRegistry);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 135);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 135);
            this.Name = "SearchForm";
            this.Text = "Знайти";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxWord;
        private System.Windows.Forms.CheckBox checkBoxRegistry;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}