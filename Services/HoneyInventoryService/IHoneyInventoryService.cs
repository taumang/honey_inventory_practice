using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice.Services.HoneyInventoryService
{
    public interface IHoneyInventoryService
    {
        Task<ServiceResponse<List<HoneyInventory>>> GetAllHoneyInventory();
        Task<ServiceResponse<HoneyInventory>> GetHoneyInventoryId(int id);
        Task<ServiceResponse<List<HoneyInventory>>> AddHoneyInventory(HoneyInventory newHoneyInventory);
    }
}