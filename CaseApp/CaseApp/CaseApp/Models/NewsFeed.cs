using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace CaseApp.Models
{
    public class NewsFeed
    {
        private Uri _link;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkString { get; set; }

        [Ignore]
        public Uri Link
        {
            get
            {
                if(_link == null) _link = new Uri(LinkString);
                return _link;
            }
            set
            {
                _link = value;
                LinkString = value.OriginalString;
            }
        }
    }
}
