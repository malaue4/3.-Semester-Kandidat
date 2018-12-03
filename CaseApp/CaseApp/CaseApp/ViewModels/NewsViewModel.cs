using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CaseApp.Services;
using CaseApp.UWP.Annotations;

namespace CaseApp.ViewModels
{
    class NewsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Article> _favoriteArticles;
        public ObservableCollection<Article> Articles { get; } = new ObservableCollection<Article>();

        public ObservableCollection<Article> FavoriteArticles
        {
            get => _favoriteArticles;
            set
            {
                if (Equals(value, _favoriteArticles)) return;
                _favoriteArticles = value;
                OnPropertyChanged();
            }
        }

        public NewsViewModel()
        {
            Articles.CollectionChanged += (sender, args) =>
                {
                    switch (args.Action)
                    {
                        case NotifyCollectionChangedAction.Add:

                            break;
                        case NotifyCollectionChangedAction.Move:
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            break;
                        case NotifyCollectionChangedAction.Replace:
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                };

            Task.Run(async () => {
                foreach (var article in await NewsProvider.GetProvider().GetNews())
                {
                    Articles.Add(article);
                }
            }).ContinueWith((task) =>
            {
                Debug.Print($"naiwa: {task.Status}");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
