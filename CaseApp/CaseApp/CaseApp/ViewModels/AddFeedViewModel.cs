using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CaseApp.Services;
using Xamarin.Forms;

namespace CaseApp.ViewModels
{
    class AddFeedViewModel : BaseViewModel
    {
        private NewsFeed _newsFeedCandidate;
        private List<Article> _articles;
        private string _errorMessage;

        public NewsFeed NewsFeedCandidate
        {
            get => _newsFeedCandidate;
            set
            {
                if (_newsFeedCandidate != value)
                {
                    _newsFeedCandidate = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Article> Articles
        {
            get => _articles;
            set
            {
                if (_articles != value)
                {
                    _articles = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddFeedCommand
        {
            get
            {
                return new Command(async obj =>
                {
                    if ((await App.Database.GetNewsFeedsAsync()).Any(feed => feed.LinkString == NewsFeedCandidate.LinkString))
                    {
                        //It is already here
                    }
                    else
                    {
                        await App.Database.SaveNewsFeedAsync(NewsFeedCandidate);
                        NewsFeedCandidate = null;
                    }
                });
            }
        }

        public async Task TestFeed(string feedUrl)
        {
            Articles = await new RssParser().ParseFeed(feedUrl);
            if (Articles != null)
            {
                ErrorMessage = null;
                NewsFeedCandidate = Articles[0].Source;
            }
            else
            {
                // Error: it was not a valid rss feed
                ErrorMessage = $"Error: '{feedUrl}' is not a valid rss feed";
                NewsFeedCandidate = null;
            }
        }
    }
}
