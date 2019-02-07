namespace OpenTKFormsFinal
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
            this.glControl = new OpenTK.GLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.blockListForm = new System.Windows.Forms.ListBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.ifTrueForm = new System.Windows.Forms.CheckBox();
            this.cycleRepeatForm = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.animationTimeForm = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cycleRepeatForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTimeForm)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(13, 13);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(500, 500);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = true;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "if";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "end if";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "for";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(600, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "end for";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(519, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "while";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(600, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "end while";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(519, 100);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Действие";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(600, 100);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Ввод/вывод";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // blockListForm
            // 
            this.blockListForm.FormattingEnabled = true;
            this.blockListForm.Location = new System.Drawing.Point(519, 129);
            this.blockListForm.Name = "blockListForm";
            this.blockListForm.Size = new System.Drawing.Size(166, 95);
            this.blockListForm.TabIndex = 9;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(600, 230);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(85, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Очистить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(519, 230);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "Удалить";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(519, 259);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(166, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "Выполнить блок схему";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // ifTrueForm
            // 
            this.ifTrueForm.AutoSize = true;
            this.ifTrueForm.Checked = true;
            this.ifTrueForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ifTrueForm.Location = new System.Drawing.Point(614, 308);
            this.ifTrueForm.Name = "ifTrueForm";
            this.ifTrueForm.Size = new System.Drawing.Size(71, 17);
            this.ifTrueForm.TabIndex = 13;
            this.ifTrueForm.Text = "IF == true";
            this.ifTrueForm.UseVisualStyleBackColor = true;
            this.ifTrueForm.CheckedChanged += new System.EventHandler(this.ifTrueForm_CheckedChanged);
            // 
            // cycleRepeatForm
            // 
            this.cycleRepeatForm.Location = new System.Drawing.Point(519, 305);
            this.cycleRepeatForm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cycleRepeatForm.Name = "cycleRepeatForm";
            this.cycleRepeatForm.Size = new System.Drawing.Size(85, 20);
            this.cycleRepeatForm.TabIndex = 14;
            this.cycleRepeatForm.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.cycleRepeatForm.ValueChanged += new System.EventHandler(this.cycleRepeatForm_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Число повторений циклов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Время анимации, миллисек";
            // 
            // animationTimeForm
            // 
            this.animationTimeForm.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationTimeForm.Location = new System.Drawing.Point(519, 349);
            this.animationTimeForm.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.animationTimeForm.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationTimeForm.Name = "animationTimeForm";
            this.animationTimeForm.Size = new System.Drawing.Size(85, 20);
            this.animationTimeForm.TabIndex = 17;
            this.animationTimeForm.ThousandsSeparator = true;
            this.animationTimeForm.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.animationTimeForm.ValueChanged += new System.EventHandler(this.animationTimeForm_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Зелень и горы",
            "Море",
            "Космос",
            "Осень в горах"});
            this.comboBox1.Location = new System.Drawing.Point(519, 375);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.Text = "Море";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(614, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Свет";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 525);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.animationTimeForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cycleRepeatForm);
            this.Controls.Add(this.ifTrueForm);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.blockListForm);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.glControl);
            this.Name = "Form1";
            this.Text = "Katkov DS";
            ((System.ComponentModel.ISupportInitialize)(this.cycleRepeatForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTimeForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ListBox blockListForm;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox ifTrueForm;
        private System.Windows.Forms.NumericUpDown cycleRepeatForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown animationTimeForm;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

