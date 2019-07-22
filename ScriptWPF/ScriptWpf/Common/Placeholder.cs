using System.Windows.Controls;

namespace Script.Common
{
    public class Placeholder
    {
        private TextBox TextBox { get; }
        private string Text { get; set; }

        public Placeholder(TextBox textBox)
        {
            TextBox = textBox;
        }

        public void AddText(string text)
        {
            Text = text;
            TextBox.GotFocus += TextBox_GotFocus;
            TextBox.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextBox.Text == Text)
            {
                TextBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.Text = Text;
            }
        }
    }
}