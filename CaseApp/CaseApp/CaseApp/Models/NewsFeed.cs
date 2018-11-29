using System;
using System.Collections.Generic;
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

        public ImageSource Icon { get; set; }
    }
}
