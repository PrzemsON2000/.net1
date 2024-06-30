using System.Windows;
using Zadanie4.Models;

namespace Zadanie4.Views
{
    public partial class CategoryWindow : Window
    {
        public Category Category { get; }

        public CategoryWindow(Category category)
        {
            InitializeComponent();
            Category = category;
            DataContext = Category;
            SubcategoryListBox.ItemsSource = Category.Subcategories;
        }

        private void SubcategoryListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection changed
        }

        private void OpenSubcategory_Click(object sender, RoutedEventArgs e)
        {
            if (SubcategoryListBox.SelectedItem is Subcategory selectedSubcategory)
            {
                SubcategoryWindow subcategoryWindow = new SubcategoryWindow(selectedSubcategory);
                subcategoryWindow.Show();
            }
        }
    }
}
