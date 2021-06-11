using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ComputerStoreDesk.Views
{
    public partial class StoreKeeperView : UserControl
    {
        public StoreKeeperView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
