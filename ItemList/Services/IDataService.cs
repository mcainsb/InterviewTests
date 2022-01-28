using ItemList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.Services
{
    internal interface IDataService
    {
        List<DataItem> GetAllDataItems();
        void UpdateDataItem(DataItem item);

        event EventHandler<DataItemChangedEventArgs> DataItemChanged;
    }
}
