using ItemList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.ViewModel
{
    internal class DataItemViewModel: ViewModelBase
    {
        public int Id { get; private set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private DataItemStatus _status;
        public DataItemStatus Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        internal void UpdateFromModel(DataItem model)
        {
            if (Id != model.Id) return;

            Name = model.Name;
            Status = model.Status;
        }

        public static explicit operator DataItemViewModel(DataItem item)
        {
            DataItemViewModel viewModel = new DataItemViewModel
            {
                Id = item.Id
            };
            viewModel.UpdateFromModel(item);
            return viewModel;
        }

        public static explicit operator DataItem(DataItemViewModel vm)
        {
            return new DataItem
            {
                Id = vm.Id,
                Name = vm.Name,
                Status = vm.Status,
            };
        }

        public DataItemViewModel Clone()
        {
            return new DataItemViewModel
            {
                Id = Id,
                Name = Name,
                Status = Status,
            };
        }

    }
}
