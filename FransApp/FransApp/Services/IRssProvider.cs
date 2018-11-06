using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;

namespace FransApp.Services
{
    interface IRssProvider
    {
        /*
        Task<bool> SubscribeToFeedAsync(Uri feed);
        Task<bool> UnsubscribeFromFeedAsync(Uri feed);
        */
        Task<IEnumerable<RssSchema>> GetRssFeedAsync(Uri feedUri); // Hent en specifik rss feed
        Task<IEnumerable<RssSchema>> GetRssFeedsAsync(bool forceRefresh = false); // Hent alle de rss feeds som er vi er subscribed til (forceRefresh == brug ikke cache? måske?)
    }
}
