using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using zadanie3.models;
using zadanie3.Commands;

namespace zadanie3.ViewModels
{
    public class AddEditMediaItemViewModel : INotifyPropertyChanged
    {
        public MediaItem MediaItem { get; set; }

        public AddEditMediaItemViewModel(MediaItem mediaItem)
        {
            MediaItem = mediaItem;
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        public string Title
        {
            get => MediaItem.Title;
            set
            {
                MediaItem.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string AuthorDirector
        {
            get => MediaItem.AuthorDirector;
            set
            {
                MediaItem.AuthorDirector = value;
                OnPropertyChanged(nameof(AuthorDirector));
            }
        }

        public string PublisherStudio
        {
            get => MediaItem.PublisherStudio;
            set
            {
                MediaItem.PublisherStudio = value;
                OnPropertyChanged(nameof(PublisherStudio));
            }
        }

        public string MediaType
        {
            get => MediaItem.MediaType;
            set
            {
                MediaItem.MediaType = value;
                OnPropertyChanged(nameof(MediaType));
            }
        }

        public DateTime? ReleaseDate
        {
            get => MediaItem.ReleaseDate;
            set
            {
                MediaItem.ReleaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private void Save(object? parameter)
        {
            // Logika zapisu
            if (parameter is Window window)
            {
                window.DialogResult = true;
            }
        }

        private void Cancel(object? parameter)
        {
            // Logika anulowania
            if (parameter is Window window)
            {
                window.DialogResult = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
