using Avalonia.Controls;
using ComputerStoreDesk.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreDesk.ViewModels
{
    public class StoreKeeperViewModel : ViewModelBase
    {

        MainWindowViewModel _parent;
        ObservableCollection<ItemDetails> Items { get; set; }

        public StoreKeeperViewModel(MainWindowViewModel parent)
        {
            _parent = parent;
            
        }

        public void UpdateData()
        {
            Items = new ObservableCollection<ItemDetails>(Program.itemRepositary.List());
        }

        public void onItemSelect()
        {
            try
            {
                _parent.ShowLogin();
            }
            catch
            {

            }
        }
    }
}
