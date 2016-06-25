using System.Windows;

namespace TransmissionFluid
{
    /// <summary>
    /// Description for AddTorrentView.
    /// </summary>
    public partial class AddTorrentView : Window
    {
        /// <summary>
        /// Initializes a new instance of the AddTorrentView class.
        /// </summary>
        public AddTorrentView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Show(string fileName)
        {
            var vm = (ViewModel.AddTorrentViewModel)this.DataContext;
            if (vm != null)
            {
                vm.ReadTorrentFile(fileName);
            }
            this.Show();
        }
    }
}