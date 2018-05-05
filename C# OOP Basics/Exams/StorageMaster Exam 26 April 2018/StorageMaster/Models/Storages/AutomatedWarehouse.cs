using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name)
            :base(name, 1, 2, new Vehicle[2])
        {
            this.vehicles[0] = new Truck();
        }
    }
}
