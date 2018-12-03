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

        public Task<List<Article>> GetFavorites()
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
    }
}
