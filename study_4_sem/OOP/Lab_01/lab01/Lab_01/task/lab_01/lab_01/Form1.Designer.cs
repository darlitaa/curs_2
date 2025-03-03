namespace TextCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOldSubstring = new System.Windows.Forms.TextBox();
            this.txtNewSubstring = new System.Windows.Forms.TextBox();
            this.txtSubstringToRemove = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCharAtIndex = new System.Windows.Forms.Button();
            this.btnLength = new System.Windows.Forms.Button();
            this.btnVowelsCount = new System.Windows.Forms.Button();
            this.btnConsonantsCount = new System.Windows.Forms.Button();
            this.btnSentenceCount = new System.Windows.Forms.Button();
            this.btnWordCount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "введите текстовую строку";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInput.Location = new System.Drawing.Point(27, 53);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(326, 26);
            this.txtInput.TabIndex = 2;
            // 
            // txtOldSubstring
            // 
            this.txtOldSubstring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOldSubstring.Location = new System.Drawing.Point(27, 118);
            this.txtOldSubstring.Name = "txtOldSubstring";
            this.txtOldSubstring.Size = new System.Drawing.Size(183, 26);
            this.txtOldSubstring.TabIndex = 3;
            // 
            // txtNewSubstring
            // 
            this.txtNewSubstring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNewSubstring.Location = new System.Drawing.Point(27, 184);
            this.txtNewSubstring.Name = "txtNewSubstring";
            this.txtNewSubstring.Size = new System.Drawing.Size(183, 26);
            this.txtNewSubstring.TabIndex = 4;
            // 
            // txtSubstringToRemove
            // 
            this.txtSubstringToRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSubstringToRemove.Location = new System.Drawing.Point(27, 254);
            this.txtSubstringToRemove.Name = "txtSubstringToRemove";
            this.txtSubstringToRemove.Size = new System.Drawing.Size(183, 26);
            this.txtSubstringToRemove.TabIndex = 5;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtIndex.Location = new System.Drawing.Point(27, 321);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(183, 26);
            this.txtIndex.TabIndex = 6;
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOutput.Location = new System.Drawing.Point(553, 53);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(332, 26);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "что нужно заменить";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(27, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "что удалить";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(27, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "символ по индексу";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(559, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "результат";
            // 
            // btnReplace
            // 
            this.btnReplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReplace.Location = new System.Drawing.Point(235, 143);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(198, 38);
            this.btnReplace.TabIndex = 13;
            this.btnReplace.Text = "заменить подстроку";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemove.Location = new System.Drawing.Point(235, 247);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(198, 33);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "удалить подстроку";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCharAtIndex
            // 
            this.btnCharAtIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnCharAtIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCharAtIndex.Location = new System.Drawing.Point(235, 313);
            this.btnCharAtIndex.Name = "btnCharAtIndex";
            this.btnCharAtIndex.Size = new System.Drawing.Size(198, 34);
            this.btnCharAtIndex.TabIndex = 15;
            this.btnCharAtIndex.Text = "символ по индексу";
            this.btnCharAtIndex.UseVisualStyleBackColor = false;
            this.btnCharAtIndex.Click += new System.EventHandler(this.btnCharAtIndex_Click);
            // 
            // btnLength
            // 
            this.btnLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLength.Location = new System.Drawing.Point(515, 178);
            this.btnLength.Name = "btnLength";
            this.btnLength.Size = new System.Drawing.Size(218, 37);
            this.btnLength.TabIndex = 16;
            this.btnLength.Text = "длина строки";
            this.btnLength.UseVisualStyleBackColor = false;
            this.btnLength.Click += new System.EventHandler(this.btnLength_Click);
            // 
            // btnVowelsCount
            // 
            this.btnVowelsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnVowelsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVowelsCount.Location = new System.Drawing.Point(757, 231);
            this.btnVowelsCount.Name = "btnVowelsCount";
            this.btnVowelsCount.Size = new System.Drawing.Size(180, 40);
            this.btnVowelsCount.TabIndex = 17;
            this.btnVowelsCount.Text = "гласные";
            this.btnVowelsCount.UseVisualStyleBackColor = false;
            this.btnVowelsCount.Click += new System.EventHandler(this.btnVowelsCount_Click);
            // 
            // btnConsonantsCount
            // 
            this.btnConsonantsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnConsonantsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConsonantsCount.Location = new System.Drawing.Point(757, 288);
            this.btnConsonantsCount.Name = "btnConsonantsCount";
            this.btnConsonantsCount.Size = new System.Drawing.Size(180, 40);
            this.btnConsonantsCount.TabIndex = 18;
            this.btnConsonantsCount.Text = "согласные";
            this.btnConsonantsCount.UseVisualStyleBackColor = false;
            this.btnConsonantsCount.Click += new System.EventHandler(this.btnConsonantsCount_Click);
            // 
            // btnSentenceCount
            // 
            this.btnSentenceCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnSentenceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSentenceCount.Location = new System.Drawing.Point(515, 288);
            this.btnSentenceCount.Name = "btnSentenceCount";
            this.btnSentenceCount.Size = new System.Drawing.Size(218, 40);
            this.btnSentenceCount.TabIndex = 19;
            this.btnSentenceCount.Text = "кол-во предложений";
            this.btnSentenceCount.UseVisualStyleBackColor = false;
            this.btnSentenceCount.Click += new System.EventHandler(this.btnSentenceCount_Click);
            // 
            // btnWordCount
            // 
            this.btnWordCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(146)))), ((int)(((byte)(217)))));
            this.btnWordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWordCount.Location = new System.Drawing.Point(515, 231);
            this.btnWordCount.Name = "btnWordCount";
            this.btnWordCount.Size = new System.Drawing.Size(218, 40);
            this.btnWordCount.TabIndex = 20;
            this.btnWordCount.Text = "кол-во слов";
            this.btnWordCount.UseVisualStyleBackColor = false;
            this.btnWordCount.Click += new System.EventHandler(this.btnWordCount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "на что заменить";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(971, 448);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWordCount);
            this.Controls.Add(this.btnSentenceCount);
            this.Controls.Add(this.btnConsonantsCount);
            this.Controls.Add(this.btnVowelsCount);
            this.Controls.Add(this.btnLength);
            this.Controls.Add(this.btnCharAtIndex);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.txtSubstringToRemove);
            this.Controls.Add(this.txtNewSubstring);
            this.Controls.Add(this.txtOldSubstring);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOldSubstring;
        private System.Windows.Forms.TextBox txtNewSubstring;
        private System.Windows.Forms.TextBox txtSubstringToRemove;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCharAtIndex;
        private System.Windows.Forms.Button btnLength;
        private System.Windows.Forms.Button btnVowelsCount;
        private System.Windows.Forms.Button btnConsonantsCount;
        private System.Windows.Forms.Button btnSentenceCount;
        private System.Windows.Forms.Button btnWordCount;
        private System.Windows.Forms.Label label3;
    }
}

