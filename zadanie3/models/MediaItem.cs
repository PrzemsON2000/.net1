using System;
using System.ComponentModel;

namespace zadanie3.models
{
    public class MediaItem : INotifyPropertyChanged
    {
        private string _title;
        private string _authorDirector;
        private string _publisherStudio;
        private string _mediaType;
        private DateTime? _releaseDate;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string AuthorDirector
        {
            get => _authorDirector;
            set
            {
                if (_authorDirector != value)
                {
                    _authorDirector = value;
                    OnPropertyChanged(nameof(AuthorDirector));
                }
            }
        }

        public string PublisherStudio
        {
            get => _publisherStudio;
            set
            {
                if (_publisherStudio != value)
                {
                    _publisherStudio = value;
                    OnPropertyChanged(nameof(PublisherStudio));
                }
            }
        }

        public string MediaType
        {
            get => _mediaType;
            set
            {
                if (_mediaType != value)
                {
                    _mediaType = value;
                    OnPropertyChanged(nameof(MediaType));
                }
            }
        }

        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (_releaseDate != value)
                {
                    _releaseDate = value;
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
