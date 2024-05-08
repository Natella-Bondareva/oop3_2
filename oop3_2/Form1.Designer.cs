namespace oop3_2
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            DoCalculation = new Button();
            RandomPoints = new Button();
            MultiThreadMode = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox = new PictureBox();
            Clear = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // DoCalculation
            // 
            DoCalculation.Location = new Point(29, 17);
            DoCalculation.Name = "DoCalculation";
            DoCalculation.Size = new Size(118, 40);
            DoCalculation.TabIndex = 0;
            DoCalculation.Text = "Calculate";
            DoCalculation.UseVisualStyleBackColor = true;
            DoCalculation.Click += buttonDoCalculation_Click;
            // 
            // RandomPoints
            // 
            RandomPoints.Location = new Point(172, 17);
            RandomPoints.Name = "RandomPoints";
            RandomPoints.Size = new Size(118, 40);
            RandomPoints.TabIndex = 1;
            RandomPoints.Text = "Random Points";
            RandomPoints.UseVisualStyleBackColor = true;
            RandomPoints.Click += buttonRandomPoints_Click;
            // 
            // MultiThreadMode
            // 
            MultiThreadMode.AutoSize = true;
            MultiThreadMode.Location = new Point(475, 26);
            MultiThreadMode.Name = "MultiThreadMode";
            MultiThreadMode.Size = new Size(129, 24);
            MultiThreadMode.TabIndex = 2;
            MultiThreadMode.Text = "multithreading";
            MultiThreadMode.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 61);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1126, 597);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            // 
            // Clear
            // 
            Clear.Location = new Point(318, 17);
            Clear.Name = "Clear";
            Clear.Size = new Size(118, 40);
            Clear.TabIndex = 4;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += buttonClear_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(657, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 27);
            textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 656);
            Controls.Add(textBox1);
            Controls.Add(Clear);
            Controls.Add(pictureBox);
            Controls.Add(MultiThreadMode);
            Controls.Add(RandomPoints);
            Controls.Add(DoCalculation);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DoCalculation;
        private Button RandomPoints;
        private CheckBox MultiThreadMode;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox;
        private Button Clear;
        private TextBox textBox1;
    }
}
