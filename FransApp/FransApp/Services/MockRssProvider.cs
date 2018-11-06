using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;

namespace FransApp.Services
{
    class MockRssProvider : IRssProvider
    {
        public Task<RssSchema> GetRssFeedAsync(Uri feedUri)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RssSchema>> GetRssFeedsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
