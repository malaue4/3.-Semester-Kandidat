using System;
using System.Collections.Generic;
using System.Text;

namespace CaseApp
{
    static class Utility
    {
        public static string RelativeTime(DateTime then)
        {
            var now = DateTime.Now.Date;
            return RelativeTime(then, now);
        }
        public static string RelativeTime(DateTime then, DateTime now)
        {
            var delta = now.Subtract(then.Date);

            if (delta.Days == 0)
            {
                return "Today";
            }

            if (delta.Days == 1)
            {
                return "Yesterday";
            }

            if (delta.Days <= 7)
            {
                return $"{delta.Days} days ago";
            }

            if (delta.Days <= 30)
            {
                return $"{delta.Days / 7} week{(delta.Days < 14 ? "" : "s")} ago";
            }

            if (delta.Days <= 360)
            {
                return $"{delta.Days / 30} month{(delta.Days < 60 ? "" : "s")} ago";
            }

            return $"{delta.Days / 360} year{(delta.Days < 720 ? "" : "s")} ago";
        }
    }
}
