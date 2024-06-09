using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp5
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ib_read = new Button();
            this.ub_read = new Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spektr = new Button();
            this.power = new Button();
            this.pathLabel = new Label();
            this.pathBox = new TextBox();
            this.durationBox = new TextBox();
            this.durationLabel = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ib_read
            // 
            this.ib_read.Location = new System.Drawing.Point(30, 20);
            this.ib_read.BackColor = Color.LightGreen;
            this.ib_read.ForeColor = Color.DarkBlue;
            this.ib_read.Name = "ib_read";
            this.ib_read.Size = new System.Drawing.Size(150, 50);
            this.ib_read.TabIndex = 0;
            this.ib_read.Text = "Чтение данных IB";
            this.ib_read.UseVisualStyleBackColor = false;
            this.ib_read.Click += new System.EventHandler(this.ib_read_Click);
            // 
            // ub_read
            // 
            this.ub_read.Location = new System.Drawing.Point(200, 20);
            this.ub_read.BackColor = Color.LightSkyBlue;
            this.ub_read.ForeColor = Color.DarkBlue;
            this.ub_read.Name = "ub_read";
            this.ub_read.Size = new System.Drawing.Size(150, 50);
            this.ub_read.TabIndex = 1;
            this.ub_read.Text = "Чтение данных UB";
            this.ub_read.UseVisualStyleBackColor = false;
            this.ub_read.Click += new System.EventHandler(this.ub_read_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chartArea1.BackColor = Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            //this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(30, 150);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1300, 700);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // spektr
            // 
            this.spektr.Location = new System.Drawing.Point(370, 20);
            this.spektr.BackColor = Color.LightSalmon;
            this.spektr.ForeColor = Color.DarkBlue;
            this.spektr.Name = "spektr";
            this.spektr.Size = new System.Drawing.Size(150, 50);
            this.spektr.TabIndex = 3;
            this.spektr.Text = "Спектр";
            this.spektr.UseVisualStyleBackColor = false;
            this.spektr.Click += new System.EventHandler(this.spektr_Click);
            // 
            // power
            // 
            this.power.Location = new System.Drawing.Point(540, 20);
            this.power.BackColor = Color.LightCoral;
            this.power.ForeColor = Color.DarkBlue;
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(150, 50);
            this.power.TabIndex = 4;
            this.power.Text = "Мгновенная мощность";
            this.power.UseVisualStyleBackColor = false;
            this.power.Click += new System.EventHandler(this.power_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.Location = new System.Drawing.Point(30, 90);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(150, 22);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Путь к файлу:";
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(200, 90);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(490, 22);
            this.pathBox.TabIndex = 6;
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(30, 120);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(150, 22);
            this.durationLabel.TabIndex = 7;
            this.durationLabel.Text = "Продолжительность:";
            // 
            // durationBox
            // 
            this.durationBox.Location = new System.Drawing.Point(200, 120);
            this.durationBox.Name = "durationBox";
            this.durationBox.Size = new System.Drawing.Size(150, 22);
            this.durationBox.TabIndex = 8;


            this.ib_read.Location = new System.Drawing.Point(30, 20);
            this.ub_read.Location = new System.Drawing.Point(30, 80);
            this.spektr.Location = new System.Drawing.Point(30, 140);
            this.power.Location = new System.Drawing.Point(30, 200);

            this.pathLabel.Location = new System.Drawing.Point(30, 260);
            this.pathLabel.Size = new System.Drawing.Size(150, 22);
            this.pathBox.Location = new System.Drawing.Point(30, 290);
            this.pathBox.Size = new System.Drawing.Size(250, 22);

            this.durationLabel.Location = new System.Drawing.Point(30, 330);
            this.durationLabel.Size = new System.Drawing.Size(150, 22);
            this.durationBox.Location = new System.Drawing.Point(30, 360);
            this.durationBox.Size = new System.Drawing.Size(150, 22);

            this.chart1.Location = new System.Drawing.Point(300, 20);
            this.chart1.Size = new System.Drawing.Size(1000, 630);
            this.chart1.Series[0].Color = Color.Red; // Красная линия

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 720);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.power);
            this.Controls.Add(this.spektr);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ub_read);
            this.Controls.Add(this.ib_read);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.durationBox);
            this.Name = "Form1";
            this.Text = "Анализ данных";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);


        }

        #endregion
        private Label pathLabel;
        private Label durationLabel;
        private TextBox pathBox;
        private TextBox durationBox;
        private System.Windows.Forms.Button ib_read;
        private System.Windows.Forms.Button ub_read;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button spektr;
        private System.Windows.Forms.Button power;
    }
}

