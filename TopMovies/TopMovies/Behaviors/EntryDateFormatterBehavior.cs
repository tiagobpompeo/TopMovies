using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TopMovies.Behaviors
{
    public class EntryDateFormatterBehavior : Behavior<Entry>
    {
        public EntryDateFormatterBehavior()
        {
        }



        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var ev = e as TextChangedEventArgs;

            if (ev.NewTextValue != ev.OldTextValue)
            {
                var entry = (Entry)sender;
                string text = Regex.Replace(ev.NewTextValue, @"[^0-9]", "");

                text = text.PadRight(8);

                // removendo todos os digitos excedentes 
                if (text.Length > 8)
                {
                    text = text.Remove(8);
                }
                
                text = text.Insert(2, "/").Insert(5, "/").TrimEnd(new char[] { ' ', '/'});
                if (entry.Text != text)
                    entry.Text = text;

            }

        }


    }
}
