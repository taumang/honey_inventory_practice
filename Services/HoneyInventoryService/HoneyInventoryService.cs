using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice.Services.HoneyInventoryService
{
    public class HoneyInventoryService : IHoneyInventoryService
    {

        private static List<HoneyInventory> honeyInventories = new List<HoneyInventory>{
            new HoneyInventory(),
            new HoneyInventory { 
                Id = 1, 
                UnitNumber = "Number12" 
                }
        };

        public async Task<ServiceResponse<List<HoneyInventory>>> AddHoneyInventory(HoneyInventory newHoneyInventory)
        {
            var serviceResponse = new ServiceResponse<List<HoneyInventory>>();
           honeyInventories.Add(newHoneyInventory);
           serviceResponse.Data = honeyInventories;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HoneyInventory>>> GetAllHoneyInventory()
        {
            var serviceResponse = new ServiceResponse<List<HoneyInventory>>();
            serviceResponse.Data = honeyInventories;
            return serviceResponse;
        }

        public async Task<ServiceResponse<HoneyInventory>> GetHoneyInventoryId(int id)
        {
            var serviceResponse = new ServiceResponse<HoneyInventory>();
            var honeyInventory = honeyInventories.FirstOrDefault(hi => hi.Id == id);
            serviceResponse.Data = honeyInventory;
            return serviceResponse;
        }
    }

    
}