using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, 2, 5, new Vehicle[5])
        {
            this.vehicles[0] = new Van();
            this.vehicles[1] = new Van();
            this.vehicles[2] = new Van();
        }
    }
}
