using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using static ipcleaner.Form1;

namespace ipcleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnClean.Click += BtnClean_Click;
            btnSelectFile.Click += BtnSelectFile_Click;
            lblStatus.Visible = false;

            // Wiring up the Load and Resize events
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a CSV file first.");
                return;
            }

            try
            {
                var records = ReadCsv(txtFilePath.Text);
                var cleanedRecords = CleanData(records);
                var outputPath = Path.Combine(Path.GetDirectoryName(txtFilePath.Text), "cleaned_file.csv");
                WriteCsv(outputPath, cleanedRecords);
                lblStatus.Visible = true;
                lblStatus.Text = $"Data cleaned and saved to: {outputPath}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred.";
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private List<OriginalData> ReadCsv(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<OriginalDataMap>();
            return csv.GetRecords<OriginalData>().ToList();
        }

        private List<CleanedData> CleanData(List<OriginalData> records)
        {
            var cleanedData = new List<CleanedData>();

            foreach (var record in records)
            {
                var parts = record.Name.Split('\n');
                if (parts.Length >= 3)
                {
                    cleanedData.Add(new CleanedData { Name = $"{parts[0].Trim()},{parts[2].Trim().Replace("-", "")}" });
                }
                else if (parts.Length == 2)
                {
                    cleanedData.Add(new CleanedData { Name = $"{parts[0].Trim()},{parts[1].Trim().Replace("-", "")}" });
                }
                else
                {
                    cleanedData.Add(new CleanedData { Name = parts[0].Trim() });
                }
            }

            return cleanedData;
        }

        private void WriteCsv(string path, List<CleanedData> records)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }

        public class OriginalData
        {
            public string Ip { get; set; }
            public string Name { get; set; }
        }

        public class CleanedData
        {
            public string Name { get; set; }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {

        }

        // Event handlers to center controls
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterControlsHorizontally(btnSelectFile, btnClean, txtFilePath, lblStatus);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControlsHorizontally(btnSelectFile, btnClean, txtFilePath, lblStatus);
        }

        private void CenterControlsHorizontally(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Left = (this.ClientSize.Width - control.Width) / 2;
            }
        }
    }

    public class OriginalDataMap : ClassMap<OriginalData>
    {
        public OriginalDataMap()
        {
            Map(m => m.Ip).Name("ip");
            Map(m => m.Name).Name("name");
        }
    }
}
