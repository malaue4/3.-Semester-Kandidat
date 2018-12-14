using CaseApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseApp.Services
{
    public class LocalDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public LocalDatabase(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<NewsFeed>().Wait();
            _database.CreateTableAsync<Article>().Wait();
        }

        public Task<List<Article>> GetFavoritesAsync()
        {
            return _database.Table<Article>().ToListAsync();
        }

        public Task<Article> GetItemAsync(int id)
        {
            return _database.Table<Article>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Article item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Article item)
        {
            return _database.DeleteAsync(item);
        }

        public async Task<bool> HasItem(Article article)
        {
            return await _database.Table<Article>().Where(i => i.Equals(article)).CountAsync() > 0;
        }


        public Task<List<NewsFeed>> GetNewsFeedsAsync()
        {
            return _database.Table<NewsFeed>().ToListAsync();
        }

        public Task<NewsFeed> GetNewsFeedAsync(int id)
        {
            return _database.Table<NewsFeed>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateNewsFeedAsync(NewsFeed item)
        {
            return _database.UpdateAsync(item);
        }


        public Task<int> SaveNewsFeedAsync(NewsFeed item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteNewsFeedAsync(NewsFeed item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
