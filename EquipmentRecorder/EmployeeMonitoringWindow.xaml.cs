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
using System.Windows.Shapes;

namespace EquipmentRecorder
{
    /// <summary>
    /// Interaction logic for EmployeeMonitoringWindow.xaml
    /// </summary>
    public partial class EmployeeMonitoringWindow : Window
    {
        private readonly List<Employee> employees = new List<Employee>();
        public EmployeeMonitoringWindow()
        {
            InitializeComponent();
            EmployeesDataGrid.ItemsSource = employees;
        }

        // Add a new employee
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            // Add the new employee to the employees list
            employees.Add(new Employee(employees.Count, "Smith", $"@{employees.Count}", "sys admin", "IT", true));

            // Refresh the employees datagrid
            EmployeesDataGrid.Items.Refresh();
        }

        // Edit an existing employee
        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the currently selected employee
            Employee selectedEmployee = (Employee)EmployeesDataGrid.SelectedItem;

            // Make sure an employee is selected
            if (selectedEmployee != null)
            {
                // Update the selected employee's properties
                selectedEmployee.EmployeeId = 9999;
                selectedEmployee.Name = "Linus";
                selectedEmployee.IdNumber = $"@{9999}";
                selectedEmployee.JobTitle = "Linux creater";
                selectedEmployee.Division = "IT";

                // Refresh the employees datagrid
                EmployeesDataGrid.Items.Refresh();
            }
        }

        // Delete an existing employee
        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the currently selected employee
            Employee selectedEmployee = (Employee)EmployeesDataGrid.SelectedItem;

            // Make sure an employee is selected
            if (selectedEmployee != null)
            {
                // Remove the selected employee from the employees list
                employees.Remove(selectedEmployee);

                // Refresh the employees datagrid
                EmployeesDataGrid.Items.Refresh();
            }
        }

        private void EquipmentAssignment_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void EquipmentUpdates_Click(object sender, RoutedEventArgs e)
        {
            var window = new ResourceUpdatesWindow();
            window.Show();
            this.Close();
        }

        private void GenerateReports_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReportGenerationWindow();
            window.Show();
            this.Close();
        }

    }
}
