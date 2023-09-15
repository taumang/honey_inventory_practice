using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace honey_inventory_practice.Services.HoneyInventoryService
{
    public interface IHoneyInventoryService
    {
        Task<ServiceResponse<List<GetHoneyInventoryDto>>> GetAllHoneyInventory();
        Task<ServiceResponse<GetHoneyInventoryDto>> GetHoneyInventoryId(int id);
        Task<ServiceResponse<List<GetHoneyInventoryDto>>> AddHoneyInventory(AddHoneyInventoryDto newHoneyInventory);
        Task<ServiceResponse<GetHoneyInventoryDto>> UpdateHoneyInventory(UpdateHoneyInventoryDto updatedHoneyInventory);

        Task<ServiceResponse<List<GetHoneyInventoryDto>>> DeleteHoneyInventory(int id);
        
    }
}