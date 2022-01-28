using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList.Model
{
    internal class DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataItemStatus Status { get; set; }
    }

    public enum DataItemStatus
    {
        Pending,
        Open,
        Closed,
    }
}
