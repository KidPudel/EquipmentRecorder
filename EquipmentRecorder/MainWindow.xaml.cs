using EquipmentRecorder.models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipmentRecorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<EquipmentAssignment> _assignments = new List<EquipmentAssignment>();

        public MainWindow()
        {
            InitializeComponent();
            AssignmentsDataGrid.ItemsSource = _assignments;
        }

        private void AddAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            _assignments.Add(new EquipmentAssignment(_assignments.Count + 1, $"Computer {_assignments.Count + 1}", "Smith", _assignments.Count, "IT", DateTime.Now));
            AssignmentsDataGrid.Items.Refresh();
        }

        private void EditAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssignmentsDataGrid.SelectedItem != null)
            {
                var assignment = (EquipmentAssignment)AssignmentsDataGrid.SelectedItem;
                var editRow = new DataGridRow { DataContext = assignment };
                AssignmentsDataGrid.SelectedItem = null;
                AssignmentsDataGrid.ScrollIntoView(assignment, null);
                AssignmentsDataGrid.UpdateLayout();
                AssignmentsDataGrid.SelectedItem = editRow;
            }
            AssignmentsDataGrid.Items.Refresh();
        }

        private void DeleteAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssignmentsDataGrid.SelectedItem != null)
            {
                _assignments.Remove((EquipmentAssignment)AssignmentsDataGrid.SelectedItem);
            }
            AssignmentsDataGrid.Items.Refresh();
        }


        // navigation
        private void GoToResourceUpdateWindow(object sender, RoutedEventArgs e)
        {
            var resourceUpdateWindow = new ResourceUpdatesWindow();
            resourceUpdateWindow.Show();
            this.Close();
        }

        private void GoToEmployeeMonitoringWindow(object sender, RoutedEventArgs e)
        {
            var employeeMonitoringWindow = new EmployeeMonitoringWindow();
            employeeMonitoringWindow.Show();
            this.Close();
        }

        private void GoToReportGenerationWindow(object sender, RoutedEventArgs e)
        {
            var reportGenerationWindow = new ReportGenerationWindow();
            reportGenerationWindow.Show();
            this.Close();
        }

        private void AssignmentsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var assignment = (EquipmentAssignment)e.Row.DataContext;
                if (e.Column.Header.ToString() == "Inventory Number")
                {
                    assignment.InventoryNumber = Int32.Parse(((TextBox)e.EditingElement).Text);
                }
                else if (e.Column.Header.ToString() == "Equipment Name")
                {
                    assignment.EquipmentName = ((TextBox)e.EditingElement).Text;
                }
                else if (e.Column.Header.ToString() == "Employee Name")
                {
                    assignment.EmployeeName = ((TextBox)e.EditingElement).Text;
                }
                else if (e.Column.Header.ToString() == "Employee ID")
                {
                    assignment.EmployeeID = Int32.Parse(((TextBox)e.EditingElement).Text);
                }
                else if (e.Column.Header.ToString() == "Division")
                {
                    assignment.Division = ((TextBox)e.EditingElement).Text;
                }
                else if (e.Column.Header.ToString() == "Date Assigned")
                {
                    assignment.DateAssigned = ((DatePicker)e.EditingElement).SelectedDate;
                }
            }
        }
    }
}
