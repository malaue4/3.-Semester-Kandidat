using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CaseApp.Annotations;
using SQLite;

namespace CaseApp.Models
{
    public class Article : INotifyPropertyChanged
    {
        private bool _favorite;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Ignore]
        public NewsFeed Source { get; set; }
        public int SourceId { get; set; }
        public Uri Link { get; set; }

        public bool Favorite
        {
            get => _favorite;
            set
            {
                if (value == _favorite) return;
                _favorite = value;
                if (_favorite)
                    App.Database.SaveItemAsync(this);
                else
                    App.Database.DeleteItemAsync(this);
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
