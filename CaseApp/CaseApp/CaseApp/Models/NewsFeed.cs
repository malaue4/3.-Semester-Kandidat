using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace CaseApp.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }

        private byte[] icon;
        public ImageSource Icon { get {
                if(icon == null)
                {
                    var image = ImageSource.FromUri(new Uri($"https://www.google.com/s2/favicons?domain={Link}"));
                    
                    return image;
                } else
                {
                    var image = ImageSource.FromStream(() => new MemoryStream(icon));
                    return image;
                }
            }}
    }
}
