using System;
using System.Collections.Generic;
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

namespace EquipmentRecorder
{
    /// <summary>
    /// Interaction logic for AccountingOldResourses.xaml
    /// </summary>
    public partial class ResourceUpdatesWindow : Window
    {
        public ResourceUpdatesWindow()
        {
            InitializeComponent();
        }

        private void EquipmentAssignments_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void EmployeeInformation_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeMonitoringWindow();
            window.Show();
            Close();
        }

        private void GenerateReports_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReportGenerationWindow();
            window.Show();
            Close();
        }
    }
}
