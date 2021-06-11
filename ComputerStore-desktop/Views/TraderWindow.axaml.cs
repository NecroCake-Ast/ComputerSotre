using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ComputerStoreDesk.Views
{
    public partial class TraderWindow : Window
    {
        public TraderWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
