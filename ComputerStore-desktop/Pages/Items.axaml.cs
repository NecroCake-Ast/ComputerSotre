using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ComputerStoreDesk.Pages
{
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
