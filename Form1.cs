using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using FftSharp;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void PlotGraph(string graphType)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                SetFilePath(openFileDialog.FileName);
                SetDuration(openFileDialog.FileName);
                switch (graphType)
                {
                    case "Напряжение":
                        napryazhenie(fileName, 332);
                        break;
                    case "Сила тока":
                        sila_toka(fileName, 332);
                        break;
                    case "Спектр":
                        CalculateSpectrum(fileName, 332);
                        break;
                    default:
                        MessageBox.Show("Неверный тип графика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        private void power_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string voltageFileName = openFileDialog1.FileName;
                SetFilePath(openFileDialog1.FileName);
                SetDuration(openFileDialog1.FileName);
                OpenFileDialog openFileDialog2 = new OpenFileDialog();

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string currentFileName = openFileDialog2.FileName;
                    CalculatePower(voltageFileName, currentFileName, 332);
                }
            }
        }
        private void ib_read_Click(object sender, EventArgs e)
        {
            PlotGraph("Сила тока");
        }
        private void ub_read_Click(object sender, EventArgs e)
        {
            PlotGraph("Напряжение");
        }
        private void spektr_Click(object sender, EventArgs e)
        {
            PlotGraph("Спектр");
        }
        private void sila_toka(string fileName, int lineNumber)
        {
            PlotChart(fileName, "Зависимость силы тока от времени", "Time (seconds)", "I(t)", 0.00125, lineNumber);
        }

        private void napryazhenie(string fileName, int lineNumber)
        {
            PlotChart(fileName, "Зависимость напряжения от времени", "Time (seconds)", "U(t)", 0.00125, lineNumber);
        }

        private void PlotChart(string fileName, string chartTitle, string xAxisTitle, string yAxisTitle, double interval, int lineNumber)
        {

            double currentTime = 0;
            // Чтение данных из файла
            string[] lines = File.ReadAllLines(fileName);

            if (lineNumber >= lines.Length || lineNumber < 0)
            {
                MessageBox.Show("Номер строки выходит за пределы файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string line = lines[lineNumber];
            string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Разделение строки на отдельные значения по пробелу

            // Очистка старых данных графика
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Создание новой области для графика
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            // Создание нового ряда данных
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4; // Установка толщины линии
            chart1.Series.Add(series);

            // Добавление данных в ряд
            foreach (string value in values)
            {
                double parsedValue;
                if (double.TryParse(value.Replace('.', ','), out parsedValue))
                {
                    series.Points.AddXY(currentTime, parsedValue);
                    currentTime += interval;
                }
                else
                {
                    MessageBox.Show($"Ошибка при считывании данных: Не удалось преобразовать значение \"{value}\" в число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Прерываем выполнение метода при возникновении ошибки
                }
            }

            // Настройка масштаба и легенды
            chartArea.AxisX.Title = xAxisTitle;
            chartArea.AxisY.Title = yAxisTitle;
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisX.Interval = interval; // Интервал между отметками по оси X

            double minX = series.Points.Min(p => p.XValue);

            // Установка названия графика
            chart1.Titles.Clear();
            chart1.Titles.Add(chartTitle);
            chart1.Legends.Clear();
            chart1.Legends.Add(new Legend("Legend"));
            chartArea.AxisX.Minimum = minX;
            chartArea.AxisX.Interval = interval;
            chart1.Series[0].Legend = "Legend";
            chart1.Series[0].IsVisibleInLegend = true;
            chart1.Series[0].Color = Color.Red;

        }
        private void CalculateSpectrum(string fileName, int lineNumber)
        {

            // Чтение данных из файла
            string[] lines = File.ReadAllLines(fileName);

            if (lineNumber >= lines.Length || lineNumber < 0)
            {
                MessageBox.Show("Номер строки выходит за пределы файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string line = lines[lineNumber];
            string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Преобразование строковых значений в double
            double[] signal = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                double.TryParse(values[i].Replace('.', ','), out signal[i]);
            }
            double[] spectrum = FftSharp.Transform.FFTmagnitude(signal);
            double[] frequencies = new double[spectrum.Length];
            for (int i = 0; i < spectrum.Length; i++)
            {
                // Вычисляем частоту по формуле 800 / (64 * i)
                frequencies[i] = (800 / 64) * (i + 1);
            }

            // Очистка старых данных графика
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Создание новой области для графика
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            // Создание нового ряда данных
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4; // Установка толщины линии
            chart1.Series.Add(series);
            for (int i = 0; i < spectrum.Length; i++)
            {
                series.Points.AddXY(frequencies[i], spectrum[i]);
            }
            double minX = series.Points.Min(p => p.XValue);
            chartArea.AxisX.Minimum = minX;
            chartArea.AxisX.Title = "Частота";
            chartArea.AxisY.Title = "Амплитуда Спектра";
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisX.Interval = 8; // Интервал между отметками по оси X
          

            chart1.Titles.Clear();
            chart1.Titles.Add("Спектр");
            chart1.Legends.Clear();
            chart1.Legends.Add(new Legend("Legend1"));
            chart1.Series[0].Legend = "Legend1";
            chart1.Series[0].IsVisibleInLegend = true;

        }
        private void CalculatePower(string voltageFileName, string currentFileName, int lineNumber)
        {
            double current_time = 0;
            double intetval = 0.00125;

            string[] voltageLines = File.ReadAllLines(voltageFileName);
            string[] amperageLines = File.ReadAllLines(currentFileName);
            // Проверка корректности номера строки
            if (lineNumber >= voltageLines.Length || lineNumber >= amperageLines.Length || lineNumber < 0)
            {
                MessageBox.Show("Номер строки выходит за пределы файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Чтение значения напряжения из строки
            string voltageLine = voltageLines[lineNumber];
            string[] voltageValues = voltageLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] voltages = new double[voltageValues.Length];
            for (int i = 0; i < voltageValues.Length; i++)
            {
                double.TryParse(voltageValues[i].Replace('.', ','), out voltages[i]);
            }

            // Чтение значения силы тока из строки
            string currentLine = amperageLines[lineNumber];
            string[] currentValues = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] currents = new double[currentValues.Length];
            for (int i = 0; i < currentValues.Length; i++)
            {
                double.TryParse(currentValues[i].Replace('.', ','), out currents[i]);
            }

            // Проверка совпадения количества значений напряжения и силы тока
            if (voltages.Length != currents.Length)
            {
                MessageBox.Show("Количество значений напряжения и силы тока не совпадает.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисление мощности
            double[] powers = new double[voltages.Length];
            for (int i = 0; i < voltages.Length; i++)
            {
                powers[i] = voltages[i] * currents[i];
            }

            // Очистка старых данных графика
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Создание новой области для графика
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            // Создание нового ряда данных для мощности
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4; // Установка толщины линии
            chart1.Series.Add(series);

            // Добавление точек на график
            for (int i = 0; i < powers.Length; i++)
            {
                series.Points.AddXY(current_time, powers[i]);
                current_time += intetval;
            }
            
            // Настройка масштаба и легенды
            chartArea.AxisX.Title = "Time (seconds)";
            chartArea.AxisY.Title = "Power";
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisX.Interval = 1; // Интервал между отметками по оси X
            double minX = series.Points.Min(p => p.XValue);
            chart1.Titles.Clear();
            chart1.Titles.Add("Power");
            chart1.Legends.Clear();
            chartArea.AxisX.Minimum = minX;
            chartArea.AxisX.Interval = intetval;
            chart1.Legends.Add(new Legend("Legend1"));
            chart1.Series[0].Legend = "Legend1";
            chart1.Series[0].IsVisibleInLegend = true;
        }
        private void SetFilePath(string filePath)
        {
            this.pathBox.Text = filePath;
        }
        private void SetDuration(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int duration = lines.Length / 10;
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration);
            this.durationBox.Text = $"{timeSpan.Minutes}:{timeSpan.Seconds}";
        }
    }
}
