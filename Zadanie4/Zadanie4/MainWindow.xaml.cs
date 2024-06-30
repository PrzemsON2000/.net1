using System.Windows;
using Zadanie4.Models;
using Zadanie4.Views;

namespace Zadanie4
{
    public partial class MainWindow : Window
    {
        private VehicleData _vehicleData;

        public MainWindow()
        {
            InitializeComponent();
            _vehicleData = VehicleData.LoadFromFile("Resources/vehicles.xml");
            CategoryListBox.ItemsSource = _vehicleData.Categories;
        }

        private void CategoryListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection changed
        }

        private void OpenCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryListBox.SelectedItem is Category selectedCategory)
            {
                CategoryWindow categoryWindow = new CategoryWindow(selectedCategory);
                categoryWindow.Show();
            }
        }
    }
}
