using ItemList.Model;
using ItemList.Services;
using ItemList.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.ViewModel
{
    internal class EditingWindowViewModel: ViewModelBase
    {
        public DataItemViewModel Item { get; private set; }

        //normally we would not want to reference a view from a view model,
        //here it's done to simplify opening and closing the window from the view model
        private EditingWindow _window;

        private readonly IDataService _dataService;

        public RelayCommand SaveCommand { get; }
        public RelayCommand CloseCommand { get; }

        public EditingWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.DataItemChanged += OnDataItemChanged;

            SaveCommand = new RelayCommand(OnSave);
            CloseCommand = new RelayCommand(OnClose);
        }

        private void OnSave()
        {
            if (Item != null)
            {
                _dataService.UpdateDataItem((DataItem)Item);
            }
            _window?.Close();
        }

        private void OnClose()
        {
            _window?.Close();
        }

        private void OnDataItemChanged(object sender, DataItemChangedEventArgs e)
        {
            if (Item?.Id == e.ChangedItem.Id)
            {
                Item.UpdateFromModel(e.ChangedItem);
            }
        }

        public void ShowWindow(DataItemViewModel item)
        {
            if (_window != null) return;

            _window = new EditingWindow { DataContext = this };

            Item = item;

            _window.Show();
        }
    }
}
