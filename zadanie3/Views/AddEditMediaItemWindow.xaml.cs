using System.Windows;
using zadanie3.models;
using zadanie3.ViewModels;

namespace zadanie3.Views
{
    public partial class AddEditMediaItemWindow : Window
    {
        public AddEditMediaItemWindow(MediaItem mediaItem)
        {
            InitializeComponent();
            DataContext = new AddEditMediaItemViewModel(mediaItem);
        }
    }
}
