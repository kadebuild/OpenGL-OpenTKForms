namespace OpenTKFormsFinal
{
    partial class OpenGLForm
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
            this.ifButton = new System.Windows.Forms.Button();
            this.endifButton = new System.Windows.Forms.Button();
            this.forButton = new System.Windows.Forms.Button();
            this.endforButton = new System.Windows.Forms.Button();
            this.whileButton = new System.Windows.Forms.Button();
            this.endwhileButton = new System.Windows.Forms.Button();
            this.actionButton = new System.Windows.Forms.Button();
            this.ioButton = new System.Windows.Forms.Button();
            this.blockListForm = new System.Windows.Forms.ListBox();
            this.clearBlockListButton = new System.Windows.Forms.Button();
            this.deleteBlockButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.ifTrueForm = new System.Windows.Forms.CheckBox();
            this.cycleRepeatForm = new System.Windows.Forms.NumericUpDown();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.animationTimeForm = new System.Windows.Forms.NumericUpDown();
            this.skyboxTheme = new System.Windows.Forms.ComboBox();
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
            // ifButton
            // 
            this.ifButton.Location = new System.Drawing.Point(519, 13);
            this.ifButton.Name = "ifButton";
            this.ifButton.Size = new System.Drawing.Size(75, 23);
            this.ifButton.TabIndex = 1;
            this.ifButton.Text = "if";
            this.ifButton.UseVisualStyleBackColor = true;
            this.ifButton.Click += new System.EventHandler(this.ifButton_Click);
            // 
            // endifButton
            // 
            this.endifButton.Location = new System.Drawing.Point(600, 13);
            this.endifButton.Name = "endifButton";
            this.endifButton.Size = new System.Drawing.Size(85, 23);
            this.endifButton.TabIndex = 2;
            this.endifButton.Text = "end if";
            this.endifButton.UseVisualStyleBackColor = true;
            this.endifButton.Click += new System.EventHandler(this.endifButton_Click);
            // 
            // forButton
            // 
            this.forButton.Location = new System.Drawing.Point(519, 42);
            this.forButton.Name = "forButton";
            this.forButton.Size = new System.Drawing.Size(75, 23);
            this.forButton.TabIndex = 3;
            this.forButton.Text = "for";
            this.forButton.UseVisualStyleBackColor = true;
            this.forButton.Click += new System.EventHandler(this.forButton_Click);
            // 
            // endforButton
            // 
            this.endforButton.Location = new System.Drawing.Point(600, 42);
            this.endforButton.Name = "endforButton";
            this.endforButton.Size = new System.Drawing.Size(85, 23);
            this.endforButton.TabIndex = 4;
            this.endforButton.Text = "end for";
            this.endforButton.UseVisualStyleBackColor = true;
            this.endforButton.Click += new System.EventHandler(this.endforButton_Click);
            // 
            // whileButton
            // 
            this.whileButton.Location = new System.Drawing.Point(519, 71);
            this.whileButton.Name = "whileButton";
            this.whileButton.Size = new System.Drawing.Size(75, 23);
            this.whileButton.TabIndex = 5;
            this.whileButton.Text = "while";
            this.whileButton.UseVisualStyleBackColor = true;
            this.whileButton.Click += new System.EventHandler(this.whileButton_Click);
            // 
            // endwhileButton
            // 
            this.endwhileButton.Location = new System.Drawing.Point(600, 71);
            this.endwhileButton.Name = "endwhileButton";
            this.endwhileButton.Size = new System.Drawing.Size(85, 23);
            this.endwhileButton.TabIndex = 6;
            this.endwhileButton.Text = "end while";
            this.endwhileButton.UseVisualStyleBackColor = true;
            this.endwhileButton.Click += new System.EventHandler(this.endwhileButton_Click);
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(519, 100);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(75, 23);
            this.actionButton.TabIndex = 7;
            this.actionButton.Text = "Action";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // ioButton
            // 
            this.ioButton.Location = new System.Drawing.Point(600, 100);
            this.ioButton.Name = "ioButton";
            this.ioButton.Size = new System.Drawing.Size(85, 23);
            this.ioButton.TabIndex = 8;
            this.ioButton.Text = "I/O";
            this.ioButton.UseVisualStyleBackColor = true;
            this.ioButton.Click += new System.EventHandler(this.ioButton_Click);
            // 
            // blockListForm
            // 
            this.blockListForm.FormattingEnabled = true;
            this.blockListForm.Location = new System.Drawing.Point(519, 129);
            this.blockListForm.Name = "blockListForm";
            this.blockListForm.Size = new System.Drawing.Size(166, 95);
            this.blockListForm.TabIndex = 9;
            // 
            // clearBlockListButton
            // 
            this.clearBlockListButton.Location = new System.Drawing.Point(600, 230);
            this.clearBlockListButton.Name = "clearBlockListButton";
            this.clearBlockListButton.Size = new System.Drawing.Size(85, 23);
            this.clearBlockListButton.TabIndex = 10;
            this.clearBlockListButton.Text = "Clear list";
            this.clearBlockListButton.UseVisualStyleBackColor = true;
            this.clearBlockListButton.Click += new System.EventHandler(this.clearBlockListButton_Click);
            // 
            // deleteBlockButton
            // 
            this.deleteBlockButton.Location = new System.Drawing.Point(519, 230);
            this.deleteBlockButton.Name = "deleteBlockButton";
            this.deleteBlockButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBlockButton.TabIndex = 11;
            this.deleteBlockButton.Text = "Remove";
            this.deleteBlockButton.UseVisualStyleBackColor = true;
            this.deleteBlockButton.Click += new System.EventHandler(this.deleteBlockButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(519, 259);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(166, 23);
            this.runButton.TabIndex = 12;
            this.runButton.Text = "Animate blocks";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
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
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(520, 289);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(126, 13);
            this.repeatLabel.TabIndex = 15;
            this.repeatLabel.Text = "Number of loop repeating";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Time of animation, ms";
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
            // skyboxTheme
            // 
            this.skyboxTheme.FormattingEnabled = true;
            this.skyboxTheme.Items.AddRange(new object[] {
            "Greens and mountains",
            "Ocean",
            "Cosmos",
            "Autumn in mountains"});
            this.skyboxTheme.Location = new System.Drawing.Point(519, 375);
            this.skyboxTheme.Name = "skyboxTheme";
            this.skyboxTheme.Size = new System.Drawing.Size(166, 21);
            this.skyboxTheme.TabIndex = 18;
            this.skyboxTheme.Text = "Ocean";
            this.skyboxTheme.SelectedIndexChanged += new System.EventHandler(this.skyboxTheme_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(614, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Light";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 525);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.skyboxTheme);
            this.Controls.Add(this.animationTimeForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.cycleRepeatForm);
            this.Controls.Add(this.ifTrueForm);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.deleteBlockButton);
            this.Controls.Add(this.clearBlockListButton);
            this.Controls.Add(this.blockListForm);
            this.Controls.Add(this.ioButton);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.endwhileButton);
            this.Controls.Add(this.whileButton);
            this.Controls.Add(this.endforButton);
            this.Controls.Add(this.forButton);
            this.Controls.Add(this.endifButton);
            this.Controls.Add(this.ifButton);
            this.Controls.Add(this.glControl);
            this.Name = "OpenGLForm";
            this.Text = "OpenGL Forms";
            ((System.ComponentModel.ISupportInitialize)(this.cycleRepeatForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTimeForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Button ifButton;
        private System.Windows.Forms.Button endifButton;
        private System.Windows.Forms.Button forButton;
        private System.Windows.Forms.Button endforButton;
        private System.Windows.Forms.Button whileButton;
        private System.Windows.Forms.Button endwhileButton;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Button ioButton;
        private System.Windows.Forms.ListBox blockListForm;
        private System.Windows.Forms.Button clearBlockListButton;
        private System.Windows.Forms.Button deleteBlockButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox ifTrueForm;
        private System.Windows.Forms.NumericUpDown cycleRepeatForm;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown animationTimeForm;
        private System.Windows.Forms.ComboBox skyboxTheme;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

