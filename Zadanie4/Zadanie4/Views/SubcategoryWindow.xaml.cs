using System.Windows;
using Zadanie4.Models;

namespace Zadanie4.Views
{
    public partial class SubcategoryWindow : Window
    {
        public Subcategory Subcategory { get; }

        public SubcategoryWindow(Subcategory subcategory)
        {
            InitializeComponent();
            Subcategory = subcategory;
            DataContext = Subcategory;
        }
    }
}
