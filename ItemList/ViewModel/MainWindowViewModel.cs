using ItemList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.ViewModel
{
    internal class MainWindowViewModel: ViewModelBase
    {
        private readonly Func<EditingWindowViewModel> _editingWindowVMFactory;

        public MainWindowViewModel(IDataService dataService,
            Func<EditingWindowViewModel> editingWindowVMFactory)
        {
            _editingWindowVMFactory = editingWindowVMFactory;

            Items = new ObservableCollection<DataItemViewModel>(
                dataService.GetAllDataItems().Select(i => (DataItemViewModel)i));

            dataService.DataItemChanged += OnDataItemChanged;

            OpenForEditingCommand = new RelayCommand<DataItemViewModel>(OnOpenItem);
        }

        private void OnOpenItem(DataItemViewModel item)
        {
            EditingWindowViewModel windowVm = _editingWindowVMFactory();
            windowVm.ShowWindow(item.Clone());

        }

        private void OnDataItemChanged(object sender, DataItemChangedEventArgs e)
        {
            DataItemViewModel vm = Items.FirstOrDefault(item => item.Id == e.ChangedItem.Id);
            if (vm != null) vm.UpdateFromModel(e.ChangedItem);
        }

        public ObservableCollection<DataItemViewModel> Items { get; set; }

        public RelayCommand<DataItemViewModel> OpenForEditingCommand { get; }
    }
}
