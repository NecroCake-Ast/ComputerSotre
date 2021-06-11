using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ComputerStoreDesk.Pages
{
    public partial class Manufacturer : UserControl
    {
        public Manufacturer()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
