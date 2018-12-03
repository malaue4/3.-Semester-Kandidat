using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CaseApp.Models
{
    public class Article : INotifyPropertyChanged
    {
        private bool _favorite;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public NewsFeed Source { get; set; }
        public Uri Link { get; set; }
        public DateTime PublishDate { get; set; }


        public bool Favorite
        {
            get => _favorite;
            set
            {
                if (_favorite == value) return;
                OnPropertyChanged();
                _favorite = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
