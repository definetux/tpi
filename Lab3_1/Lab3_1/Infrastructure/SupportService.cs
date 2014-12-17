using System.Windows;

namespace Lab3_1.Infrastructure
{
    public class SupportService : ISupportService
    {
        public void Show(string text)
        {
            MessageBox.Show(text);
        }
    }
}