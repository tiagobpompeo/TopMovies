using System;
using Xamarin.Forms;

namespace TopMovies.Behaviors
{
    public class MaskBehaviorEntry : Behavior<Entry>
    {
        public int MaxLength { get; set; }
        public bool Formatado { get; set; }
        public string Tipo { get; set; }
        internal const int LENGTH_CPF = 11;
        internal const int LENGTH_CNPJ = 14;
        internal const int LENGTH_DATE = 8;
        internal const int LENGTH_DATE_CARTAO_CREDITO = 6;
        internal const int LENGTH_PHONE_SEM_MASCARA_10 = 10;
        internal const int LENGTH_PHONE_SEM_MASCARA_11 = 11;
        internal const int LENGTH_PHONE_SEM_MASCARA_14 = 14;
        internal const int LENGTH_DECIMAL = 2;

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
            var entry = (Entry)sender;
            var entryText = e.NewTextValue;
            var entryLength = entryText.Length;
            var entryVal = 0M;

            switch (Tipo)
            {
                case "Cpf":
                    if (entryLength == LENGTH_CPF && !Formatado)
                    {
                        entryVal = Convert.ToUInt64(entryText);
                        entryText = entryVal.ToString(@"000\.000\.000\-00");
                        Formatado = true;
                    }
                    else if (entryText.Length > MaxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1);
                    }
                    else if (entryText.Length < MaxLength && Formatado)
                    {
                        entryText = entryText.RemoveNonNumbers();
                        Formatado = false;
                    }

                    entry.Text = entryText;
                    entry.TextColor = entry.Text.Length < MaxLength ? Color.Red : Color.Black;

                    break;

                case "Cnpj":
                    if (entryLength == LENGTH_CNPJ && !Formatado)
                    {
                        entryVal = Convert.ToUInt64(entryText);
                        entryText = entryVal.ToString(@"00\.000\.000\/0000\-00");
                        Formatado = true;
                    }
                    else if (entryText.Length > MaxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1);
                    }
                    else if (entryText.Length < MaxLength && Formatado)
                    {
                        entryText = entryText.RemoveNonNumbers();
                        Formatado = false;
                    }

                    entry.Text = entryText;
                    entry.TextColor = entry.Text.Length < MaxLength ? Color.Red : Color.Black;

                    break;

                case "Telefone":
                    if ((entryLength == LENGTH_PHONE_SEM_MASCARA_11 || entryLength == LENGTH_PHONE_SEM_MASCARA_14))
                    {
                        entryText = entryText.RemoveNonNumbers();                        entryVal = Convert.ToUInt64(entryText);
                        entryText = string.Format("{0:(##) ####-####}", entryVal);
                        Formatado = true;
                    }
                    else if (entryLength == 15)
                    {
                        entryText = entryText.RemoveNonNumbers();
                        entryVal = Convert.ToUInt64(entryText);
                        entryText = string.Format("{0:(##) #####-####}", entryVal);
                        Formatado = true;
                    }
                    else if (entryText.Length > MaxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1);
                    }
                    else if (entryText.Length < LENGTH_PHONE_SEM_MASCARA_14 && Formatado)
                    {
                        entryText = entry.Text.RemoveNonNumbers();
                        Formatado = false;
                    }

                    entry.Text = entryText;
                    entry.TextColor = entry.Text.Length < LENGTH_PHONE_SEM_MASCARA_11 ? Color.Red : Color.Black;

                    break;

                case "Data":
                    if (entryLength == LENGTH_DATE && !Formatado)
                    {
                        entryText = Convert.ToUInt64(entryText).ToString(@"00/00/0000");
                        Formatado = true;
                    }
                    else if (entryText.Length > MaxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1);
                    }
                    else if (entryText.Length < MaxLength && Formatado)
                    {
                        entryText = entryText.RemoveNonNumbers();
                        Formatado = false;
                    }

                    entry.Text = entryText;
                    entry.TextColor = entry.Text.Length < MaxLength ? Color.Red : Color.Black;

                    break;

                case "DataValidadeCartaoCredito":
                    if (entryLength == LENGTH_DATE_CARTAO_CREDITO && !Formatado)
                    {
                        entryText = Convert.ToUInt64(entryText).ToString(@"00/0000");
                        Formatado = true;
                    }
                    else if (entryText.Length > MaxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1);
                    }
                    else if (entryText.Length < MaxLength && Formatado)
                    {
                        //entryText = entryText.RemoveNonNumbers();
                        Formatado = false;
                    }

                    entry.Text = entryText;
                    entry.TextColor = entry.Text.Length < MaxLength ? Color.Red : Color.Black;

                    break;

                case "Decimal":

                    if (entryText != e.OldTextValue)
                    {
                        string strNumber = entryText.RemoveNonNumbers();

                        if (strNumber.Length > LENGTH_DECIMAL)
                        {
                            var pos = strNumber.Length - LENGTH_DECIMAL;
                            entryText = strNumber.Insert(pos, ",");
                            entry.Text = string.Format("{0:N2}", Convert.ToDecimal(entryText));
                        }
                    }

                    break;
            }
        }
    }
}