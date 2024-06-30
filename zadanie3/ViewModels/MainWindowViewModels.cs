using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using zadanie3.models;
using zadanie3.Views;
using zadanie3.Commands;

namespace zadanie3.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MediaItem> MediaItems { get; set; }
        private MediaItem? _selectedMediaItem;

        public MediaItem? SelectedMediaItem
        {
            get => _selectedMediaItem;
            set
            {
                if (_selectedMediaItem != value)
                {
                    _selectedMediaItem = value;
                    OnPropertyChanged(nameof(SelectedMediaItem));
                }
            }
        }

        public ICommand DodajCommand { get; set; }
        public ICommand EdytujCommand { get; set; }
        public ICommand UsunCommand { get; set; }
        public ICommand ImportujCommand { get; set; }
        public ICommand EksportujCommand { get; set; }

        public MainWindowViewModel()
        {
            MediaItems = new ObservableCollection<MediaItem>();
            DodajCommand = new RelayCommand(DodajMediaItem);
            EdytujCommand = new RelayCommand(EdytujMediaItem, CanEditOrDelete);
            UsunCommand = new RelayCommand(UsunMediaItem, CanEditOrDelete);
            ImportujCommand = new RelayCommand(ImportujMediaItems);
            EksportujCommand = new RelayCommand(EksportujMediaItems);
        }

        private void DodajMediaItem(object? parameter)
        {
            var newMediaItem = new MediaItem();
            var addEditWindow = new AddEditMediaItemWindow(newMediaItem);
            if (addEditWindow.ShowDialog() == true)
            {
                MediaItems.Add(newMediaItem);
            }
        }

        private void EdytujMediaItem(object? parameter)
        {
            if (SelectedMediaItem != null)
            {
                var editWindow = new AddEditMediaItemWindow(SelectedMediaItem);
                editWindow.ShowDialog();
            }
        }

        private bool CanEditOrDelete(object? parameter)
        {
            return SelectedMediaItem != null;
        }

        private void UsunMediaItem(object? parameter)
        {
            if (SelectedMediaItem != null)
            {
                MediaItems.Remove(SelectedMediaItem);
            }
        }

        private void ImportujMediaItems(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var lines = File.ReadAllLines(openFileDialog.FileName);
                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    if (values.Length == 5)
                    {
                        MediaItems.Add(new MediaItem
                        {
                            Title = values[0],
                            AuthorDirector = values[1],
                            PublisherStudio = values[2],
                            MediaType = values[3],
                            ReleaseDate = DateTime.TryParse(values[4], out DateTime releaseDate) ? (DateTime?)releaseDate : null
                        });
                    }
                }
            }
        }

        private void EksportujMediaItems(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var lines = new List<string>();
                foreach (var item in MediaItems)
                {
                    lines.Add($"{item.Title},{item.AuthorDirector},{item.PublisherStudio},{item.MediaType},{item.ReleaseDate?.ToString("yyyy-MM-dd")}");
                }
                File.WriteAllLines(saveFileDialog.FileName, lines);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
