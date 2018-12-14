using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CaseApp.Behaviors
{
    public class UrlValidatorBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(UrlValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var hasProto = Regex.IsMatch(e.NewTextValue, "\\A\\w*://.*", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            var url = e.NewTextValue;
            if (!hasProto)
            {
                url = "https://" + url;
            }

            IsValid = Uri.TryCreate(url, UriKind.Absolute, out var result);
            ((Entry) sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
