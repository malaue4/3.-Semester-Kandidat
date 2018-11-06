using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;

namespace FransApp.Services
{
    class MockRssProvider : IRssProvider
    {
        public Task<IEnumerable<RssSchema>> GetRssFeedAsync(Uri feedUri)
        {
            //Burde hente rss'en baseret på Uri'en, men istedet får de lidt hardcoded xkcd.
            return new Task<IEnumerable<RssSchema>>(
                ()=>ParseRss("<?xml version=\"1.0\" encoding=\"utf-8\"?><rss version=\"2.0\"><channel><title>xkcd.com</title><link>https://xkcd.com/</link><description>xkcd.com: A webcomic of romance and math humor.</description><language>en</language><item><title>Rock Wall</title><link>https://xkcd.com/2058/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/rock_wall.png\" title=\"I don\'t trust mantle/core geologists because I suspect that, if they ever get a chance to peel away the Earth\'s crust, they\'ll do it in a heartbeat.\" alt=\"I don\'t trust mantle/core geologists because I suspect that, if they ever get a chance to peel away the Earth\'s crust, they\'ll do it in a heartbeat.\" /&gt;</description><pubDate>Fri, 12 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2058/</guid></item><item><title>Internal Monologues</title><link>https://xkcd.com/2057/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/internal_monologues.png\" title=\"Haha, just kidding, everyone\'s already been hacked. I wonder if today\'s the day we find out about it.\" alt=\"Haha, just kidding, everyone\'s already been hacked. I wonder if today\'s the day we find out about it.\" /&gt;</description><pubDate>Wed, 10 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2057/</guid></item><item><title>Horror Movies</title><link>https://xkcd.com/2056/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/horror_movies.png\" title=\"&amp;quot;Isn\'t the original Jurassic Park your favorite movie of all time?&amp;quot; &amp;quot;Yes, but that\'s because I like dinosaurs and I WANT there to be an island full of them. If John Hammond\'s lab had been breeding serial killers in creepy masks, I wouldn\'t have watched!&amp;quot; &amp;quot;Wait, are you sure? That could actually be good.&amp;quot; &amp;quot;Ok, I WOULD watch the scenes where Jeff Goldblum tries to convince a bunch of executives that the park is a bad idea.&amp;quot;\" alt=\"&amp;quot;Isn\'t the original Jurassic Park your favorite movie of all time?&amp;quot; &amp;quot;Yes, but that\'s because I like dinosaurs and I WANT there to be an island full of them. If John Hammond\'s lab had been breeding serial killers in creepy masks, I wouldn\'t have watched!&amp;quot; &amp;quot;Wait, are you sure? That could actually be good.&amp;quot; &amp;quot;Ok, I WOULD watch the scenes where Jeff Goldblum tries to convince a bunch of executives that the park is a bad idea.&amp;quot;\" /&gt;</description><pubDate>Mon, 08 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2056/</guid></item><item><title>Bluetooth</title><link>https://xkcd.com/2055/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/bluetooth.png\" title=\"Bluetooth is actually named for the tenth-century Viking king Harald &amp;quot;Bluetooth&amp;quot; Gormsson, but the protocol developed by Harald was a wireless charging standard unrelated to the modern Bluetooth except by name.\" alt=\"Bluetooth is actually named for the tenth-century Viking king Harald &amp;quot;Bluetooth&amp;quot; Gormsson, but the protocol developed by Harald was a wireless charging standard unrelated to the modern Bluetooth except by name.\" /&gt;</description><pubDate>Fri, 05 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2055/</guid></item></channel></rss>")
                );
        }

        public Task<IEnumerable<RssSchema>> GetRssFeedsAsync(bool forceRefresh = false)
        {
            return new Task<IEnumerable<RssSchema>>(
                () => ParseRss("<?xml version=\"1.0\" encoding=\"utf-8\"?><rss version=\"2.0\"><channel><title>xkcd.com</title><link>https://xkcd.com/</link><description>xkcd.com: A webcomic of romance and math humor.</description><language>en</language><item><title>Rock Wall</title><link>https://xkcd.com/2058/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/rock_wall.png\" title=\"I don\'t trust mantle/core geologists because I suspect that, if they ever get a chance to peel away the Earth\'s crust, they\'ll do it in a heartbeat.\" alt=\"I don\'t trust mantle/core geologists because I suspect that, if they ever get a chance to peel away the Earth\'s crust, they\'ll do it in a heartbeat.\" /&gt;</description><pubDate>Fri, 12 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2058/</guid></item><item><title>Internal Monologues</title><link>https://xkcd.com/2057/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/internal_monologues.png\" title=\"Haha, just kidding, everyone\'s already been hacked. I wonder if today\'s the day we find out about it.\" alt=\"Haha, just kidding, everyone\'s already been hacked. I wonder if today\'s the day we find out about it.\" /&gt;</description><pubDate>Wed, 10 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2057/</guid></item><item><title>Horror Movies</title><link>https://xkcd.com/2056/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/horror_movies.png\" title=\"&amp;quot;Isn\'t the original Jurassic Park your favorite movie of all time?&amp;quot; &amp;quot;Yes, but that\'s because I like dinosaurs and I WANT there to be an island full of them. If John Hammond\'s lab had been breeding serial killers in creepy masks, I wouldn\'t have watched!&amp;quot; &amp;quot;Wait, are you sure? That could actually be good.&amp;quot; &amp;quot;Ok, I WOULD watch the scenes where Jeff Goldblum tries to convince a bunch of executives that the park is a bad idea.&amp;quot;\" alt=\"&amp;quot;Isn\'t the original Jurassic Park your favorite movie of all time?&amp;quot; &amp;quot;Yes, but that\'s because I like dinosaurs and I WANT there to be an island full of them. If John Hammond\'s lab had been breeding serial killers in creepy masks, I wouldn\'t have watched!&amp;quot; &amp;quot;Wait, are you sure? That could actually be good.&amp;quot; &amp;quot;Ok, I WOULD watch the scenes where Jeff Goldblum tries to convince a bunch of executives that the park is a bad idea.&amp;quot;\" /&gt;</description><pubDate>Mon, 08 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2056/</guid></item><item><title>Bluetooth</title><link>https://xkcd.com/2055/</link><description>&lt;img src=\"https://imgs.xkcd.com/comics/bluetooth.png\" title=\"Bluetooth is actually named for the tenth-century Viking king Harald &amp;quot;Bluetooth&amp;quot; Gormsson, but the protocol developed by Harald was a wireless charging standard unrelated to the modern Bluetooth except by name.\" alt=\"Bluetooth is actually named for the tenth-century Viking king Harald &amp;quot;Bluetooth&amp;quot; Gormsson, but the protocol developed by Harald was a wireless charging standard unrelated to the modern Bluetooth except by name.\" /&gt;</description><pubDate>Fri, 05 Oct 2018 04:00:00 -0000</pubDate><guid>https://xkcd.com/2055/</guid></item></channel></rss>")
                );
        }



        public IEnumerable<RssSchema> ParseRss(string feed)
        {
            if (feed == null) return null;
            var parser = new RssParser();
            var rss = parser.Parse(feed);

            return rss;
        }
    }
}
