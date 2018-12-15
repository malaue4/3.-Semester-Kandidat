using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Xamarin.Forms;

namespace CaseApp.Behaviors
{
    public class UrlValidatorBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly(nameof(IsValid), typeof(bool), typeof(UrlValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        /*
        static readonly BindablePropertyKey ErrorReasonPropertyKey = BindableProperty.CreateReadOnly(nameof(ErrorReason), typeof(Reason), typeof(UrlValidatorBehavior), false);

        public static readonly BindableProperty ErrorReasonProperty = ErrorReasonPropertyKey.BindableProperty;
        private Reason _errorReason;

        public Reason ErrorReason {
            get => (Reason)GetValue(ErrorReasonProperty);
            set => SetValue(ErrorReasonPropertyKey, value);
        }

        public enum Reason
        {
            MalformedUrl,
            MalformedXml,
            Unknown
        }*/

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
            if(Uri.TryCreate(url, UriKind.Absolute, out var result))
            {
                try
                {
                    //XDocument.Load(result.AbsoluteUri);
                    IsValid = true;
                }
                catch (System.Xml.XmlException)
                {
                    IsValid = false;
                    //ErrorReason = Reason.MalformedXml;
                } catch (Exception)
                {
                    IsValid = false;
                    //ErrorReason = Reason.Unknown;
                }
            } else
            {
                IsValid = false;
                //ErrorReason = Reason.MalformedUrl;
            }
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
