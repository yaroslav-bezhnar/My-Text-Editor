namespace TextEditor
{
    partial class ReplaceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxRegistry = new System.Windows.Forms.CheckBox();
            this.checkBoxWord = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Знайти:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Замінити на:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(217, 20);
            this.textBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Знайти далі";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Замінити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(325, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "Замінити все";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(325, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 20);
            this.button4.TabIndex = 2;
            this.button4.Text = "Скасувати";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxRegistry
            // 
            this.checkBoxRegistry.AutoSize = true;
            this.checkBoxRegistry.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBoxRegistry.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRegistry.Location = new System.Drawing.Point(28, 97);
            this.checkBoxRegistry.Name = "checkBoxRegistry";
            this.checkBoxRegistry.Size = new System.Drawing.Size(140, 18);
            this.checkBoxRegistry.TabIndex = 3;
            this.checkBoxRegistry.Text = "Враховувати регістр";
            this.checkBoxRegistry.UseVisualStyleBackColor = false;
            // 
            // checkBoxWord
            // 
            this.checkBoxWord.AutoSize = true;
            this.checkBoxWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBoxWord.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxWord.Location = new System.Drawing.Point(28, 74);
            this.checkBoxWord.Name = "checkBoxWord";
            this.checkBoxWord.Size = new System.Drawing.Size(83, 18);
            this.checkBoxWord.TabIndex = 3;
            this.checkBoxWord.Text = "Все слово";
            this.checkBoxWord.UseVisualStyleBackColor = false;
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 121);
            this.Controls.Add(this.checkBoxWord);
            this.Controls.Add(this.checkBoxRegistry);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 160);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 160);
            this.Name = "ReplaceForm";
            this.Text = "Замінити";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBoxRegistry;
        private System.Windows.Forms.CheckBox checkBoxWord;
    }
}