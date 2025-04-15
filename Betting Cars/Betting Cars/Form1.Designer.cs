namespace Betting_Cars
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox car1;
        private System.Windows.Forms.PictureBox car2;
        private System.Windows.Forms.PictureBox car3;
        private System.Windows.Forms.Button redBtn;
        private System.Windows.Forms.Button blackBtn;
        private System.Windows.Forms.Button orangeBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            car1 = new PictureBox();
            car2 = new PictureBox();
            car3 = new PictureBox();
            redBtn = new Button();
            blackBtn = new Button();
            orangeBtn = new Button();
            startBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)car1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)car2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)car3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // car1
            // 
            car1.BackColor = Color.Transparent;
            car1.BackgroundImage = Properties.Resources.Screenshot_2025_04_14_023640;
            car1.BackgroundImageLayout = ImageLayout.Zoom;
            car1.Location = new Point(16, 51);
            car1.Name = "car1";
            car1.Size = new Size(100, 50);
            car1.TabIndex = 1;
            car1.TabStop = false;
            car1.Click += car1_Click;
            // 
            // car2
            // 
            car2.BackColor = Color.Transparent;
            car2.BackgroundImage = Properties.Resources.Screenshot_2025_04_14_023629;
            car2.BackgroundImageLayout = ImageLayout.Zoom;
            car2.Location = new Point(16, 178);
            car2.Name = "car2";
            car2.Size = new Size(100, 50);
            car2.TabIndex = 2;
            car2.TabStop = false;
            // 
            // car3
            // 
            car3.BackColor = Color.Transparent;
            car3.BackgroundImage = Properties.Resources.Screenshot_2025_04_14_023656;
            car3.BackgroundImageLayout = ImageLayout.Zoom;
            car3.Location = new Point(3, 304);
            car3.Name = "car3";
            car3.Size = new Size(100, 50);
            car3.TabIndex = 3;
            car3.TabStop = false;
            // 
            // redBtn
            // 
            redBtn.BackColor = Color.Beige;
            redBtn.Location = new Point(830, 50);
            redBtn.Name = "redBtn";
            redBtn.Size = new Size(100, 50);
            redBtn.TabIndex = 7;
            redBtn.Text = "Prime";
            redBtn.UseVisualStyleBackColor = false;
            redBtn.Click += redBtn_Click;
            // 
            // blackBtn
            // 
            blackBtn.BackColor = Color.Beige;
            blackBtn.Location = new Point(830, 120);
            blackBtn.Name = "blackBtn";
            blackBtn.Size = new Size(100, 50);
            blackBtn.TabIndex = 6;
            blackBtn.Text = "Ivan";
            blackBtn.UseVisualStyleBackColor = false;
            blackBtn.Click += blackBtn_Click;
            // 
            // orangeBtn
            // 
            orangeBtn.BackColor = Color.Beige;
            orangeBtn.ForeColor = SystemColors.Desktop;
            orangeBtn.Location = new Point(830, 190);
            orangeBtn.Name = "orangeBtn";
            orangeBtn.Size = new Size(100, 50);
            orangeBtn.TabIndex = 5;
            orangeBtn.Text = "Tony";
            orangeBtn.UseVisualStyleBackColor = false;
            orangeBtn.Click += orangeBtn_Click;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.LawnGreen;
            startBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startBtn.Location = new Point(830, 260);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(100, 50);
            startBtn.TabIndex = 4;
            startBtn.Text = "Start Race";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.race_track;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(car3);
            panel1.Controls.Add(car2);
            panel1.Controls.Add(car1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 400);
            panel1.TabIndex = 8;
            // 
            // Form1
            // 
            BackColor = Color.PowderBlue;
            ClientSize = new Size(950, 425);
            Controls.Add(panel1);
            Controls.Add(startBtn);
            Controls.Add(orangeBtn);
            Controls.Add(blackBtn);
            Controls.Add(redBtn);
            Name = "Form1";
            Text = "Betting Cars Game";
            ((System.ComponentModel.ISupportInitialize)car1).EndInit();
            ((System.ComponentModel.ISupportInitialize)car2).EndInit();
            ((System.ComponentModel.ISupportInitialize)car3).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel panel1;
    }
}