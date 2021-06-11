using ReactiveUI;

namespace ComputerStoreDesk.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        StoreKeeperViewModel StoreKeeper;
        AuthorizationViewModel Authorization;

        ViewModelBase _content;
        
        public MainWindowViewModel()
        {
            Authorization = new AuthorizationViewModel(this);
            StoreKeeper = new StoreKeeperViewModel(this);
            _content = Authorization;
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public void ShowLogin()
        {
            Content = Authorization;
        }

        public void ShowKeeper()
        {
            StoreKeeper.UpdateData();
            Content = StoreKeeper;
        }

    }
}
