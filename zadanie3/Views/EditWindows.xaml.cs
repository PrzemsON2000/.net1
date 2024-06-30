using System.Windows;
using zadanie3.models;

namespace zadanie3.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(MediaItem mediaItem) : this()
        {
            // Tutaj przypisz mediaItem do DataContext lub odpowiednich elementów UI
        }
    }
}
