using EquipmentRecorder.models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Diagnostics;

using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO.Pipes;

namespace EquipmentRecorder
{
    /// <summary>
    /// Interaction logic for ReportGenerationWIndow.xaml
    /// </summary>
    public partial class ReportGenerationWindow : Window
    {
        private Division[] divisions;

        public ReportGenerationWindow()
        {
            InitializeComponent();

            // Populate the division combo box
            divisions = new Division[]
            {
                new Division { Name = "Division 1" },
                new Division { Name = "Division 2" },
                new Division { Name = "Division 3" }
            };

            DivisionComboBox.ItemsSource = divisions;
            DivisionComboBox.DisplayMemberPath = "Name";
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected report type
            string reportType = "";
            if (EquipmentAssignmentsRadioButton.IsChecked == true)
            {
                reportType = "Equipment Assignments";
            }
            else if (EquipmentReplacementsRadioButton.IsChecked == true)
            {
                reportType = "Equipment Replacements";
            }
            else if (EmployeeInformationRadioButton.IsChecked == true)
            {
                reportType = "Employee Information";
            }

            // Get the selected division
            string division = ((Division)DivisionComboBox.SelectedItem)?.Name;

            // Get the selected date range
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MaxValue;

            // Get the selected output format
            string outputFormat = "";
            if (PdfRadioButton.IsChecked == true)
            {
                outputFormat = "PDF";
            }
            else if (ExcelRadioButton.IsChecked == true)
            {
                outputFormat = "Excel";
            }

            // Generate the report
            string report = "";

            switch (reportType)
            {
                case "Equipment Assignments":
                    report = "Назначение оборудования";
                    break;
                case "Equipment Replacements":
                    report = "Замена оборудования";
                    break;
                case "Employee Information":
                    report = "Информация о работниках";
                    break;
            }



            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Encoding objEncoding = Encoding.Default;

            // Create PDF Document
            PdfDocument pdfDocument = new PdfDocument();
            // Create PDF page
            PdfPage pdfPage = pdfDocument.AddPage();
            // For drawing in PDF page
            XGraphics gfx = XGraphics.FromPdfPage(pdfPage);
            // define font
            XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
            // draw text in PDF page
            gfx.DrawString(report, font, XBrushes.Black, new XRect(0, 0, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);

            string fileName = reportType;
            pdfDocument.Save($"C:/Users/ikupc/Downloads/{fileName}.pdf");
        }



        // Navigate to first window
        private void GoToFirstWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
            
        }

        // Navigate to second window
        private void GoToSecondWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ResourceUpdatesWindow();
            window.Show();
            this.Close();
        }

        // Navigate to third window
        private void GoToThirdWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeMonitoringWindow();
            window.Show();
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
