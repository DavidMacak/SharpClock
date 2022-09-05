using System.Windows;

namespace SharpClock
{
    public partial class GetTitleDialog : Window
    {
        public GetTitleDialog()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
