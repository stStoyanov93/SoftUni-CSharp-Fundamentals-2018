using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        public Warehouse(string name)
           : base(name, 10, 10, new Vehicle[10])
        {
            this.vehicles[0] = new Semi();
            this.vehicles[1] = new Semi();
            this.vehicles[2] = new Semi();
        }
    }
}
