using ItemList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.Services
{
    internal class DataService : IDataService
    {
        //simplified data storage - in real life, this would be a database
        private readonly List<DataItem> _data = new List<DataItem>
        {
            new DataItem{ Id = 1, Name = "Upcoming work", Status = DataItemStatus.Pending },
            new DataItem{ Id = 2, Name = "Current work 1", Status = DataItemStatus.Open },
            new DataItem{ Id = 3, Name = "Current work 2", Status = DataItemStatus.Open },
            new DataItem{ Id = 4, Name = "Finished work", Status = DataItemStatus.Closed },
        };

        public event EventHandler<DataItemChangedEventArgs> DataItemChanged;


        public List<DataItem> GetAllDataItems()
        {
            return new List<DataItem>(_data);
        }

        public void UpdateDataItem(DataItem item)
        {
            lock (_data)
            {
                int existingItemIndex = _data.FindIndex(i => i.Id == item.Id);
                if (existingItemIndex < 0) return;

                _data[existingItemIndex] = item;
                DataItemChanged?.Invoke(this, new DataItemChangedEventArgs{ ChangedItem = item });
            }
        }
    }

    internal class DataItemChangedEventArgs : EventArgs
    {
        public DataItem ChangedItem { get; set; }
    }

}
