using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ComputerStoreDesk.Pages
{
    public partial class Storage : UserControl
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
