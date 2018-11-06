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
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        */
        Task<RssSchema> GetRssFeedAsync(Uri feedUri);
        Task<IEnumerable<RssSchema>> GetRssFeedsAsync(bool forceRefresh = false);
    }
}
