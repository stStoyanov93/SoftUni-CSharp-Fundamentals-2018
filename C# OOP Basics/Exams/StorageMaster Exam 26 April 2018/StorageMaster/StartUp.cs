using System;
using System.Linq;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var storageMaster = new StorageMaster();

            while (input != "END")
            {
                input = Console.ReadLine();
                var inputParams = input.Split();
                var command = inputParams[0];

                try
                {                   
                    switch (command)
                    {
                        case "AddProduct":
                            var productType = inputParams[1];
                            var productPrice = double.Parse(inputParams[2]);
                            Console.WriteLine(storageMaster.AddProduct(productType, productPrice));
                            break;
                        case "RegisterStorage":
                            var storageType = inputParams[1];
                            var storageName = inputParams[2];
                            Console.WriteLine(storageMaster.RegisterStorage(storageType, storageName));
                            break;
                        case "SelectVehicle":
                            var storageN = inputParams[1];
                            var garageSlot = int.Parse(inputParams[2]);
                            Console.WriteLine(storageMaster.SelectVehicle(storageN, garageSlot));
                            break;
                        case "LoadVehicle":
                            var products = inputParams.Skip(1);
                            Console.WriteLine(storageMaster.LoadVehicle(products));
                            break;
                        case "SendVehicleTo":
                            var sourceName = inputParams[1];
                            var sourceGarageSlot = int.Parse(inputParams[2]);
                            var destinationName = inputParams[3];
                            Console.WriteLine(storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                            break;
                        case "UnloadVehicle":
                            var storageNameUnl = inputParams[1];
                            var gs = int.Parse(inputParams[2]);
                            Console.WriteLine(storageMaster.UnloadVehicle(storageNameUnl, gs));
                            break;
                        case "GetStorageStatus":
                            var storageStatusName = inputParams[1];
                            Console.WriteLine(storageMaster.GetStorageStatus(storageStatusName));
                            break;
                        case "GetSummary":
                            Console.WriteLine(storageMaster.GetSummary());
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }                
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
